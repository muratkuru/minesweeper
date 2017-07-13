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

        public Color GetColor()
        {
            Color[] colors = { Color.Black, Color.Blue, Color.Orange, Color.Olive, Color.Orchid, Color.DarkGray, Color.Purple, Color.Purple, Color.LightCyan, Color.Yellow };
            if (IsFlagged && IsMined) return Color.DarkGreen; // if the flag in true place
            if (IsFlagged && !IsMined || IsMined) return Color.Red; // if the flag is in the wrong place or the cell just mined
            return colors[MineCount]; // else get a color for mine count
        }
    }
}
