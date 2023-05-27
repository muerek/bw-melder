using BwMelder.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BwMelder.Data
{
    public class BwMelderDbContext : DbContext
    {
        public DbSet<Athlete> Athletes => Set<Athlete>();

        public DbSet<Race> Races => Set<Race>();

        public DbSet<Crew> Crews => Set<Crew>();

        public DbSet<HomeCoach> HomeCoaches => Set<HomeCoach>();
        public DbSet<TeamCoach> TeamCoaches => Set<TeamCoach>();
        public DbSet<TeamCoachKey> TeamCoachKeys => Set<TeamCoachKey>();

        public BwMelderDbContext(DbContextOptions<BwMelderDbContext> options) : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Add participant base class to model without making a separate DbSet.
            modelBuilder.Entity<Participant>().ToTable("Participants");

            // Add predefined race data.
            modelBuilder.AddBwRaces();
        }
    }
}
