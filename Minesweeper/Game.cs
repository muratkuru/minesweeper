using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Minesweeper
{
    class Game
    {
        public Game(int width, int height, int mineCount)
        {
            Board = new Board(width, height, mineCount);

            SetButtons(width, height);
        }

        private Board Board { get; set; }

        public List<Button> Buttons { get; set; }

        public Size GetFormSize()
        {
            int width = (Board.MatrixWidth + 1) * Constants.BUTTON_SIZE + 10;
            int height = (Board.MatrixHeight + 1) * Constants.BUTTON_SIZE + 60;
            return new Size(width, height);
        }

        private void SetButtons(int width, int height)
        {
            Buttons = new List<Button>();
            int size = Constants.BUTTON_SIZE;

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    var button = new Button
                    {
                        Name = string.Format("button{0}{1}", i, j),
                        Left = size * i,
                        Top = size * j,
                        Size = new Size(size, size),
                        Font = new Font("Tahoma", 12, FontStyle.Bold),
                        Tag = new Point(i, j)
                    };
                    button.MouseUp += Button_Click;
                    Buttons.Add(button);
                }
            }
        }

        private void Button_Click(object sender, MouseEventArgs e)
        {
            Button clickedButton = sender as Button;
            Point point = (Point)clickedButton.Tag;

            var cell = Board.Matrix[point.X, point.Y];
            if (e.Button == MouseButtons.Left)
                OpenCell(point.X, point.Y);
            else if (e.Button == MouseButtons.Right)
                SetFlag(point.X, point.Y);

            FinishControl();
        }

        private void OpenCell(int x, int y)
        {
            var button = Buttons.Find(find => ((Point)find.Tag).Equals(x, y));
            var matrix = Board.Matrix[x, y];

            if (!matrix.IsMined)
            {
                if (matrix.IsEmpty && !matrix.IsOpened && !matrix.IsFlagged)
                {
                    button.Enabled = false;
                    Board.Matrix[x, y].IsOpened = true;

                    foreach (var item in Board.Neighbors(x, y))
                        if (Board.LimitControl(item.X, item.Y))
                            OpenCell(item.X, item.Y);
                }
                else
                {
                    if (!matrix.IsFlagged)
                    {
                        button.Text = GetValue(x, y);
                        button.ForeColor = Board.Matrix[x, y].GetColor();
                        Board.Matrix[x, y].IsOpened = true;
                    }
                }
            }
            else
                FailureGame();
        }

        private void SetFlag(int x, int y)
        {
            var button = Buttons.Find(find => ((Point)find.Tag).Equals(x, y));
            bool isFlagged = Board.Matrix[x, y].IsFlagged;
            bool isOpened = Board.Matrix[x, y].IsOpened;

            if (!isOpened)
            {
                if (isFlagged)
                {
                    button.Text = "";
                    button.ForeColor = Color.Black;
                    Board.Matrix[x, y].IsFlagged = false;
                }
                else
                {
                    button.Text = "≈";
                    button.ForeColor = Color.DarkGreen;
                    Board.Matrix[x, y].IsFlagged = true;
                }
            }
        }

        private void FailureGame()
        {
            foreach (var item in Buttons)
            {
                var point = (Point)item.Tag;
                item.Text = GetValue(point.X, point.Y);
                item.ForeColor = Board.Matrix[point.X, point.Y].GetColor();
                item.MouseUp -= Button_Click;
            }
            MessageBox.Show(Constants.FAILURE_MESSAGE, Constants.MESSAGE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void SuccessfulGame()
        {
            foreach (var item in Buttons)
                item.MouseUp -= Button_Click;

            MessageBox.Show(Constants.SUCCESSFUL_MESSAGE, Constants.MESSAGE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FinishControl()
        {
            int width = Board.MatrixWidth;
            int height = Board.MatrixHeight;
            int totalCell = width * height;
            int count = 0;
            
            for(int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (Board.Matrix[i, j].IsFlagged || Board.Matrix[i, j].IsOpened)
                        count++;
                }
            }

            if(count == totalCell)
            {
                SuccessfulGame();
            }
        }

        private string GetValue(int x, int y)
        {
            string value;
            var matrix = Board.Matrix[x, y];

            if (matrix.IsFlagged)
                value = "≈";
            else if (matrix.IsMined)
                value = "x";
            else if (matrix.IsEmpty)
                value = string.Empty;
            else
                value = matrix.MineCount.ToString();

            return value;
        }
    }
}
