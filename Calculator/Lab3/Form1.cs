using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Form1 : Form
    {
        double solution = 0;

        public Form1()
        {
            InitializeComponent();
            this.Text = "Mario Han - Lab 3";
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            solution = 0;
            textBox2.Text = solution.ToString();
        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                double buffer = Convert.ToDouble(textBox1.Text);
                solution = solution + buffer;
                textBox2.Text = solution.ToString();
                textBox1.Text = string.Empty;
            }
            catch (FormatException fe)
            {
                
                MessageBox.Show(fe.Message);
                textBox2.Text = solution.ToString();
            }
        }

        private void button3_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                double buffer = Convert.ToDouble(textBox1.Text);
                solution = solution - buffer;
                textBox2.Text = solution.ToString();
                textBox1.Text = string.Empty;
            }
            catch (FormatException fe)
            {
                MessageBox.Show(fe.Message);
                textBox2.Text = solution.ToString();
            }
        }

        private void button4_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                double buffer = Convert.ToDouble(textBox1.Text);
                solution = solution * buffer;
                textBox2.Text = solution.ToString();
                textBox1.Text = string.Empty;
            }
            catch (FormatException fe)
            {
                MessageBox.Show(fe.Message);
                textBox2.Text = solution.ToString();
            }
        }

        private void button5_MouseClick(object sender, MouseEventArgs e)
        {
             try
            {
                 double buffer = Convert.ToDouble(textBox1.Text);
                if (buffer == 0 && textBox2.Text != "0")
                {
                    textBox2.Text = "∞";
                    textBox1.Text = string.Empty;
                }
                else if(buffer == 0 && textBox2.Text == "0")
                {
                    textBox2.Text = "NaN";
                    textBox1.Text = string.Empty;
                }
                else
                {
                    solution = solution / buffer;
                    textBox2.Text = solution.ToString();
                    textBox1.Text = string.Empty;
                }
            }
            catch (FormatException fe)
            {
                MessageBox.Show(fe.Message);
                textBox2.Text = solution.ToString();
            }
        }
    }
}
