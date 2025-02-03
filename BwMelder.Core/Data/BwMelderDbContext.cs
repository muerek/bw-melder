using BwMelder.Core.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text.Json;

namespace BwMelder.Core.Data;

public class BwMelderDbContext(DbContextOptions<BwMelderDbContext> options) : DbContext(options)
{
    internal DbSet<AccessKey> AccessKeys => Set<AccessKey>();
    internal DbSet<Athlete> Athletes => Set<Athlete>();
    internal DbSet<Club> Clubs => Set<Club>();
    internal DbSet<ClubCoach> ClubCoaches => Set<ClubCoach>();
    internal DbSet<Crew> Crews => Set<Crew>();
    internal DbSet<Race> Races => Set<Race>();
    internal DbSet<TeamCoach> TeamCoaches => Set<TeamCoach>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Participant>(builder =>
        {
            // Create a table for the Participant base type.
            // This table is not exposed as a separate DbSet.
            builder.ToTable("Participants");

            // Address and Diet are a nested types.
            builder.ComplexProperty(p => p.Address);
            builder.ComplexProperty(p => p.Diet);
            builder.ComplexProperty(p => p.Name);
        });

        modelBuilder.Entity<AccessKey>(builder =>
        {
            // Database ID is not exposed.
            builder.Property<int>("Id");
            builder.HasKey("Id");
        });

        modelBuilder.Entity<Athlete>(builder =>
        {
            // LegalGuardian is a nested type.
            builder.ComplexProperty(
                a => a.LegalGuardian,
                b =>
                {
                    // LegalGuardian contains nested types itself.
                    b.ComplexProperty(lg => lg.Contact);
                    b.ComplexProperty(lg => lg.Name);
                });
        });

        modelBuilder.Entity<ClubCoach>(builder =>
        {
            builder.ComplexProperty(cc => cc.Contact);
            builder.ComplexProperty(cc => cc.Name);
        });

        modelBuilder.Entity<TeamCoach>(builder =>
        {
            builder.ComplexProperty(tc => tc.Contact);
            builder.ComplexProperty(tc => tc.Name);
        });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Seed database with default race data.
        optionsBuilder.UseSeeding((context, _) =>
        {
            // Do not do anything if for whatever reason the table contains data.
            if(context.Set<Race>().Any()) { return; }
            
            var races = GetDefaultRaces();
            if (races is null) { return; }
            context.Set<Race>().AddRange(races);
            context.SaveChanges();
        })
        .UseAsyncSeeding(async (context, _, cancellationToken) =>
        {
            // Do not do anything if for whatever reason the table contains data.
            if (await context.Set<Race>().AnyAsync(cancellationToken)) { return; }

            var races = GetDefaultRaces();
            if (races is null) { return; }
            context.Set<Race>().AddRange(races);
            await context.SaveChangesAsync(cancellationToken);
        });
    }

    /// <summary>
    /// Reads the default race data from an embedded resource file.
    /// </summary>
    /// <returns>List of races, or null if nothing was found.</returns>
    private static IList<Race>? GetDefaultRaces()
    {
        // Try to find and open seed data file in assembly.
        var assembly = Assembly.GetExecutingAssembly();
        using var stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.Data.default_races.json");

        // Read and parse JSON data from the file.
        if (stream is null) { return null; }
        var races = JsonSerializer.Deserialize<IList<Race>>(stream);

        return races;
    }
}
