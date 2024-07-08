using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRM
{
    public partial class ShowProjects : Form
    {
        public ShowProjects()
        {
            InitializeComponent();
        }



        private void button5_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                textBox1.Clear();
                string query = "SELECT * FROM ProjectsTable";
                SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\beta laptop\source\repos\HRM\HRM\Database1.mdf"";Integrated Security=True");
                sqlConnection.Open();
                SqlCommand command = new SqlCommand(query, sqlConnection);
                var dr = command.ExecuteReader();
                while (dr.Read())
                {
                    
                    //  comboBox1.Items.Add(dr["id"] + ":" + dr["name"] + " " + dr["family"]);
                    textBox1.AppendText("Id:" + " " + dr["id"] + " " + "Project Name:" + dr["pname"] + "project ID:" + dr["pid"] + " " + "Department Number:" + dr["departementnumber"] + " " + "Report:" + dr["report"] + " " + Environment.NewLine);
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
