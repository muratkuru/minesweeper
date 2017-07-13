using System;
using System.Collections.Generic;

namespace Minesweeper
{
    public static class Helpers
    {
        // TODO: This extension method will be refactoring.
        public static List<Point> GetDifferentRandomPoint(this List<Point> list, int minesCount, int width, int height)
        {
            List<Point> numbers = new List<Point>();
            Random random = new Random();
            int randomX, randomY;

            for (int i = 0; i < minesCount; i++)
            {
                while (true)
                {
                    randomX = random.Next(width);
                    randomY = random.Next(height);

                    if (numbers.FindIndex(find => find.X == randomX && find.Y == randomY) == -1)
                    {
                        numbers.Add(new Point(randomX, randomY));
                        break;
                    }
                }
            }

            return numbers;
        }
    }
}
