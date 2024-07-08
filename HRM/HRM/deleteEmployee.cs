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
    public partial class deleteEmployee : Form
    {
        public deleteEmployee()
        {
            InitializeComponent();
        }

        private void deleteEmployee_Load(object sender, EventArgs e)
        {
            refresh();
        }
        void refresh()
            {
                try
                {
                    comboBox1.Items.Clear();
                    string query = "SELECT * FROM EmployeeTable";
                    SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\beta laptop\source\repos\HRM\HRM\Database1.mdf"";Integrated Security=True");

                    sqlConnection.Open();
                    SqlCommand command = new SqlCommand(query, sqlConnection);
                    var dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        comboBox1.Items.Add( dr["id"] + ":" + "Ssn:" + dr["ssn"] + "Firstname:" + dr["firstname"] + " " + "Lastname:" + dr["lastname"] + " " + "Age:" + dr["age"] + " " + "Address:" + dr["address"] + " " + "MObile:" + dr["mobile"] + " " + "Salary:" + dr["salary"] + " " + "Department Number:" + dr["departementnumber"] + " " + "Start Date:" + dr["startdate"]);
                    }
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }

            }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = comboBox1.SelectedItem.ToString();
            int index = id.IndexOf(":");
            id = id.Substring(0, index);
            try
            {
                string query = "DELETE FROM EmployeeTable WHERE id='" + id + "'";
                SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\beta laptop\source\repos\HRM\HRM\Database1.mdf"";Integrated Security=True");
                sqlConnection.Open();
                SqlCommand command = new SqlCommand(query, sqlConnection);
                int i = command.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("DELETE OK");
                    refresh();
                }
                else
                    MessageBox.Show("Nashod");
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

   
    }
    
}
