using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;

/*
class PasswordGenerator
- Length
- empty Constructor
- string lowerCaseChars
- string symbols
- string numbers 
- random 
- public string GeneratePassword
-- Insert everything into one string
-- For loop until the length
--- Generate random char 
--- Append it to str

void Generate
- Set length 
- Set active charsets
- Generate password
- Insert it into the PasswordTextBox

void Clear
- Clear input 
- Clear checkBoxes

 */


namespace _3
{
    public partial class PasswordGenerator : Form
    {
        private Generator Generator;
        public PasswordGenerator()
        {
            InitializeComponent();
            this.Generator = new Generator();
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Generator.length = Convert.ToInt16(this.LengthTextBox.Text);
                string password = this.Generator.generate(this.NumbersCheckBox.Checked, this.UpperCaseCheckBox.Checked, this.SymbolsCheckBox.Checked);
                this.GeneratedPassword.Text = password;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error");
            }

        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            foreach(Control item in this.Controls)
            {
                if(item is CheckBox)
                {
                    ((CheckBox)item).Checked = false;
                }
            }
            this.LengthTextBox.Text = "";
            this.GeneratedPassword.Text = "";
        }
    }
    class Generator
    {
        private string chars = "abcdefghijklmnopqrstuvwxyz";
        private string numbers = "1234567890";
        private string symbols = "!@#$%^&";



        public int length;
        Random random;

        public Generator() { 
            random = new Random();
        }

        public string generate(bool numbers,bool upperCase, bool symbols)
        {
            string characters = chars;
            if (numbers)
            {
                characters += this.numbers;
            }
            if (upperCase)
            {
                characters += this.chars.ToUpper();
            }
            if (symbols)
            {
                characters += this.symbols;
            }

            string password = "";

            for (int i = 0; i < length; i++) {
                password += characters[random.Next(0, characters.Length)];
            }
            return password;
        }

    }
}