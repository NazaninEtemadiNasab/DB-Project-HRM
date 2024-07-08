using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRM
{
    public partial class Applicants : Form
    {
        public Applicants()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string ssn = textBox1.Text;
                string name = textBox2.Text;
                string fami = textBox3.Text;
                string age = textBox4.Text;
                string addr = textBox5.Text;
                string mob = textBox6.Text;
                string mail = textBox7.Text;
                string job = textBox8.Text;
                string expr = textBox9.Text;
                string query = "INSERT INTO ApplicantsTable (ssn,firstname,lastname,age,address,mobile,email,job,experience)" +
                    "VALUES ('"+ssn + "','" + name + "','" + fami + "','" + age + "','" + addr + "','" + mob + "','" + mail + "','" + job + "','" + expr + "')";
                SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\beta laptop\source\repos\HRM\HRM\Database1.mdf"";Integrated Security=True");
                sqlConnection.Open();
                SqlCommand command = new SqlCommand(query, sqlConnection);
                int i = command.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Your request has been successfully sent.");
                    textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = textBox8.Text = textBox9.Text = "";
                 
                }
                else
                    MessageBox.Show("Problem!");
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

      

        
    }
    
}
