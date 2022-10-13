using Microsoft.EntityFrameworkCore;
using TicTacToe.Contracts.Models;

namespace TicTacToe.Core
{
    public class GameContext : DbContext
    {
        public GameContext(DbContextOptions<GameContext> options) :base(options){ }

        public DbSet<GameResult> GameResults { get; set; }
    }
}
