using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }
        Vorod v = new Vorod();
        private void button1_Click_1(object sender, EventArgs e)
        {
            v.Show();
            v.TopMost = true;
            v.TopMost = false;
        }
        aplicanvorod va= new aplicanvorod();
        private void button2_Click(object sender, EventArgs e)
        {
            va.Show();
            va.TopMost = true;
            va.TopMost = false;
        }
    }
}
