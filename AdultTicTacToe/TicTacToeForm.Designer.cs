namespace AdultTicTacToe
{
    partial class TicTacToeForm
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
            this.labelScorePlayerX = new System.Windows.Forms.Label();
            this.labelScorePlayerO = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelScorePlayerX
            // 
            this.labelScorePlayerX.AutoSize = true;
            this.labelScorePlayerX.Location = new System.Drawing.Point(555, 9);
            this.labelScorePlayerX.Name = "labelScorePlayerX";
            this.labelScorePlayerX.Size = new System.Drawing.Size(109, 16);
            this.labelScorePlayerX.TabIndex = 0;
            this.labelScorePlayerX.Text = "Player X Score: 0";
            // 
            // labelScorePlayerO
            // 
            this.labelScorePlayerO.AutoSize = true;
            this.labelScorePlayerO.Location = new System.Drawing.Point(555, 34);
            this.labelScorePlayerO.Name = "labelScorePlayerO";
            this.labelScorePlayerO.Size = new System.Drawing.Size(111, 16);
            this.labelScorePlayerO.TabIndex = 1;
            this.labelScorePlayerO.Text = "Player O Score: 0";
            // 
            // TicTacToeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelScorePlayerO);
            this.Controls.Add(this.labelScorePlayerX);
            this.Name = "TicTacToeForm";
            this.Text = "TicTacToe";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelScorePlayerX;
        private System.Windows.Forms.Label labelScorePlayerO;
    }
}

