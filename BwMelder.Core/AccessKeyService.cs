using BwMelder.Shared.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography;
using BwMelder.Shared.Services;
using BwMelder.Core.Model;

namespace BwMelder.Core;

/// <summary>
/// Handles access keys.
/// </summary>
public class AccessKeyService(BwMelderDbContext db)
    : IAccessKeyService
{
    public async Task<AuthenticationResponse> AuthenticateAsync(string secret)
    {
        var accessKey = await db.AccessKeys
            .AsNoTracking()
            .SingleOrDefaultAsync(k => k.Secret == secret);

        if (accessKey != null && ValidateAccessKey(accessKey))
        {
            // Club is needed to get the club name and club coach.
            var club = await db.Clubs
                .AsNoTracking()
                .Include(c => c.ClubCoach)
                .SingleAsync(c => c.Id == accessKey.ClubId);

            return new AuthenticationResponse
            {
                IsSuccess = true,
                Role = "ClubCoach",
                // Require onboarding if club coach is not set.
                OnboardingRequired = club.ClubCoach is null,
                ClubId = club.Id,
                ClubName = club.Name
            };
        }

        return new AuthenticationResponse { IsSuccess = false };
    }

    public async Task<IList<ClubKey>> GetClubKeysAsync()
    {
        var clubs = await db.Clubs
            .AsNoTracking()
            .Include(c => c.AccessKeys)
            .ToListAsync();

        return clubs.Select(c => new ClubKey
        {
            ClubId = c.Id,
            ClubName = c.Name,
            // TODO: Include base URI.
            SecretUrl = c.AccessKeys.FirstOrDefault(ak => ValidateAccessKey(ak))?.Secret
        }).ToList();
    }

    public async Task<string> RenewAccessAsync(Guid clubId)
    {
        // Generate a new key.
        var accessKey = new AccessKey
        {
            Secret = await GenerateUniqueSecretAsync(),
            ClubId = clubId
        };

        await LockAccessAsync(clubId);
        // Save the new key.
        db.AccessKeys.Add(accessKey);
        await db.SaveChangesAsync();

        return accessKey.Secret;
    }

    public async Task LockAccessAsync(Guid clubId)
    {
        await db.AccessKeys
            .Where(a => a.ClubId == clubId)
            .ExecuteUpdateAsync(setters => setters.SetProperty(a => a.Active, false));
    }

    /// <summary>
    /// Generates a new secret guaranteed not to be in use in any other access key.
    /// </summary>
    /// <returns>New secret.</returns>
    private async Task<string> GenerateUniqueSecretAsync()
    {
        // Only use URL-friendly characters.
        var alphabet = "abcdefghijklmnopqrstuvwxyz123456789";
        // 14 characters should give us more than enough space to operate collision-free and prevent enumeration.
        string GenerateSecret() => RandomNumberGenerator.GetString(alphabet, 14);

        for (int attempts = 3; attempts > 0; attempts--)
        {
            var secret = GenerateSecret();
            // If the secret is already in use, try again.
            if (await db.AccessKeys.AnyAsync(k => k.Secret == secret))
            {
                continue;
            }
            return secret;
        }

        throw new Exception("Could not generate unique secret. While not impossible, this is highly unlikely to occur.");
    }

    /// <summary>
    /// Determines if an access key is valid.
    /// </summary>
    /// <param name="key">Access key to validate.</param>
    /// <returns>Boolean result of the check.</returns>
    private static bool ValidateAccessKey(AccessKey key) =>
        key.Active && key.NotBefore <= DateTime.Now && DateTime.Now <= key.NotAfter;
}
