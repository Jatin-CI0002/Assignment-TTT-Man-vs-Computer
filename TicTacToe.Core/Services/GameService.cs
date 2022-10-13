using System;
using TicTacToe.Contracts;
using TicTacToe.Contracts.Models;
using TicTacToe.Core.Services;

namespace TicTacToe.Core
{
    public class GameService : IGameService
    {
        private static string opponent = "x", player = "o";
        private readonly GameContext _dbContext;
        public GameService(GameContext gameContext)
        {
            _dbContext = gameContext;
        }

        public Move FindBestMove(string[,] board)
        {
            int bestVal = -1000;
            Move bestMove = new Move();
            bestMove.row = -1;
            bestMove.column = -1;

            // Traverse all cells, evaluate minimax function
            // for all empty cells. And return the cell
            // with optimal value.
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    // Check if cell is empty
                    if (board[i, j] == "")
                    {
                        // Make the move
                        board[i, j] = player;

                        // compute evaluation function for this
                        // move.
                        int moveVal = findOptimal(board, 0, false);

                        // Undo the move
                        board[i, j] = "";

                        // If the value of the current move is
                        // more than the best value, then update
                        // best/
                        if (moveVal > bestVal)
                        {
                            bestMove.row = i;
                            bestMove.column = j;
                            bestVal = moveVal;
                        }
                    }
                }
            }
            return bestMove;
        }
        // This is the optimal function. It considers all
        // the possible ways the game can go and returns
        // the value of the board
        private int findOptimal(string[,] board,
                           int depth, Boolean isMax)
        {
            int score = evaluate(board);

            //for computer move
            if (score == 10)
                return score;

            //for user move
            if (score == -10)
                return score;

            // for draw / tie
            if (isMovesLeft(board) == false)
                return 0;

            // If this computer's move
            if (isMax)
            {
                int best = -1000;

                // Traverse all cells
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        // Check if cell is empty
                        if (board[i, j] == "")
                        {
                            // using recursive take or not take approach
                            board[i, j] = player;
                            best = Math.Max(best, findOptimal(board,
                                            depth + 1, !isMax));

                            board[i, j] = "";
                        }
                    }
                }
                return best;
            }

            // If this user's move
            else
            {
                int best = 1000;

                // Traverse all cells
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        // Check if cell is empty
                        if (board[i, j] == "")
                        {
                            board[i, j] = opponent;

                            // again using take or not take recursive approach
                            best = Math.Min(best, findOptimal(board,
                                            depth + 1, !isMax));

                            board[i, j] = "";
                        }
                    }
                }
                return best;
            }
        }

        private int evaluate(string[,] board)
        {
            // Checking for Rows for X or O victory.
            for (int row = 0; row < 3; row++)
            {
                if (board[row, 0] == board[row, 1] &&
                    board[row, 1] == board[row, 2])
                {
                    if (board[row, 0] == player)
                        return +10;
                    else if (board[row, 0] == opponent)
                        return -10;
                }
            }

            // Checking for Columns for X or O victory.
            for (int col = 0; col < 3; col++)
            {
                if (board[0, col] == board[1, col] &&
                    board[1, col] == board[2, col])
                {
                    if (board[0, col] == player)
                        return +10;

                    else if (board[0, col] == opponent)
                        return -10;
                }
            }

            // Checking for Diagonals for X or O victory.
            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            {
                if (board[0, 0] == player)
                    return +10;
                else if (board[0, 0] == opponent)
                    return -10;
            }

            if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            {
                if (board[0, 2] == player)
                    return +10;
                else if (board[0, 2] == opponent)
                    return -10;
            }

            return 0;
        }

        // This function returns true if there are moves
        // remaining on the board. It returns false if
        // there are no moves left to play.
        private Boolean isMovesLeft(string[,] board)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (board[i, j] == "")
                        return true;
            return false;
        }

        public GameResult CreateResult(GameResult gameResult)
        {
            if (gameResult.Winner == null && gameResult.Loser == null)
                gameResult.Draw = true;

            _dbContext.GameResults.Add(gameResult);
            _dbContext.SaveChanges();
            return gameResult;
        }
    } 
}


