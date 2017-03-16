using System;
using System.Linq;
using System.Collections.Generic;
using TermProject296N.Models;
using Microsoft.EntityFrameworkCore;

namespace TermProject296N.Repository {
    public class UserRepository : IUser
    {
        AppIdentityDbContext context;

        public UserRepository (AppIdentityDbContext ctx) {
            context = ctx;
        }

        public void AddGameToFavoritesList(User user, Game game) {
            user.FavoriteGames.Add(game);
        }

        public IEnumerable<User> GetAllUsers() {
            return context.Users;
        }

        public List<User> GetUserByFavoriteGame(string game) {
            return context.Users.Where(u => 
            u.FavoriteGames.Select(t => t.Title == game)
            .FirstOrDefault())
            .ToList();
        }

        public User GetUserByID(int id) {
            return context.Users.Where(u => u.UserID == id).SingleOrDefault();
        }

        public List<User> GetUserByUserName(string username) {
            return context.Users.Where(n => n.UserName == username).ToList(); 
        }

        public void Update(User user) {
            context.Users.Update(user);
            context.SaveChanges();
        }
    }
}
