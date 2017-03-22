using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TermProject296N.Repository;
using TermProject296N.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TermProject296N.Models
{
    public class SeedData {
        public static async void EnsurePopulated(IApplicationBuilder app) {
            ApplicationDbContext context = app.ApplicationServices
                .GetRequiredService<ApplicationDbContext>();

            string firstName = "Daniel";
            string lastName = "DelaTorre";
            string username = "Tzunami";
            string email = "DJ.Tower223@gmail.com";
            string password = "P@ssword23";
            string role = "Admin";

            UserManager<User> userManager = app.ApplicationServices.GetRequiredService<UserManager<User>>();
            RoleManager<IdentityRole> roleManager = app.ApplicationServices.GetRequiredService<RoleManager<IdentityRole>>();

            if (!context.Games.Any()) {
                User user = await userManager.FindByNameAsync(username);
                if (user == null) {
                    user = new User { FirstName = firstName, LastName = lastName, UserName = username, Email = email };
                    IdentityResult result = await userManager.CreateAsync(user, password);
                    if (await roleManager.FindByNameAsync(role) == null) {
                        await roleManager.CreateAsync(new IdentityRole(role));

                    }
                    if (await roleManager.FindByNameAsync("Member") == null) {
                        await roleManager.CreateAsync(new IdentityRole("Member"));
                        if (result.Succeeded) {
                            await userManager.AddToRoleAsync(user, "Member");
                        }

                    }
                }
               



                Game g = new Game() {
                    Title = "Halo 5",
                    Platform = "Xbox One",
                    Description = "The fifth iteration in the Halo series.",
                    TotalUsers = 0
                };

                context.Games.Add(g);

                g = new Game() {
                    Title = "Call of Duty: Advanced Warfare",
                    Platform = "Playstation 4",
                    Description = "Shoot bad guys",
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
