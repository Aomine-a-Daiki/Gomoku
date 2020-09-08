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
            GameBoard.DrawGameBoard(board);
            Thread.Sleep(600);
            Console.Clear();
            board[4, 7] = 'x';
            board[5, 7] = 'x';
            board[6, 7] = 'x';
            board[7, 7] = 'x';
            board[8, 7] = 'x';

            board[0, 10] = 'y';
            board[0, 11] = 'y';
            board[0, 12] = 'y';
            board[0, 13] = 'y';
            board[0, 14] = 'y';

            board[10, 0] = '1';
            board[11, 1] = '1';
            board[12, 2] = '1';
            board[13, 3] = '1';
            board[14, 4] = '1';

            board[0, 5] = '2';
            board[1, 4] = '2';
            board[2, 3] = '2';
            board[3, 2] = '2';
            board[4, 1] = '2';
            GameBoard.DrawGameBoard(board);


            int cnt = 0;
            
            for(int i = 0; i < board.GetLength(0); i++)
            {
                for(int j = 1; j < board.GetLength(1); j++)
                {
                    if (board[i, j] != '_')
                    {
                        if (board[i, j] != board[i, j - 1]) cnt = 0;
                        else cnt++;
                        if (cnt == 4)
                        {
                            Console.WriteLine("Winner1");
                            break;
                        }
                    }
                }
            }
          

            for (int i = 1; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] != '_')
                    {
                        if (board[i, j] != board[i - 1, j]) cnt = 0;
                        else cnt++;
                        if (cnt == 4)
                        {
                            Console.WriteLine("Winner2");
                            break;
                        }
                    }
                }
            }

            for (int i = 1; i < board.GetLength(0); i++)
            {
                for (int j = 1; j < board.GetLength(1); j++)
                {
                    if (board[i, j] != '_')
                    {
                        if (board[i, j] != board[i - 1, j - 1]) cnt = 0;
                        else cnt++;
                        if (cnt == 4)
                        {
                            Console.WriteLine("Winner3");
                            break;
                        }
                    }
                }
            }

            for (int i = 0; i < board.GetLength(0)-1; i++)
            {
                for (int j = board.GetLength(1)-2; j > 0; j--)
                {
                    if (board[i, j] != '_')
                    {
                        if (board[i, j] != board[i + 1, j - 1]) cnt = 0;
                        else cnt++;
                        if (cnt == 4)
                        {
                            Console.WriteLine("Winner4");
                            break;
                        }
                    }
                }
            }



            /*
            for (int y = 0; y < 15; y++)
            {
                for (int x = 0; x < 15; x++)
                {
                    if (arr[y, x] != '_') Console.WriteLine($"\n x = {x+1}, y = {y + 1}");
                }
            }
            */
            Console.ReadKey();

            
        }
    }
}
