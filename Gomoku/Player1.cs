using System;
using System.Collections.Generic;
using System.Linq;
using MoreLinq;
using System.Text;
using MoreLinq.Extensions;

namespace Gomoku
{
    class Player1
    {
        public char sym {get; }
        List<Point> Points = new List<Point>();
        int range = 5;
        int size;
        Random rand = new Random();
        public Player1(char _sym) 
        {
            sym = _sym;
        }

        private Point CheckLine(char[,] _board, int y, int x, int dx, int dy, char curSym)
        {
            Point point = new Point();
            point.x = x;
            point.y = y;
            point.divider = 1;
            point.sym = curSym;

            if (y + range > _board.GetLength(0) - 1) size = (_board.GetLength(0) - 1); else size = y + range;
            if (x + range > _board.GetLength(0) - 1) size = (_board.GetLength(0) - 1); else size = x + range;

            while(y < size && x < size && x >= 0)
            {
                if(_board[y, x] == curSym)
                {
                    point.capacity++;
                }
                else
                    if (_board[y, x] != curSym &&  _board[y, x] != '_')
                    {
                        point.capacity--;
                    }
                else
                    if(_board[y, x] == '_')
                    {
                    point.divider++;
                    }
                y += dy;
                x += dx;
            }
            point.weight = ((double) point.capacity / point.divider);
            return point;
        }

        public Figure Move(char[,] _board)
        {
            Point bestPoint = new Point();
            Figure result = new Figure();

            Points.Clear();

            for (int i = 0; i < _board.GetLength(0); i++)
            {
                for (int j = 0; j < _board.GetLength(1); j++)
                {
                    if (_board[i, j] == '_')
                    {
                        Points.Add(CheckLine(_board, i, j, 0, 1, sym));
                        Points.Add(CheckLine(_board, i, j, 1, 0, sym));
                        Points.Add(CheckLine(_board, i, j, 1, 1, sym));
                        Points.Add(CheckLine(_board, i, j, -1, 1, sym));
                    }
                }
            }

            Point pointMin = Points.OrderBy(p => p.weight).First();
            Point pointMax = Points.OrderBy(p => p.weight).Last();
                                 

            if (pointMin.weight == 0.0 && pointMax.weight == 0.0)
            {
                result.y = _board.GetLength(0) / 2;
                result.x = _board.GetLength(1) / 2;
                result.sym = sym;
            }
            else if (Math.Abs(pointMin.weight) < Math.Abs(pointMax.weight))
            {
                result.y = pointMax.y;
                result.x = pointMax.x;
                result.sym = sym;
            }
            else
            { 
                result.y = pointMin.y;
                result.x = pointMin.x;
                result.sym = sym;
            }

            return result;
        }
    }
}
