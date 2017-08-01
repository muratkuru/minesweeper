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
            SetEmojiButton();
            SetFlagCountLabel();
        }

        private Board Board { get; set; }

        public List<Button> Buttons { get; set; }

        public Button EmojiButton { get; set; }

        public Label FlagCountLabel { get; set; }

        public Size GetFormSize()
        {
            int width = (Board.MatrixWidth + 1) * Constants.BUTTON_SIZE + 10;
            int height = (Board.MatrixHeight + 1) * Constants.BUTTON_SIZE + 70;
            return new Size(width, height);
        }

        private void SetFlagCountLabel()
        {
            int flagCountLeft = GetFormSize().Width - 100;

            FlagCountLabel = new Label
            {
                Name = "flagCountLbl",
                Top = 10,
                Left = flagCountLeft,
                Text = "0",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Tahoma", 12, FontStyle.Bold),
                Image = Properties.Resources.Flag,
                ImageAlign = ContentAlignment.MiddleLeft
            };
        }

        private void SetEmojiButton()
        {
            int emojiLeft = GetFormSize().Width / 2 - Constants.BUTTON_SIZE;

            EmojiButton = new Button
            {
                Name = "emojiBtn",
                Width = Constants.BUTTON_SIZE,
                Height = Constants.BUTTON_SIZE,
                Left = emojiLeft,
                Top = 7,
                BackgroundImage = Properties.Resources.Smile,
                BackgroundImageLayout = ImageLayout.Stretch
            };
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

            if (e.Button == MouseButtons.Left)
                OpenCell(point.X, point.Y);
            if (e.Button == MouseButtons.Right)
                SetFlag(point.X, point.Y);

            FinishControl();
        }

        private void OpenCell(int x, int y)
        {
            var button = Buttons.Find(find => ((Point)find.Tag).EqualWith(x, y));
            var cell = Board.Matrix[x, y];

            if (!cell.IsMined)
            {
                if (cell.IsEmpty && !cell.IsOpened && !cell.IsFlagged)
                {
                    button.Enabled = false;
                    cell.IsOpened = true;

                    foreach (var item in Board.Neighbors(x, y))
                        if (Board.LimitControl(item.X, item.Y))
                            OpenCell(item.X, item.Y);
                }
                else
                {
                    if (!cell.IsFlagged)
                    {
                        button.Text = cell.IsEmpty ? string.Empty : cell.MineCount.ToString();
                        button.ForeColor = Constants.Colors[cell.MineCount];
                        cell.IsOpened = true;
                    }
                }
            }
            else
                FailureGame();
        }

        private void SetFlag(int x, int y)
        {
            var button = Buttons.Find(find => ((Point)find.Tag).EqualWith(x, y));
            var cell = Board.Matrix[x, y];

            if (!cell.IsOpened)
            {
                if (cell.IsFlagged)
                {
                    button.Image = null;
                    cell.IsFlagged = false;
                    Board.FlagCount--;
                }
                else
                {
                    button.Image = Properties.Resources.Flag;
                    button.ImageAlign = ContentAlignment.MiddleCenter;
                    cell.IsFlagged = true;
                    Board.FlagCount++;
                }
            }
            FlagCountLabel.Text = Board.FlagCount.ToString();
        }

        private void FailureGame()
        {
            EmojiButton.BackgroundImage = Properties.Resources.Worried;
            foreach (var item in Buttons)
            {
                var point = (Point)item.Tag;
                var cell = Board.Matrix[point.X, point.Y];
                item.Text = cell.IsEmpty || cell.IsMined || cell.IsFlagged ? string.Empty : cell.MineCount.ToString();
                item.Image = cell.IsFlagged ? Properties.Resources.Flag : (cell.IsMined ? Properties.Resources.Poop : null);
                item.ImageAlign = ContentAlignment.MiddleCenter;
                item.ForeColor = Constants.Colors[cell.MineCount];
                item.MouseUp -= Button_Click;
            }
        }

        private void SuccessfulGame()
        {
            foreach (var item in Buttons)
                item.MouseUp -= Button_Click;

            EmojiButton.BackgroundImage = Properties.Resources.Cool;
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
                    var cell = Board.Matrix[i, j];
                    if (cell.IsFlagged || cell.IsOpened)
                        count++;
                }
            }

            if(count == totalCell)
                SuccessfulGame();
        }
    }
}
