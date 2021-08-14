using BwMelder.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BwMelder.Data
{
    public static class BwRaceDataSeeding
    {
        public static void AddBwRaces(this ModelBuilder modelBuilder)
        {
            var races = new List<Race>()
            {
                new() { Id = 1, Number = "1", Name = "Jung 1x 14", RowerCount = 1, Coxed = false },
                new() { Id = 2, Number = "2", Name = "Jung 1x 14 LG", RowerCount = 1, Coxed = false },
                new() { Id = 3, Number = "3", Name = "Mäd 1x 14", RowerCount = 1, Coxed = false },
                new() { Id = 4, Number = "4", Name = "Mäd 1x 14 LG", RowerCount = 1, Coxed = false },
                new() { Id = 5, Number = "5", Name = "Jung 2x 13/14", RowerCount = 2, Coxed = false },
                new() { Id = 6, Number = "6", Name = "Jung 2x 13/14 LG", RowerCount = 2, Coxed = false },
                new() { Id = 7, Number = "7", Name = "Mäd 2x 13/14", RowerCount = 2, Coxed = false },
                new() { Id = 8, Number = "8", Name = "Mäd 2x 13/14 LG", RowerCount = 2, Coxed = false },
                new() { Id = 9, Number = "9", Name = "Jung 4x+ 13/14", RowerCount = 4, Coxed = true },
                new() { Id = 10, Number = "10", Name = "Mäd 4x+ 13/14", RowerCount = 4, Coxed = true },
                new() { Id = 11, Number = "11", Name = "Jung/Mäd 4x+ 13/14 Mix", RowerCount = 4, Coxed = true }
            };

            modelBuilder.Entity<Race>().HasData(races);
        }
    }
}
