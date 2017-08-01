using System;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class SettingsForm : Form
    {
        public SettingsForm(MainForm form)
        {
            InitializeComponent();

            MainForm = form;
        }

        private MainForm MainForm { get; set; }

        private void beginnerRB_CheckedChanged(object sender, EventArgs e)
        {
            widthTB.Text = "9";
            heightTB.Text = "9";
            minesTB.Text = "10";
        }

        private void intermediateRB_CheckedChanged(object sender, EventArgs e)
        {
            widthTB.Text = "16";
            heightTB.Text = "16";
            minesTB.Text = "40";
        }

        private void expertRB_CheckedChanged(object sender, EventArgs e)
        {
            widthTB.Text = "30";
            heightTB.Text = "16";
            minesTB.Text = "99";
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            int width = int.Parse(widthTB.Text);
            int height = int.Parse(heightTB.Text);
            int minesCount = int.Parse(minesTB.Text);

            this.MainForm.NewGame(width, height, minesCount);
            Close();
        }
    }
}
