using System.Collections.Generic;
using System.Linq;
using TermProject296N.Models;


namespace TermProject296N.Repository
{
    // TODO: Determine if I should add ratings to the Game object.
    // TODO: Should I add CRUD functions for admins to alter or create games to the DB.
    public class GameRepository : IGame
    {
        ApplicationDbContext context;

        public GameRepository (ApplicationDbContext ctx) {
            context = ctx;
        }

        public IEnumerable<Game> GetAllGames() {
            return context.Games;
        }

        public List<Game> GetGamesByPlatform(string platform) {
            return context.Games.Where(
                p => p.Platform == platform).ToList();
        }

        public List<Game> GetGamesByTitle(string title) {
            return context.Games.Where(
                t => t.Title == title).ToList();
        }
    }
}
