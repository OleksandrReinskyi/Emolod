namespace _1
{
    partial class Converter
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
            this.ClearButton = new System.Windows.Forms.Button();
            this.ConvertButton = new System.Windows.Forms.Button();
            this.MilesButton = new System.Windows.Forms.RadioButton();
            this.KilometersButton = new System.Windows.Forms.RadioButton();
            this.ValueTextBox = new System.Windows.Forms.TextBox();
            this.formLabel = new System.Windows.Forms.Label();
            this.TextBoxPrompt = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ClearButton
            // 
            this.ClearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ClearButton.ForeColor = System.Drawing.Color.Red;
            this.ClearButton.Location = new System.Drawing.Point(380, 241);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(75, 34);
            this.ClearButton.TabIndex = 0;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // ConvertButton
            // 
            this.ConvertButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ConvertButton.Location = new System.Drawing.Point(224, 242);
            this.ConvertButton.Name = "ConvertButton";
            this.ConvertButton.Size = new System.Drawing.Size(85, 33);
            this.ConvertButton.TabIndex = 1;
            this.ConvertButton.Text = "Convert";
            this.ConvertButton.UseVisualStyleBackColor = true;
            this.ConvertButton.Click += new System.EventHandler(this.ConvertButton_Click);
            // 
            // MilesButton
            // 
            this.MilesButton.AutoSize = true;
            this.MilesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MilesButton.Location = new System.Drawing.Point(311, 164);
            this.MilesButton.Name = "MilesButton";
            this.MilesButton.Size = new System.Drawing.Size(63, 24);
            this.MilesButton.TabIndex = 2;
            this.MilesButton.TabStop = true;
            this.MilesButton.Text = "Miles";
            this.MilesButton.UseVisualStyleBackColor = true;
            this.MilesButton.CheckedChanged += new System.EventHandler(this.AllCheckboxes_CheckChanged);
            // 
            // KilometersButton
            // 
            this.KilometersButton.AutoSize = true;
            this.KilometersButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.KilometersButton.Location = new System.Drawing.Point(311, 194);
            this.KilometersButton.Name = "KilometersButton";
            this.KilometersButton.Size = new System.Drawing.Size(101, 24);
            this.KilometersButton.TabIndex = 3;
            this.KilometersButton.TabStop = true;
            this.KilometersButton.Text = "Kilometers";
            this.KilometersButton.UseVisualStyleBackColor = true;
            this.KilometersButton.CheckedChanged += new System.EventHandler(this.AllCheckboxes_CheckChanged);
            // 
            // ValueTextBox
            // 
            this.ValueTextBox.Location = new System.Drawing.Point(284, 85);
            this.ValueTextBox.Name = "ValueTextBox";
            this.ValueTextBox.Size = new System.Drawing.Size(195, 20);
            this.ValueTextBox.TabIndex = 4;
            // 
            // formLabel
            // 
            this.formLabel.AutoSize = true;
            this.formLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.formLabel.Location = new System.Drawing.Point(161, 21);
            this.formLabel.Name = "formLabel";
            this.formLabel.Size = new System.Drawing.Size(360, 31);
            this.formLabel.TabIndex = 5;
            this.formLabel.Text = "Miles/Kilometers converter";
            // 
            // TextBoxPrompt
            // 
            this.TextBoxPrompt.AutoSize = true;
            this.TextBoxPrompt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextBoxPrompt.Location = new System.Drawing.Point(132, 81);
            this.TextBoxPrompt.Name = "TextBoxPrompt";
            this.TextBoxPrompt.Size = new System.Drawing.Size(146, 24);
            this.TextBoxPrompt.TabIndex = 6;
            this.TextBoxPrompt.Text = "Insert a value: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(232, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "Choose the dimension: ";
            // 
            // Converter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TextBoxPrompt);
            this.Controls.Add(this.formLabel);
            this.Controls.Add(this.ValueTextBox);
            this.Controls.Add(this.KilometersButton);
            this.Controls.Add(this.MilesButton);
            this.Controls.Add(this.ConvertButton);
            this.Controls.Add(this.ClearButton);
            this.Name = "Converter";
            this.Text = "Miles/Kilometers converter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button ConvertButton;
        private System.Windows.Forms.RadioButton MilesButton;
        private System.Windows.Forms.RadioButton KilometersButton;
        private System.Windows.Forms.TextBox ValueTextBox;
        private System.Windows.Forms.Label formLabel;
        private System.Windows.Forms.Label TextBoxPrompt;
        private System.Windows.Forms.Label label1;
    }
}

