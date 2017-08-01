using System;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            NewGame(9, 9, 10);
        }

        private Game Game { get; set; }

        public void NewGame(int width, int height, int minesCount)
        {
            Game = new Game(width, height, minesCount);
            Size = Game.GetFormSize();
            cellPanel.Controls.Clear();
            Controls.RemoveByKey("emojiBtn");
            Controls.RemoveByKey("flagCountLbl");

            var buttons = Game.Buttons;
            foreach (var item in buttons)
                cellPanel.Controls.Add(item);

            Controls.Add(Game.EmojiButton);
            Controls.Add(Game.FlagCountLabel);
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame(Board.MatrixWidth, Board.MatrixHeight, Board.MinesCount);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm form = new SettingsForm(this);
            form.ShowDialog();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
