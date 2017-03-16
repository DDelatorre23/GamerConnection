using TermProject296N.Models;
using System.Collections.Generic;

namespace TermProject296N.Repository
{
    public interface IUser
    {
        IEnumerable<User> GetAllUsers();
        User GetUserByID(int id);
        List<User> GetUserByUserName(string username);
        List<User> GetUserByFavoriteGame(string game);
        void AddGameToFavoritesList(User user, Game game);
        void Update(User user);
    }
}

// TODO: implement full user interface/repository/controller
// TODO: implement full MVC for requests 
// TODO: implement master page and other necessary layouts.