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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }
 
        showapplicants sh = new showapplicants();
        private void button3_Click(object sender, EventArgs e)
        {
          
            sh.Show();
            sh.TopMost = true;
            sh.TopMost = false;
        }
        Employee emp = new Employee();
        private void button4_Click(object sender, EventArgs e)
        {
           
            emp.Show();
            emp.TopMost = true;
            emp.TopMost = false;

        }
        project p =new project();
        private void button2_Click(object sender, EventArgs e)
        {
            p.Show();
            p.TopMost = true;
            p.TopMost = false;


        }
    }
}
