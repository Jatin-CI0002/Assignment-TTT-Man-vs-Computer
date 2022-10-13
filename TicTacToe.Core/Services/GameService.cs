using System;
using TicTacToe.Contracts;
using TicTacToe.Contracts.Models;
using TicTacToe.Core.Services;

namespace TicTacToe.Core
{
    public class GameService : IGameService
    {
        private readonly GameContext _dbContext;
        public GameService(GameContext gameContext)
        {
            _dbContext = gameContext;
        }

        public GameResult Score(GameResult gameScore)
        {
            if (gameScore.Winner == null && gameScore.Loser == null)
                gameScore.Draw = true;

            _dbContext.GameResults.Add(gameScore);
            _dbContext.SaveChanges();
            return gameScore;
        }
    } 
}


