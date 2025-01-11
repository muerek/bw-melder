using BwMelder.Data;
using BwMelder.Dto;
using BwMelder.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography;

namespace BwMelder.Services;

/// <summary>
/// Handles access keys.
/// </summary>
class AccessKeyService(BwMelderDbContext db)
{
    /// <summary>
    /// Determines if an access key is valid.
    /// </summary>
    /// <param name="key">Access key to validate.</param>
    /// <returns>Boolean result of the check.</returns>
    /// <remarks>This does not really fit in here, but there is no better place right now either.</remarks>
    public static bool ValidateAccessKey(AccessKey key) =>
        key.Active && key.NotBefore <= DateTime.Now && DateTime.Now <= key.NotAfter;

    /// <summary>
    /// Gets a list of accesses the clubs hold.
    /// </summary>
    /// <returns></returns>
    public async Task<IList<ClubAccess>> GetClubAccessesAsync()
    {
        var clubs = await db.Clubs
            .AsNoTracking()
            .Include(c => c.AccessKeys)
            .ToListAsync();

        return clubs.Select(c => new ClubAccess
        {
            ClubId = c.Id,
            ClubName = c.Name,
            // TODO: Include base URI.
            SecretUrl = c.AccessKeys.FirstOrDefault(ak => ValidateAccessKey(ak))?.Secret
        }).ToList();
    }

    /// <summary>
    /// Creates and stores a new access key for a club.
    /// All existing access keys will be invalidated.
    /// </summary>
    /// <param name="clubId">Link the access key to the club identified by this ID.</param>
    /// <returns>New access key.</returns>
    public async Task<AccessKey> CreateAccessKeyAsync(Guid clubId)
    {
        // Generate a new key.
        var accessKey = new AccessKey()
        {
            Secret = await GenerateUniqueSecretAsync(),
            ClubId = clubId
        };

        // Invalidate any existing keys for this club.
        await db.AccessKeys
            .Where(a => a.ClubId == clubId)
            .ExecuteUpdateAsync(setters => setters.SetProperty(a => a.Active, false));

        // Save the new key.
        db.AccessKeys.Add(accessKey);
        await db.SaveChangesAsync();

        return accessKey;
    }

    /// <summary>
    /// Generates a new secret guaranteed not to be in use.
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
}
