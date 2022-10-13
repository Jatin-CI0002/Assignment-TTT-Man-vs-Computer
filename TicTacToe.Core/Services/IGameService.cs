using System;
using System.Collections.Generic;
using System.Text;
using TicTacToe.Contracts;
using TicTacToe.Contracts.Models;

namespace TicTacToe.Core.Services
{
    public interface IGameService
    {
        public GameResult Score(GameResult gameResult);
    }
}
