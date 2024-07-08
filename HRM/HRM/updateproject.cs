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
    public partial class updateproject : Form
    {
        public updateproject()
        {
            InitializeComponent();
        }

        void refresh()
        {
            try
            {
                comboBox1.Items.Clear();
                string query = "SELECT * FROM ProjectsTable";
                SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\beta laptop\source\repos\HRM\HRM\Database1.mdf"";Integrated Security=True");

                sqlConnection.Open();
                SqlCommand command = new SqlCommand(query, sqlConnection);
                var dr = command.ExecuteReader();
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr["id"] + ":" + "Project Name:" + dr["pname"] + "project ID:" + dr["pid"] + " " + "Department Number:" + dr["departementnumber"] + " " + "Report:" + dr["report"] + " ");
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            try
            {
                comboBox2.Items.Clear();
                string query = "SELECT * FROM DepartmentTable";
                SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\beta laptop\source\repos\HRM\HRM\Database1.mdf"";Integrated Security=True");

                sqlConnection.Open();
                SqlCommand command = new SqlCommand(query, sqlConnection);
                var dr = command.ExecuteReader();
                while (dr.Read())
                {
                    comboBox2.Items.Add(dr["departementnumber"]);
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }





        string id_1;
        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                string id = comboBox1.SelectedItem.ToString();
                int index = id.IndexOf(":");
                id = id.Substring(0, index);
                id_1 = id;
                comboBox1.Items.Clear();
                string query = "SELECT * FROM ProjectsTable WHERE id='" + id + "'";
                SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\beta laptop\source\repos\HRM\HRM\Database1.mdf"";Integrated Security=True");
                sqlConnection.Open();
                SqlCommand command = new SqlCommand(query, sqlConnection);
                var dr = command.ExecuteReader();
                dr.Read();
                textBox1.Text = dr["pname"].ToString();
                textBox2.Text = dr["pid"].ToString();

                textBox4.Text = dr["report"].ToString();

                comboBox2.Text = dr["departementnumber"].ToString();

                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }


        }

        private void updateproject_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            try
            {

                string pname = textBox1.Text;
                string pid = textBox2.Text;
                string report = textBox4.Text;
                string dno = comboBox2.Text;
                string query = "UPDATE ProjectsTable SET pname='" + pname + "', pid='" + pid + "',departementnumber ='" + dno + "', report='" + report + "' WHERE id='" + id_1 + "'";
                //  string query = "UPDATE EmployeeTable SET ssn='" + ssn +"'firstname='" + name +"lastname='" + fami +"'age='" + age +"'address='" + addr +"'mobile='" + mob +"'salary='" + salary + "'departementNumber='" + dno + "'startdate='" + date +"'WHERE id='" + id_1 +"'";
                SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\beta laptop\source\repos\HRM\HRM\Database1.mdf"";Integrated Security=True");
                sqlConnection.Open();
                SqlCommand command = new SqlCommand(query, sqlConnection);
                int i = command.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Update OK.");
                    textBox1.Text = textBox2.Text = textBox4.Text = "";
                    comboBox2.Text = "";



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
