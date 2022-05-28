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
                new() { Id = 1, Number = "A", Name = "Jung 1x 13", RowerCount = 1, Coxed = false },
                new() { Id = 2, Number = "B", Name = "Jung 1x 13 LG", RowerCount = 1, Coxed = false },
                new() { Id = 3, Number = "C", Name = "Mäd 1x 13", RowerCount = 1, Coxed = false },
                new() { Id = 4, Number = "D", Name = "Mäd 1x 13 LG", RowerCount = 1, Coxed = false },
                new() { Id = 5, Number = "E", Name = "Jung 2x 12/13", RowerCount = 2, Coxed = false },
                new() { Id = 6, Number = "F", Name = "Jung 2x 12/13 LG", RowerCount = 2, Coxed = false },
                new() { Id = 7, Number = "G", Name = "Mäd 2x 12/13", RowerCount = 2, Coxed = false },
                new() { Id = 8, Number = "H", Name = "Mäd 2x 12/13 LG", RowerCount = 2, Coxed = false },
                new() { Id = 9, Number = "I", Name = "Jung 4x+ 12/13", RowerCount = 4, Coxed = true },
                new() { Id = 10, Number = "J", Name = "Mäd 4x+ 12/13", RowerCount = 4, Coxed = true },
                new() { Id = 11, Number = "K", Name = "Jung/Mäd 4x+ 12/13 Mix", RowerCount = 4, Coxed = true },
                new() { Id = 12, Number = "L", Name = "Jung 1x 14", RowerCount = 1, Coxed = false },
                new() { Id = 13, Number = "M", Name = "Jung 1x 14 LG", RowerCount = 1, Coxed = false },
                new() { Id = 14, Number = "N", Name = "Mäd 1x 14", RowerCount = 1, Coxed = false },
                new() { Id = 15, Number = "O", Name = "Mäd 1x 14 LG", RowerCount = 1, Coxed = false },
                new() { Id = 16, Number = "P", Name = "Jung 2x 13/14", RowerCount = 2, Coxed = false },
                new() { Id = 17, Number = "Q", Name = "Jung 2x 13/14 LG", RowerCount = 2, Coxed = false },
                new() { Id = 18, Number = "R", Name = "Mäd 2x 13/14", RowerCount = 2, Coxed = false },
                new() { Id = 19, Number = "S", Name = "Mäd 2x 13/14 LG", RowerCount = 2, Coxed = false },
                new() { Id = 20, Number = "T", Name = "Jung 4x+ 13/14", RowerCount = 4, Coxed = true },
                new() { Id = 21, Number = "U", Name = "Mäd 4x+ 13/14", RowerCount = 4, Coxed = true },
                new() { Id = 22, Number = "V", Name = "Jung/Mäd 4x+ 13/14 Mix", RowerCount = 4, Coxed = true }
            };

            modelBuilder.Entity<Race>().HasData(races);
        }
    }
}
