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
    public partial class project : Form
    {
        public project()
        {
            InitializeComponent();
        }

        void refresh()
        {
            
            try
            {
                comboBox1.Items.Clear();
                string query = "SELECT * FROM DepartmentTable";
                SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\beta laptop\source\repos\HRM\HRM\Database1.mdf"";Integrated Security=True");

                sqlConnection.Open();
                SqlCommand command = new SqlCommand(query, sqlConnection);
                var dr = command.ExecuteReader();
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr["departementnumber"]);
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void project_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string pname = textBox1.Text;
                string pid = textBox2.Text;
                string dname = comboBox1.Text;
                string report = textBox4.Text;
                string query = "INSERT INTO ProjectsTable (pname,pid,departementnumber,report)" +
                    "VALUES ('" + pname + "','" + pid + "','" + dname + "','" + report +"')";
                SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\beta laptop\source\repos\HRM\HRM\Database1.mdf"";Integrated Security=True");
                sqlConnection.Open();
                SqlCommand command = new SqlCommand(query, sqlConnection);
                int i = command.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("project added.");
                    textBox1.Text = textBox2.Text = textBox4.Text  ="";
                    comboBox1.Text = "";

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
        ShowProjects ss= new ShowProjects();
        private void button2_Click(object sender, EventArgs e)
        {
            ss.Show();
            ss.TopMost
                = true; 
            ss.TopMost = false;

        }
        deleteproject de= new deleteproject();  
        private void button3_Click(object sender, EventArgs e)
        {
            de.Show();
            de.TopMost
                = true;
            de.TopMost = false;

        }
        updateproject up = new updateproject();
        private void button4_Click(object sender, EventArgs e)
        {
            up.Show();
            up.TopMost= true;
            up.TopMost = false;

        }
        WorksOnSetting we = new WorksOnSetting();
        private void button7_Click(object sender, EventArgs e)
        {
            we.Show();  
            we.TopMost = true;  
            we.TopMost = false;
        }

    }
}
