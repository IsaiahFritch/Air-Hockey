namespace Air_Hockey
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.player1TextLabel = new System.Windows.Forms.Label();
            this.scoreOneLabel = new System.Windows.Forms.Label();
            this.scoreTwoLabel = new System.Windows.Forms.Label();
            this.player2TextLabel = new System.Windows.Forms.Label();
            this.winLabel = new System.Windows.Forms.Label();
            this.resetButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // player1TextLabel
            // 
            this.player1TextLabel.AutoSize = true;
            this.player1TextLabel.BackColor = System.Drawing.Color.White;
            this.player1TextLabel.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player1TextLabel.Location = new System.Drawing.Point(29, 8);
            this.player1TextLabel.Name = "player1TextLabel";
            this.player1TextLabel.Size = new System.Drawing.Size(98, 21);
            this.player1TextLabel.TabIndex = 0;
            this.player1TextLabel.Text = "Player One:";
            // 
            // scoreOneLabel
            // 
            this.scoreOneLabel.BackColor = System.Drawing.Color.White;
            this.scoreOneLabel.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreOneLabel.Location = new System.Drawing.Point(124, 8);
            this.scoreOneLabel.Name = "scoreOneLabel";
            this.scoreOneLabel.Size = new System.Drawing.Size(23, 21);
            this.scoreOneLabel.TabIndex = 1;
            this.scoreOneLabel.Text = "0";
            // 
            // scoreTwoLabel
            // 
            this.scoreTwoLabel.BackColor = System.Drawing.Color.White;
            this.scoreTwoLabel.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreTwoLabel.Location = new System.Drawing.Point(544, 970);
            this.scoreTwoLabel.Name = "scoreTwoLabel";
            this.scoreTwoLabel.Size = new System.Drawing.Size(23, 21);
            this.scoreTwoLabel.TabIndex = 3;
            this.scoreTwoLabel.Text = "0";
            // 
            // player2TextLabel
            // 
            this.player2TextLabel.AutoSize = true;
            this.player2TextLabel.BackColor = System.Drawing.Color.White;
            this.player2TextLabel.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player2TextLabel.Location = new System.Drawing.Point(449, 970);
            this.player2TextLabel.Name = "player2TextLabel";
            this.player2TextLabel.Size = new System.Drawing.Size(100, 21);
            this.player2TextLabel.TabIndex = 2;
            this.player2TextLabel.Text = "Player Two:";
            // 
            // winLabel
            // 
            this.winLabel.BackColor = System.Drawing.Color.White;
            this.winLabel.Font = new System.Drawing.Font("MV Boli", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.winLabel.Location = new System.Drawing.Point(158, 448);
            this.winLabel.Name = "winLabel";
            this.winLabel.Size = new System.Drawing.Size(282, 100);
            this.winLabel.TabIndex = 4;
            this.winLabel.Text = "Player One Wins";
            this.winLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.winLabel.Visible = false;
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(258, 549);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 5;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Visible = false;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(600, 1000);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.winLabel);
            this.Controls.Add(this.scoreTwoLabel);
            this.Controls.Add(this.player2TextLabel);
            this.Controls.Add(this.scoreOneLabel);
            this.Controls.Add(this.player1TextLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Air Hockey";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label player1TextLabel;
        private System.Windows.Forms.Label scoreOneLabel;
        private System.Windows.Forms.Label scoreTwoLabel;
        private System.Windows.Forms.Label player2TextLabel;
        private System.Windows.Forms.Label winLabel;
        private System.Windows.Forms.Button resetButton;
    }
}

