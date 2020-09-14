using System;
using System.Threading;

namespace Gomoku
{
    class Program
    {
        static void Main(string[] args)
        {
            int boardSize = 15;

            GameBoard GameBoard = new GameBoard(boardSize);
            GameBoard.CreateBoard();
            char[,] board = GameBoard.Board;

            Referee referee = new Referee(board);

            Player1 player1 = new Player1('X');
            Player1 player2 = new Player1('0');


            while (true)
            {
                Figure figure1 = player1.Move(board);
                board[figure1.y, figure1.x] = player1.sym;
                Thread.Sleep(1500);
                Console.Clear();
                GameBoard.DrawGameBoard(board);
                referee.CheckWinner(board);
                if (referee.CheckWinner(board)) break;
                else
                {
                    Figure figure2 = player2.Move(board);
                    board[figure2.y, figure2.x] = player2.sym;
                    Thread.Sleep(1500);
                    Console.Clear();
                    GameBoard.DrawGameBoard(board);
                    if(referee.CheckWinner(board)) break;
                }
            }
        }
    }
}
