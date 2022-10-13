using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TicTacToe.Contracts;
using TicTacToe.Contracts.Models;
using TicTacToe.Core;
using TicTacToe.Core.Services;

namespace TicTacToe.Web
{
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;
        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [Route("api/getindex")]
        [HttpPost]
        public IActionResult GetCordinates([FromBody] List<string> characters)
        {
            string[,] board = new string[3, 3];
            int row = 0;
            int col = 0;
            foreach(var character in characters)
            {
                if (col == 3)
                {
                    col = 0;
                    row++;
                }

                if (col < 3)
                    board[row, col++] = character;
                
            }

            var cordinates = _gameService.FindBestMove(board);
            var data = new
            {
                row = cordinates.row,
                col = cordinates.column
            };
            return Ok(data);
        }

        [Route("api/winner")]
        [HttpPost]
        public IActionResult GetWinnerData(GameResult gameResult)
        {
            var createdresult = _gameService.CreateResult(gameResult);
            return CreatedAtAction(nameof(GetWinnerData), new { id = gameResult.Id }, createdresult);
        }
    }
}
