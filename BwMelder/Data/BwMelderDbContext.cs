using BwMelder.Model;
using Microsoft.EntityFrameworkCore;

namespace BwMelder.Data;

public class BwMelderDbContext : DbContext
{
    public DbSet<AccessKey> AccessKeys => Set<AccessKey>();
    public DbSet<Athlete> Athletes => Set<Athlete>();
    public DbSet<Club> Clubs => Set<Club>();
    public DbSet<ClubCoach> ClubCoaches => Set<ClubCoach>();
    public DbSet<Crew> Crews => Set<Crew>();
    public DbSet<Race> Races => Set<Race>();
    public DbSet<TeamCoach> TeamCoaches => Set<TeamCoach>();

    public BwMelderDbContext(DbContextOptions<BwMelderDbContext> options) : base(options) { }

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
