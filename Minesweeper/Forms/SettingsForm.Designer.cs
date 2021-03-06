﻿namespace Minesweeper
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.beginnerRB = new System.Windows.Forms.RadioButton();
            this.intermediateRB = new System.Windows.Forms.RadioButton();
            this.expertRB = new System.Windows.Forms.RadioButton();
            this.widthLabel = new System.Windows.Forms.Label();
            this.widthTB = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.heightLabel = new System.Windows.Forms.Label();
            this.heightTB = new System.Windows.Forms.TextBox();
            this.minesLabel = new System.Windows.Forms.Label();
            this.minesTB = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // beginnerRB
            // 
            this.beginnerRB.AutoSize = true;
            this.beginnerRB.Checked = true;
            this.beginnerRB.Font = new System.Drawing.Font("Verdana", 10F);
            this.beginnerRB.Location = new System.Drawing.Point(12, 12);
            this.beginnerRB.Name = "beginnerRB";
            this.beginnerRB.Size = new System.Drawing.Size(88, 21);
            this.beginnerRB.TabIndex = 0;
            this.beginnerRB.TabStop = true;
            this.beginnerRB.Text = "Beginner";
            this.beginnerRB.UseVisualStyleBackColor = true;
            this.beginnerRB.CheckedChanged += new System.EventHandler(this.beginnerRB_CheckedChanged);
            // 
            // intermediateRB
            // 
            this.intermediateRB.AutoSize = true;
            this.intermediateRB.Font = new System.Drawing.Font("Verdana", 10F);
            this.intermediateRB.Location = new System.Drawing.Point(12, 47);
            this.intermediateRB.Name = "intermediateRB";
            this.intermediateRB.Size = new System.Drawing.Size(115, 21);
            this.intermediateRB.TabIndex = 1;
            this.intermediateRB.Text = "Intermediate";
            this.intermediateRB.UseVisualStyleBackColor = true;
            this.intermediateRB.CheckedChanged += new System.EventHandler(this.intermediateRB_CheckedChanged);
            // 
            // expertRB
            // 
            this.expertRB.AutoSize = true;
            this.expertRB.Font = new System.Drawing.Font("Verdana", 10F);
            this.expertRB.Location = new System.Drawing.Point(12, 82);
            this.expertRB.Name = "expertRB";
            this.expertRB.Size = new System.Drawing.Size(73, 21);
            this.expertRB.TabIndex = 2;
            this.expertRB.Text = "Expert";
            this.expertRB.UseVisualStyleBackColor = true;
            this.expertRB.CheckedChanged += new System.EventHandler(this.expertRB_CheckedChanged);
            // 
            // widthLabel
            // 
            this.widthLabel.AutoSize = true;
            this.widthLabel.Font = new System.Drawing.Font("Verdana", 10F);
            this.widthLabel.Location = new System.Drawing.Point(8, 127);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(50, 17);
            this.widthLabel.TabIndex = 3;
            this.widthLabel.Text = "Width";
            // 
            // widthTB
            // 
            this.widthTB.Font = new System.Drawing.Font("Verdana", 10F);
            this.widthTB.Location = new System.Drawing.Point(69, 124);
            this.widthTB.Name = "widthTB";
            this.widthTB.Size = new System.Drawing.Size(51, 24);
            this.widthTB.TabIndex = 4;
            this.widthTB.Text = "9";
            // 
            // okButton
            // 
            this.okButton.Font = new System.Drawing.Font("Verdana", 10F);
            this.okButton.Location = new System.Drawing.Point(126, 124);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(96, 26);
            this.okButton.TabIndex = 5;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // heightLabel
            // 
            this.heightLabel.AutoSize = true;
            this.heightLabel.Font = new System.Drawing.Font("Verdana", 10F);
            this.heightLabel.Location = new System.Drawing.Point(8, 159);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(53, 17);
            this.heightLabel.TabIndex = 6;
            this.heightLabel.Text = "Height";
            // 
            // heightTB
            // 
            this.heightTB.Font = new System.Drawing.Font("Verdana", 10F);
            this.heightTB.Location = new System.Drawing.Point(69, 156);
            this.heightTB.Name = "heightTB";
            this.heightTB.Size = new System.Drawing.Size(51, 24);
            this.heightTB.TabIndex = 7;
            this.heightTB.Text = "9";
            // 
            // minesLabel
            // 
            this.minesLabel.AutoSize = true;
            this.minesLabel.Font = new System.Drawing.Font("Verdana", 10F);
            this.minesLabel.Location = new System.Drawing.Point(8, 191);
            this.minesLabel.Name = "minesLabel";
            this.minesLabel.Size = new System.Drawing.Size(47, 17);
            this.minesLabel.TabIndex = 8;
            this.minesLabel.Text = "Mines";
            // 
            // minesTB
            // 
            this.minesTB.Font = new System.Drawing.Font("Verdana", 10F);
            this.minesTB.Location = new System.Drawing.Point(69, 188);
            this.minesTB.Name = "minesTB";
            this.minesTB.Size = new System.Drawing.Size(51, 24);
            this.minesTB.TabIndex = 9;
            this.minesTB.Text = "10";
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("Verdana", 10F);
            this.cancelButton.Location = new System.Drawing.Point(126, 156);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(96, 26);
            this.cancelButton.TabIndex = 10;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(233, 222);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.minesTB);
            this.Controls.Add(this.minesLabel);
            this.Controls.Add(this.heightTB);
            this.Controls.Add(this.heightLabel);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.widthTB);
            this.Controls.Add(this.widthLabel);
            this.Controls.Add(this.expertRB);
            this.Controls.Add(this.intermediateRB);
            this.Controls.Add(this.beginnerRB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton beginnerRB;
        private System.Windows.Forms.RadioButton intermediateRB;
        private System.Windows.Forms.RadioButton expertRB;
        private System.Windows.Forms.Label widthLabel;
        private System.Windows.Forms.TextBox widthTB;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label heightLabel;
        private System.Windows.Forms.TextBox heightTB;
        private System.Windows.Forms.Label minesLabel;
        private System.Windows.Forms.TextBox minesTB;
        private System.Windows.Forms.Button cancelButton;
    }
}