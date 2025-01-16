using BwMelder.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace BwMelder.Core;

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
        // The Participant class is required for the database model.
        // But it should not be a separate DbSet as it is just an abstract base class.
        modelBuilder.Entity<Participant>().ToTable("Participants");

        // Address does not appear on its own.
        modelBuilder.Entity<Participant>().OwnsOne(p => p.Address);

        // Diet does not appear on its own.
        modelBuilder.Entity<Participant>().OwnsOne(p => p.Diet);

        // Contact does not appear on its own.
        modelBuilder.Entity<TeamCoach>().OwnsOne(tc => tc.Contact);
        modelBuilder.Entity<ClubCoach>().OwnsOne(cc => cc.Contact);

        // LegalGuardian does not appear on its own.
        // It also holds a nested Contact class.
        modelBuilder.Entity<Athlete>().OwnsOne(a => a.LegalGuardian, lg => { lg.OwnsOne(g => g.Contact); });

    }
}
