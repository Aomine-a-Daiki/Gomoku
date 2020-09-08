using System;
using System.Collections.Generic;
using System.Text;

namespace Gomoku
{
    class GameBoard
    {
        int size;
        public char[,] Board;
        public GameBoard(int _size)
        {
            size = _size;         
        }

        public char[,] CreateBoard()
        {
            Board = new char[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Board[i, j] = '_';
                }
            }

            return Board;
        }


        public void DrawGameBoard(char[,] Board)
        {
            for (int i = 0; i < Board.GetLength(0); i++, Console.WriteLine())
                for (int j = 0; j < Board.GetLength(1); j++)
                    Console.Write("{0,3}", Board[i, j]);
        }
    }
}
