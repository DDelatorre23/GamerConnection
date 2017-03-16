using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TermProject296N.Models;
namespace TermProject296N.Repository
{
    public interface IGame
    {
        IEnumerable<Game> GetAllGames();
        List<Game> GetGamesByTitle(string title);
        List<Game> GetGamesByPlatform(string platform);
    }
}
