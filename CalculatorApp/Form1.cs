using System;
using System.Windows.Forms;

namespace CalculatorApp
{
    public partial class Form1 : Form
    {
        private double result = 0;
        private string operation = "";
        private bool isOperationPerformed = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            if ((textBox_Result.Text == "0") || (isOperationPerformed))
                textBox_Result.Clear();

            isOperationPerformed = false;
            Button button = (Button)sender;
            textBox_Result.Text += button.Text; // Append the digit to the result
        }

        private void operator_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            operation = button.Text; // Store the operation
            result = double.Parse(textBox_Result.Text); // Store the current result
            isOperationPerformed = true; // Set flag to indicate an operation has been performed
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            switch (operation)
            {
                case "+":
                    textBox_Result.Text = (result + double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "-":
                    textBox_Result.Text = (result - double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "*":
                    textBox_Result.Text = (result * double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "/":
                    if (double.Parse(textBox_Result.Text) != 0) // Prevent division by zero
                    {
                        textBox_Result.Text = (result / double.Parse(textBox_Result.Text)).ToString();
                    }
                    else
                    {
                        MessageBox.Show("Cannot divide by zero");
                        textBox_Result.Text = "0"; // Reset the display
                    }
                    break;
                default:
                    break;
            }
            result = double.Parse(textBox_Result.Text); // Update result
            operation = ""; // Reset operation
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBox_Result.Text = "0"; // Reset display
            result = 0; // Reset stored result
            operation = ""; // Reset operation
        }
    }
}
