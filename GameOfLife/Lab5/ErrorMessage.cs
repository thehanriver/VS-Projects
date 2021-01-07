using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    public partial class ErrorMessage : Form
    {
        public ErrorMessage()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawString("ERROR:\nclicked on taken cell.\nTry again!", Font, Brushes.Black, 10, 10);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
