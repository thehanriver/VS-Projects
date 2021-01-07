using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6
{
    public partial class Settings : Form
    {
        private int pen_color;
        private int fill_color;
        private int pen_width;
        public Settings(int n_pen_color, int n_fill_color, int n_pen_width)
        {
            InitializeComponent();
            pen_color = n_pen_color;
            listBox1.SelectedIndex = n_pen_color;

            fill_color = n_fill_color;
            listBox2.SelectedIndex = n_fill_color;

            pen_width = n_pen_width;
            listBox3.SelectedIndex = n_pen_width;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            pen_color = listBox1.SelectedIndex;
            fill_color = listBox2.SelectedIndex;
            pen_width = listBox3.SelectedIndex;
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        public int get_pen_color()
        {
            return pen_color;
        }
        public int get_fill_color()
        {
            return fill_color;

        }
        public int get_pen_width()
        {
            return pen_width;
        }
    }
}
