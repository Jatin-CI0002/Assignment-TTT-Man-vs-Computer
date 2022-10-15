using System;
using System.ComponentModel.DataAnnotations;

namespace TicTacToe.Contracts.Models
{
    public class GameResult
    {
        [Key]
        public int Id { get; set; }
        public Boolean Draw { get; set; }
        public string Winner { get; set; }
        public string Loser { get; set; }
        public int XCount { get; set; }
        public int OCount { get; set; }
        public string GameState { get; set; }

    }
}
