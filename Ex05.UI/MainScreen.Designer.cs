namespace Ex05.UI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;

    public partial class MainScreen
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonBoardSize = new System.Windows.Forms.Button();
            this.buttonPlayWithComputer = new System.Windows.Forms.Button();
            this.buttonPlayWithFriend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonBoardSize
            // 
            this.buttonBoardSize.Location = new System.Drawing.Point(35, 31);
            this.buttonBoardSize.Name = "buttonBoardSize";
            this.buttonBoardSize.Size = new System.Drawing.Size(376, 29);
            this.buttonBoardSize.TabIndex = 0;
            this.buttonBoardSize.Text = "Board Size: 6x6 (click to increase)";
            this.buttonBoardSize.UseVisualStyleBackColor = true;
            this.buttonBoardSize.Click += new System.EventHandler(this.buttonBoardSize_Click);
            // 
            // buttonPlayWithComputer
            // 
            this.buttonPlayWithComputer.Location = new System.Drawing.Point(35, 82);
            this.buttonPlayWithComputer.Name = "buttonPlayWithComputer";
            this.buttonPlayWithComputer.Size = new System.Drawing.Size(185, 29);
            this.buttonPlayWithComputer.TabIndex = 1;
            this.buttonPlayWithComputer.Text = "Play against computer";
            this.buttonPlayWithComputer.UseVisualStyleBackColor = true;
            this.buttonPlayWithComputer.Click += new System.EventHandler(this.buttonPlayWithComputer_Click);
            // 
            // buttonPlayWithFriend
            // 
            this.buttonPlayWithFriend.Location = new System.Drawing.Point(226, 82);
            this.buttonPlayWithFriend.Name = "buttonPlayWithFriend";
            this.buttonPlayWithFriend.Size = new System.Drawing.Size(185, 29);
            this.buttonPlayWithFriend.TabIndex = 2;
            this.buttonPlayWithFriend.Text = "Play against your friend";
            this.buttonPlayWithFriend.UseVisualStyleBackColor = true;
            this.buttonPlayWithFriend.Click += new System.EventHandler(this.buttonPlayWithFriend_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 135);
            this.Controls.Add(this.buttonPlayWithFriend);
            this.Controls.Add(this.buttonPlayWithComputer);
            this.Controls.Add(this.buttonBoardSize);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Othello - Game Settings";
            this.ResumeLayout(false);

        }

        #endregion

        private Button buttonBoardSize;
        private Button buttonPlayWithComputer;
        private Button buttonPlayWithFriend;
    }
}