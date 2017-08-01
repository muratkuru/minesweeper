using System;
using System.Collections.Generic;
using System.Drawing;

namespace Minesweeper
{
    public static class Helpers
    {
        public static List<Point> GetDifferentRandomPoint(this List<Point> list, int minesCount, int width, int height)
        {
            List<Point> numbers = new List<Point>();
            Random random = new Random();
            int randomX, randomY;
            bool control;

            for (int i = 0; i < minesCount; i++)
            {
                control = true;
                while (control)
                {
                    randomX = random.Next(width);
                    randomY = random.Next(height);

                    if (numbers.FindIndex(find => find.X == randomX && find.Y == randomY) == -1)
                    {
                        numbers.Add(new Point(randomX, randomY));
                        control = false;
                    }
                }
            }

            return numbers;
        }

        public static bool EqualWith(this Point point, int x, int y)
        {
            return point.X == x && point.Y == y;
        }
    }
}
