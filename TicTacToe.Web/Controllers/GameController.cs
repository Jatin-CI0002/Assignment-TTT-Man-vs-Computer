using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TicTacToe.Contracts;
using TicTacToe.Contracts.Models;
using TicTacToe.Core;
using TicTacToe.Core.Helper;
using TicTacToe.Core.Services;

namespace TicTacToe.Web
{
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;
        private readonly ComputerLogic _computerLogic;
        public GameController(IGameService gameService)
        {
            _gameService = gameService;
            _computerLogic = new ComputerLogic();
        }

        [Route("api/nextmove")]
        [HttpPost]
        public IActionResult NextMove([FromBody] List<string> moves)
        {
            string[,] board = new string[3, 3];
            int row = 0;
            int col = 0;
            foreach(var move in moves)
            {
                if (col == 3)
                {
                    col = 0;
                    row++;
                }

                if (col < 3)
                    board[row, col++] = move;
                
            }

            var cordinates = _computerLogic.FindBestMove(board);
            var data = new
            {
                row = cordinates.row,
                col = cordinates.column
            };
            return Ok(data);
        }

        [Route("api/score")]
        [HttpPost]
        public IActionResult Score(GameResult gameScore)
        {
            var createdresult = _gameService.Score(gameScore);
            return CreatedAtAction(nameof(Score), new { id = gameScore.Id }, createdresult);
        }
    }
}
