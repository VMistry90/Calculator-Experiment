using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        Double result = 0;
        String Operater = "";
        bool isOperationPerformed = false;
        bool equalsRepeat = false;
        bool equalOnceUsed = false;
        String valueLabel = "";
        Double rightNum = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            //When number button pressed, check if equal button was pressed
            //If true then clear all values.
            if (equalOnceUsed == true)
            {
                txtResult.Text = "0";
                lblOperation.Text = "";
                result = 0;
                equalOnceUsed = false;

            }

            //On number press, check if textbox text equals to zero and clear all values.
            if ((txtResult.Text == "0") || isOperationPerformed == true) 
            {
                txtResult.Clear();
                isOperationPerformed = false;
                equalsRepeat = false;
                
            }

            //Set operation performed to false when number button is pressed 
            //isOperationPerformed = false;

            //On number press, button pressed is "." then add decimal to text.
            if (button.Text == ".")
            {
                txtResult.Text = txtResult.Text + button.Text;
            }

            
           
            //Check if text contains decimal
            if (button.Text == ".")
            {
                if (!txtResult.Text.Contains("."))
                {
                    txtResult.Text = txtResult.Text + button.Text;
                }
            }
            else
            {
                //check text equals zero, else txtresult.text added to button.text.
                if (txtResult.Text == "0")
                {
                    txtResult.Text = /*txtResult.Text +*/ button.Text;
                }
                else
                {
                    txtResult.Text = txtResult.Text + button.Text;
                }
                rightNum = Double.Parse(button.Text);
            }
        }

        private void operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            //check if result is not equal to zero. 
            if (result != 0)
            {
                equalsRepeat = false;
                Operater = button.Text;
                result = Double.Parse(txtResult.Text);
                valueLabel = result + Operater;
                lblOperation.Text = valueLabel;
            }
            else
            {
                //if operation performed is false then add opertor to existing number
                if (isOperationPerformed == false)
                {
                    Operater = button.Text;
                    result = Double.Parse(txtResult.Text);
                    valueLabel = result + Operater;
                    lblOperation.Text = valueLabel;
                }
                else
                {
                    //if operation performed is true then add the operator and get number on both sides of it.
                    Operater = button.Text;
                    result = Double.Parse(txtResult.Text);
                    valueLabel = result + Operater;

                    result = Double.Parse(valueLabel + rightNum);
                    lblOperation.Text = valueLabel + result;
                }

            }
            
            //Set operation performed to true after all checks
            isOperationPerformed = true;
        }

        private void BtnClearEntry_Click(object sender, EventArgs e)
        {
            //Clear just the number entered into textbox
            txtResult.Text = "0";
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            //Clear all values and restart
            result = 0;
            Operater = "";
            isOperationPerformed = false;
            equalsRepeat = false;
            equalOnceUsed = false;
            valueLabel = "";
            rightNum = 0;
            txtResult.Text = "0";
            lblOperation.Text = "";

        }
       
        private void BtnEquals_Click(object sender, EventArgs e)
        {
            //Check if equal button is pressed once or multiple times without any new number press or operator press.
            if (equalsRepeat == false)
            {
                switch (Operater)
                {
                    case "+":
                        txtResult.Text = (result + Double.Parse(txtResult.Text)).ToString();
                        result = Double.Parse(txtResult.Text);
                        lblOperation.Text = valueLabel + rightNum;
                        break;
                    case "-":
                        txtResult.Text = (result - Double.Parse(txtResult.Text)).ToString();
                        lblOperation.Text = valueLabel + rightNum;
                        break;
                    case "x":
                        txtResult.Text = (result * Double.Parse(txtResult.Text)).ToString();
                        lblOperation.Text = valueLabel + rightNum;
                        break;
                    case "/":
                        txtResult.Text = (result / Double.Parse(txtResult.Text)).ToString();
                        lblOperation.Text = valueLabel + rightNum;
                        break;
                    default:
                        break;
                }

                equalOnceUsed = true;
                equalsRepeat = true;
            }
            else
            {
                //if equal button press repeated, use number on right of operator and perform same operation.
                switch (Operater)
                {
                    case "+":
                        lblOperation.Text = txtResult.Text + "+" + rightNum.ToString();
                        result = Double.Parse(rightNum.ToString());
                        txtResult.Text = (Double.Parse(txtResult.Text) + result).ToString();
                      
                        //txtResult.AppendText(System.Environment.NewLine + valueLabel + rightNum);
                        break;
                    case "-":
                        lblOperation.Text = txtResult.Text + "-" + rightNum.ToString();
                        result = Double.Parse(rightNum.ToString());
                        txtResult.Text = (Double.Parse(txtResult.Text) - result).ToString();
                        break;
                    case "x":
                        lblOperation.Text = txtResult.Text + "x" + rightNum.ToString();
                        result = Double.Parse(rightNum.ToString());
                        txtResult.Text = (Double.Parse(txtResult.Text) * result).ToString();
                        break;
                    case "/":
                        lblOperation.Text = txtResult.Text + "/" + rightNum.ToString();
                        result = Double.Parse(rightNum.ToString());
                        txtResult.Text = (Double.Parse(txtResult.Text) / result).ToString();
                        break;
                    default:
                        break;
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Clear all values when form closed
            result = 0;
            Operater = "";
            isOperationPerformed = false;
            equalsRepeat = false;
            equalOnceUsed = false;
            valueLabel = "";
            rightNum = 0;
            txtResult.Text = "0";
            lblOperation.Text = "";
        }

    }
}