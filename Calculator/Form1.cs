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

            if (equalOnceUsed == true || result != 0)
            {
                txtResult.Text = button.Text;
                lblOperation.Text = "";
                result = 0;
                equalOnceUsed = false;

            }

            if ((txtResult.Text == "0") || isOperationPerformed == true) 
            {
                txtResult.Clear();
                isOperationPerformed = false;
                equalsRepeat = false;
                
            }

            
            isOperationPerformed = false;
           
            if (button.Text == ".")
            {
                if (!txtResult.Text.Contains("."))
                {
                    txtResult.Text = txtResult.Text + button.Text;
                }
            }
            else
            {
                txtResult.Text = txtResult.Text + button.Text;
                rightNum = Double.Parse(button.Text);
            }

            
            

        }

        private void operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
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
                if (isOperationPerformed == false)
                {
                    Operater = button.Text;
                    result = Double.Parse(txtResult.Text);
                    valueLabel = result + Operater;
                    lblOperation.Text = valueLabel;
                }
                else
                {
                    Operater = button.Text;
                    result = Double.Parse(txtResult.Text);
                    valueLabel = result + Operater;

                    result = Double.Parse(valueLabel + rightNum);
                    lblOperation.Text = valueLabel + result;
                }

            }
            
            //valueLabel = result + Operater;
            ////txtResult.AppendText(System.Environment.NewLine + valueLabel);
            //lblOperation.Text = valueLabel;
            isOperationPerformed = true;
        }

        private void BtnClearEntry_Click(object sender, EventArgs e)
        {
            txtResult.Text = "0";
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            result = 0;
            Operater = "";
            isOperationPerformed = false;
            equalsRepeat = false;
            equalOnceUsed = false;
            valueLabel = "";
            rightNum = 0;

        }
       
        private void BtnEquals_Click(object sender, EventArgs e)
        {
            if (equalsRepeat == false)
            {
                switch (Operater)
                {
                    case "+":
                        txtResult.Text = (result + Double.Parse(txtResult.Text)).ToString();
                        result = Double.Parse(txtResult.Text);
                        lblOperation.Text = valueLabel + rightNum;
                        //txtResult.AppendText(System.Environment.NewLine + valueLabel + rightNum);
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
                switch (Operater)
                {
                    case "+":
                        lblOperation.Text = txtResult.Text + "+" + rightNum.ToString();
                        result = Double.Parse(rightNum.ToString());
                        txtResult.Text = (Double.Parse(txtResult.Text) + result).ToString();
                      
                        //txtResult.AppendText(System.Environment.NewLine + valueLabel + rightNum);
                        break;
                    case "-":
                        lblOperation.Text = txtResult.Text + "+" + rightNum.ToString();
                        result = Double.Parse(rightNum.ToString());
                        txtResult.Text = (result - Double.Parse(txtResult.Text)).ToString();
                        break;
                    case "x":
                        lblOperation.Text = txtResult.Text + "+" + rightNum.ToString();
                        result = Double.Parse(rightNum.ToString());
                        txtResult.Text = (result * Double.Parse(txtResult.Text)).ToString();
                        break;
                    case "/":
                        lblOperation.Text = txtResult.Text + "+" + rightNum.ToString();
                        result = Double.Parse(rightNum.ToString());
                        txtResult.Text = (result / Double.Parse(txtResult.Text)).ToString();
                        break;
                    default:
                        break;
                }
            }

            //result = txtResult.Text;
            //lblOperation.Text = "";

            //if (equalOnceUsed == true)
            //{
            //    result = 0;
            //    lblOperation.Text = "";
            //    txtResult.Text = "0";
            //    isOperationPerformed = false;
            //}
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            lblOperation.Text = "";
            valueLabel = "";
            txtResult.Text = "0";
            result = 0;
            equalsRepeat = false;
            equalOnceUsed = false;
        }

       
    }
}
