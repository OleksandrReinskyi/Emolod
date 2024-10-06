using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1
{
   

    public partial class Converter : Form
    {
        public Converter()
        {
            InitializeComponent();
        }
        private void AllCheckboxes_CheckChanged(Object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                Helper.RBChecked = (RadioButton)sender;
            }
        }

        private void ConvertButton_Click(object sender, EventArgs e)
        {
            try
            {
                if(Helper.RBChecked == null)
                {
                    throw new Exception("Please choose a dimension!");
                }
                double value = Convert.ToDouble(this.ValueTextBox.Text);
                string dimension = Helper.RBChecked.Text;
                double convertedValue = Helper.Convert(value, dimension);

                MessageBox.Show(Convert.ToString(convertedValue), "Value");
            }
            catch(Exception ex)
            {

                MessageBox.Show("Error: "+ex.Message,"Error");
            }


        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            this.ValueTextBox.Text = "";
            foreach(Control item in this.Controls)
            {
                if(item is RadioButton)
                {
                    ((RadioButton)item).Checked = false;
                }
            }
            Helper.RBChecked = null;

        }
    }


    static class Helper
    {
        public static RadioButton RBChecked = null;
        public const double milesMultiplier = 1.6;
        public static double Convert(double value, string toDimension)
        {
            switch (toDimension.ToUpper())
            {
                case "MILES":
                    return value / milesMultiplier;
                case "KILOMETERS":
                    return value * milesMultiplier;
                default:
                    throw new Exception("Invalid dimension passed!");
            }
        }
    }
}
