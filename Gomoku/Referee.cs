using System;
using System.Collections.Generic;
using System.Text;

namespace Gomoku
{
    class Referee
    {
        //Класс Referee находит первую не пустую позицию - проверяет по 4м направлениям победную комбинацию
        //Метод CheckLine отвечает за поиск победной комбинации

        int cnt;
        char[,] board;
        public int r;
        bool result = false;

        public Referee(char[,] _board)
        {
            board = _board;
            r = _board.GetLength(0);
        }

        private bool CheckLine(char[,] _array, int _i, int _j, char _figure, int dx, int dy)
        {
            bool checkWin = false;
            cnt = 0;
            while (_array[_i, _j] == _figure && _j < board.GetLength(1) && _i < board.GetLength(0) && _j > 0)
            {
                cnt++;
                if (cnt == 5)
                {
                    Console.WriteLine($"Winner {_figure}");
                    checkWin = true;
                    break;
                }
                else if (_i == board.GetLength(0) - 1 || _j == 0) break;
                _i += dy;
                _j += dx;
            }

            return checkWin;
        }

        public bool CheckWinner(char[,] _board)
        {

            for (int i = 0; i < _board.GetLength(0); i++)
            {
                for (int j = 0; j < _board.GetLength(1); j++)
                {
                    if (board[i, j] != '_')
                    {
                        if (CheckLine(_board, i, j, _board[i, j], 1, 0)) break; //горизанталь
                        else
                            if(CheckLine(_board, i, j, _board[i, j], 0, 1)) break; // вертикаль
                        else
                            if(CheckLine(_board, i, j, _board[i, j], 1, 1)) break; //диагональ 135 градусов
                        else
                            if(CheckLine(_board, i, j, _board[i, j], -1, 1)) break; // диагональ 45 градусов
                    }
                    if (cnt == 5)
                    {
                        result = true;
                        break;
                    }
                }
            }

            return result;
        }
    }
}
