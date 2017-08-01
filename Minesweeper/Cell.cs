using System.Drawing;

namespace Minesweeper
{
    class Cell
    {
        public int MineCount { get; private set; }

        public bool IsMined { get; set; }

        public bool IsFlagged { get; set; }

        public bool IsOpened { get; set; }

        public bool IsEmpty {
            get { return MineCount == 0; }
        }

        public void IncrementMineCount()
        {
            MineCount++;
        }
    }
}
