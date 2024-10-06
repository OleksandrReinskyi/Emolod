using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


/*
Game class:
- public Number
- public tries
- public generateNewNumber
- public string checkAnswer (less,more, equal)

Guess func
- If equal 
-- activate play again button 
- Update result and tries 

public void UpdateResultTries 

PlayAgain func
- generateNewNumber
- Clear tries, result, 
- deactivate playAgainButton 
 */

namespace _2
{
    public partial class Game : Form
    {
        private GuessGame GuessGame;
        public Game()
        {
            InitializeComponent();
            this.GuessGame = new GuessGame(1, 100);
        }

        private void GuessButton_Click(object sender, EventArgs e)
        {
            try
            {
                

                int answer = Convert.ToInt16(this.TextBox.Text);
                if(answer>GuessGame.max || answer < GuessGame.min)
                {
                    throw new Exception($"Inserted number is out of bounds ({GuessGame.min};{GuessGame.max})");
                }
                int result = this.GuessGame.CheckAnswer(answer);
                string message = "";
                switch (result) {
                    case -1:
                        message += "Smaller";
                        break;
                    case 0:
                        message += "The Same";
                        this.PlayAgainButton.Enabled = true;
                        this.GuessButton.Enabled = false;
                        break;
                    case 1:
                        message += "Bigger";
                        break;
                }
                this.ResultLabel.Text = "Result: "+message;
                this.TriesLabel.Text = "Tries: " + ++this.GuessGame.tries;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void PlayAgainButton_Click(object sender, EventArgs e)
        {
            this.GuessGame.GenerateNumber();
            this.ResultLabel.Text = "Result: ";
            this.TriesLabel.Text = "Tries: ";
            this.PlayAgainButton.Enabled = false;
            this.GuessButton.Enabled=true;

        }
    }

    class GuessGame
    {
        public int min;
        public int max;


        public int tries = 0;
        private int number;
        private Random random;
        public GuessGame(int min, int max)
        {
            this.min = min;
            this.max = max;
            this.random = new Random();
            GenerateNumber();
        }

        public void GenerateNumber()
        {
            this.number = random.Next(min, max);
            this.tries = 0;
        }
        public int CheckAnswer(int answer)
        {
            if (answer > number)
            {
                return -1;
            }
            if (answer == number)
            {
                return 0;
            }
            if (answer < number)
            {
                return 1;
            }
            throw new Exception("Invalid input!");
        }
    }
}
