namespace _2
{
    partial class Game
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
            this.TextBox = new System.Windows.Forms.TextBox();
            this.ResultLabel = new System.Windows.Forms.Label();
            this.FormName = new System.Windows.Forms.Label();
            this.GuessButton = new System.Windows.Forms.Button();
            this.TriesLabel = new System.Windows.Forms.Label();
            this.PlayAgainButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TextBox
            // 
            this.TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextBox.Location = new System.Drawing.Point(147, 157);
            this.TextBox.Name = "TextBox";
            this.TextBox.Size = new System.Drawing.Size(150, 26);
            this.TextBox.TabIndex = 0;
            // 
            // ResultLabel
            // 
            this.ResultLabel.AutoSize = true;
            this.ResultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ResultLabel.Location = new System.Drawing.Point(188, 63);
            this.ResultLabel.Name = "ResultLabel";
            this.ResultLabel.Size = new System.Drawing.Size(80, 24);
            this.ResultLabel.TabIndex = 1;
            this.ResultLabel.Text = "Result: ";
            // 
            // FormName
            // 
            this.FormName.AutoSize = true;
            this.FormName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormName.Location = new System.Drawing.Point(99, 24);
            this.FormName.Name = "FormName";
            this.FormName.Size = new System.Drawing.Size(268, 25);
            this.FormName.TabIndex = 2;
            this.FormName.Text = "Guess the number game";
            // 
            // GuessButton
            // 
            this.GuessButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.GuessButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GuessButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.GuessButton.Location = new System.Drawing.Point(183, 199);
            this.GuessButton.Name = "GuessButton";
            this.GuessButton.Size = new System.Drawing.Size(75, 33);
            this.GuessButton.TabIndex = 3;
            this.GuessButton.Text = "Guess";
            this.GuessButton.UseVisualStyleBackColor = false;
            this.GuessButton.Click += new System.EventHandler(this.GuessButton_Click);
            // 
            // TriesLabel
            // 
            this.TriesLabel.AutoSize = true;
            this.TriesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TriesLabel.Location = new System.Drawing.Point(188, 106);
            this.TriesLabel.Name = "TriesLabel";
            this.TriesLabel.Size = new System.Drawing.Size(69, 24);
            this.TriesLabel.TabIndex = 4;
            this.TriesLabel.Text = "Tries: ";
            // 
            // PlayAgainButton
            // 
            this.PlayAgainButton.Enabled = false;
            this.PlayAgainButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PlayAgainButton.Location = new System.Drawing.Point(156, 264);
            this.PlayAgainButton.Name = "PlayAgainButton";
            this.PlayAgainButton.Size = new System.Drawing.Size(131, 35);
            this.PlayAgainButton.TabIndex = 5;
            this.PlayAgainButton.Text = "Play Again";
            this.PlayAgainButton.UseVisualStyleBackColor = true;
            this.PlayAgainButton.Click += new System.EventHandler(this.PlayAgainButton_Click);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 450);
            this.Controls.Add(this.PlayAgainButton);
            this.Controls.Add(this.TriesLabel);
            this.Controls.Add(this.GuessButton);
            this.Controls.Add(this.FormName);
            this.Controls.Add(this.ResultLabel);
            this.Controls.Add(this.TextBox);
            this.Name = "Game";
            this.Text = "Guess the number game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBox;
        private System.Windows.Forms.Label ResultLabel;
        private System.Windows.Forms.Label FormName;
        private System.Windows.Forms.Button GuessButton;
        private System.Windows.Forms.Label TriesLabel;
        private System.Windows.Forms.Button PlayAgainButton;
    }
}

