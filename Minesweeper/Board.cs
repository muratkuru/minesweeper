using System.Collections.Generic;

namespace Minesweeper
{
    class Board
    {
        public Board(int width, int height, int minesCount)
        {
            MatrixWidth = width;
            MatrixHeight = height;
            MinesCount = minesCount;
            
            SetMatrix();
            SetMines();
            SetCountsOfMines();
        }

        public static int MatrixWidth { get; set; }

        public static int MatrixHeight { get; set; }

        public static int MinesCount { get; set; }

        public Cell[,] Matrix { get; set; }

        private void SetMatrix()
        {
            Matrix = new Cell[MatrixWidth, MatrixHeight];
            for (int i = 0; i < MatrixWidth; i++)
            {
                for (int j = 0; j < MatrixHeight; j++)
                {
                    Matrix[i, j] = new Cell();
                }
            }
        }

        private void SetMines()
        {
            var mines = new List<Point>().GetDifferentRandomPoint(MinesCount, MatrixWidth, MatrixHeight);

            foreach (var item in mines)
            {
                Matrix[item.X, item.Y].IsMined = true;
            }
        }

        private void CountMine(int x, int y)
        {
            if (LimitControl(x, y) && !Matrix[x, y].IsMined)
            {
                Matrix[x, y].IncrementMineCount();
            }
        }

        private void SetCountsOfMines()
        {
            for (int i = 0; i < MatrixWidth; i++)
            {
                for (int j = 0; j < MatrixHeight; j++)
                {
                    if (Matrix[i, j].IsMined)
                    {
                        foreach (var item in Neighbors(i, j))
                            CountMine(item.X, item.Y);
                    }
                }
            }
        }

        public bool LimitControl(int x, int y)
        {
            return (x >= 0 && x < MatrixWidth) && (y >= 0 && y < MatrixHeight);
        }

        public IEnumerable<Point> Neighbors(int x, int y)
        {
            yield return new Point(x - 1, y - 1);
            yield return new Point(x - 1, y);
            yield return new Point(x - 1, y + 1);
            yield return new Point(x, y - 1);
            yield return new Point(x, y + 1);
            yield return new Point(x + 1, y - 1);
            yield return new Point(x + 1, y);
            yield return new Point(x + 1, y + 1);
        }
    }
}
