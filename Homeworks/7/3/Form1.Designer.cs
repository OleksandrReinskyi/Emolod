namespace _3
{
    partial class PasswordGenerator
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.UpperCaseCheckBox = new System.Windows.Forms.CheckBox();
            this.NumbersCheckBox = new System.Windows.Forms.CheckBox();
            this.SymbolsCheckBox = new System.Windows.Forms.CheckBox();
            this.LengthTextBox = new System.Windows.Forms.TextBox();
            this.GenerateButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.GeneratedPassword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(179, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Password Generator";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(139, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Length: ";
            // 
            // UpperCaseCheckBox
            // 
            this.UpperCaseCheckBox.AutoSize = true;
            this.UpperCaseCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UpperCaseCheckBox.Location = new System.Drawing.Point(231, 160);
            this.UpperCaseCheckBox.Name = "UpperCaseCheckBox";
            this.UpperCaseCheckBox.Size = new System.Drawing.Size(113, 24);
            this.UpperCaseCheckBox.TabIndex = 2;
            this.UpperCaseCheckBox.Text = "Upper Case";
            this.UpperCaseCheckBox.UseVisualStyleBackColor = true;
            // 
            // NumbersCheckBox
            // 
            this.NumbersCheckBox.AutoSize = true;
            this.NumbersCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NumbersCheckBox.Location = new System.Drawing.Point(231, 125);
            this.NumbersCheckBox.Name = "NumbersCheckBox";
            this.NumbersCheckBox.Size = new System.Drawing.Size(92, 24);
            this.NumbersCheckBox.TabIndex = 3;
            this.NumbersCheckBox.Text = "Numbers";
            this.NumbersCheckBox.UseVisualStyleBackColor = true;
            // 
            // SymbolsCheckBox
            // 
            this.SymbolsCheckBox.AutoSize = true;
            this.SymbolsCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SymbolsCheckBox.Location = new System.Drawing.Point(231, 193);
            this.SymbolsCheckBox.Name = "SymbolsCheckBox";
            this.SymbolsCheckBox.Size = new System.Drawing.Size(92, 24);
            this.SymbolsCheckBox.TabIndex = 4;
            this.SymbolsCheckBox.Text = "Symbols ";
            this.SymbolsCheckBox.UseVisualStyleBackColor = true;
            // 
            // LengthTextBox
            // 
            this.LengthTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LengthTextBox.Location = new System.Drawing.Point(231, 82);
            this.LengthTextBox.Name = "LengthTextBox";
            this.LengthTextBox.Size = new System.Drawing.Size(100, 29);
            this.LengthTextBox.TabIndex = 5;
            // 
            // GenerateButton
            // 
            this.GenerateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GenerateButton.Location = new System.Drawing.Point(160, 276);
            this.GenerateButton.Name = "GenerateButton";
            this.GenerateButton.Size = new System.Drawing.Size(115, 32);
            this.GenerateButton.TabIndex = 6;
            this.GenerateButton.Text = "Generate";
            this.GenerateButton.UseVisualStyleBackColor = true;
            this.GenerateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ClearButton.Location = new System.Drawing.Point(292, 276);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(113, 32);
            this.ClearButton.TabIndex = 7;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // GeneratedPassword
            // 
            this.GeneratedPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GeneratedPassword.Location = new System.Drawing.Point(160, 234);
            this.GeneratedPassword.Name = "GeneratedPassword";
            this.GeneratedPassword.ReadOnly = true;
            this.GeneratedPassword.Size = new System.Drawing.Size(245, 26);
            this.GeneratedPassword.TabIndex = 8;
            this.GeneratedPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PasswordGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 450);
            this.Controls.Add(this.GeneratedPassword);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.GenerateButton);
            this.Controls.Add(this.LengthTextBox);
            this.Controls.Add(this.SymbolsCheckBox);
            this.Controls.Add(this.NumbersCheckBox);
            this.Controls.Add(this.UpperCaseCheckBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PasswordGenerator";
            this.Text = "Password Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox UpperCaseCheckBox;
        private System.Windows.Forms.CheckBox NumbersCheckBox;
        private System.Windows.Forms.CheckBox SymbolsCheckBox;
        private System.Windows.Forms.TextBox LengthTextBox;
        private System.Windows.Forms.Button GenerateButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.TextBox GeneratedPassword;
    }
}

