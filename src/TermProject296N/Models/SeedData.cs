using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TermProject296N.Repository;
using TermProject296N.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace TermProject296N.Models
{
    public class SeedData {
        public static void EnsurePopulated(IApplicationBuilder app) {
            ApplicationDbContext context = app.ApplicationServices
                .GetRequiredService<ApplicationDbContext>();
            if (!context.Games.Any()) {
                Game g = new Game() {
                    Title = "Halo 5",
                    Platform = "Xbox One",
                    Description = "The fifth iteration in the Halo series.",
                    TotalUsers = 0
                };

                context.Games.Add(g);

                g = new Game() {
                    Title = "Pokemon Sun/Moon",
                    Platform = "Nintendo 3DS",
                    Description = "Travel to the isles of Alona Region to become the next Pokemon League Champ",
                    TotalUsers = 0
                };

                context.Games.Add(g);

                context.SaveChanges();
            }

        }
    }
}
