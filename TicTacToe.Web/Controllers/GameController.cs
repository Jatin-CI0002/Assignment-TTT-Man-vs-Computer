using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TicTacToe.Core;

namespace TicTacToe.Web
{
    [ApiController]
    public class GameController : ControllerBase
    {
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

            var cordinates = GameService.findBestMove(board);
            var data = new
            {
                row = cordinates.row,
                col = cordinates.column
            };
            return Ok(data);
        }
    }
}
