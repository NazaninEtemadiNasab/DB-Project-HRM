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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HRM
{
    public partial class aplicanvorod : Form
    {
        public aplicanvorod()
        {
            InitializeComponent();
        }
        Applicants ac = new Applicants();
        private void button1_Click(object sender, EventArgs e)
        {
           try {
                string user = textBox1.Text;
                string pass = maskedTextBox1.Text;
     
                string query = "INSERT INTO AploginTable(Username,Password) VALUES ('" + user + "','" + pass + "')";
                SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\beta laptop\source\repos\HRM\HRM\Database1.mdf"";Integrated Security=True");
                sqlConnection.Open();
                SqlCommand command = new SqlCommand(query, sqlConnection);
                int i = command.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Sucessfully added.");
                    textBox1.Text = maskedTextBox1.Text ="";

                    ac.Show();
                    ac.TopMost = true;
                    ac.TopMost = false;

                }
                else
                    MessageBox.Show("Error.");
                sqlConnection.Close();
            }
           catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }
    }
}
