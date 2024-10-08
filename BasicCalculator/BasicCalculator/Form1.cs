﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string CalTotal;
        float num1;
        float num2;
        string option;
        float result;

        private void button1_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + "7";
        }

        private void button20_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + "0";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + "1";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + "2";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + "3";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + "4";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + "5";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + "6";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + "8";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + "9";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if(!(txtDisplay.Text.Contains(".")))
                txtDisplay.Text = txtDisplay.Text + ".";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtDisplay.Clear();
            num1 = 0;
            num2 = 0;
            result = 0;
            option = "";

        }

        private void button17_Click(object sender, EventArgs e)
        {
            option = "+";
            num1 = float.Parse(txtDisplay.Text);

            txtDisplay.Clear();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            num2 = float.Parse(txtDisplay.Text);
            if (option.Equals("+"))
            {
                result = num1 + float.Parse(txtDisplay.Text);
                txtDisplay.Text = result.ToString();
            }

            if (option.Equals("-"))
            {
                result = num1 - float.Parse(txtDisplay.Text);
                txtDisplay.Text = result.ToString();
            }

            if (option.Equals("*"))
            {
                result = num1 * float.Parse(txtDisplay.Text);
                txtDisplay.Text = result.ToString();
            }

            if (option.Equals("/"))
            {
                if (float.Parse(txtDisplay.Text) == 0)
                {
                    txtDisplay.Text = "Cannot divide";
                }

                else
                {
                    result = num1 / num2;
                    txtDisplay.Text = result + "";
                }
            }

            if (option.Equals("%"))
            {
                txtDisplay.Text = (num1 % num2).ToString();
            }    
        }

        private void button12_Click(object sender, EventArgs e)
        {
            option = "-";
            num1 = float.Parse(txtDisplay.Text);

            txtDisplay.Clear();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            option = "*";
            num1 = float.Parse(txtDisplay.Text);

            txtDisplay.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            option = "/";
            num1 = float.Parse(txtDisplay.Text);

            txtDisplay.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            option = "%";
            num1 = float.Parse(txtDisplay.Text);

            txtDisplay.Clear();
        }

        private void txtDisplay_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
