using System;
using System.Collections.Generic;
using System.Text;

namespace Gomoku
{
    class Referee
    {
        int cnt;
        char[,] board;

        public Referee(char[,] _board)
        {
            board = _board;
        }

        private void Horizontal(char[,] _array, int _i, int _j)
        {
            while(_array[_i,_j] == _array[_i, _j+1])
            {
                cnt++;
                j++;
                if(cnt == 4)
                {
                    Console.WriteLine("Winner1");
                }
            }
        }

        public void CheckWinner()
        {
            for(int i = 0; i < board.GetLength(0); i++)
            {
                for(int j = 0; j < board.GetLength(1); j++)
                {

                }
            }
        }
    }
}
