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
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }

        private void X_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                textBox1.Clear();
                string query = "SELECT * FROM EmployeeTable";
                SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\beta laptop\source\repos\HRM\HRM\Database1.mdf"";Integrated Security=True");
                sqlConnection.Open();
                SqlCommand command = new SqlCommand(query, sqlConnection);
                var dr = command.ExecuteReader();
                while (dr.Read())
                {
                    //  comboBox1.Items.Add(dr["id"] + ":" + dr["name"] + " " + dr["family"]);
                    textBox1.AppendText("Id:" + " " + dr["id"] + " " + "Ssn:" + dr["ssn"] + "Firstname:" + dr["firstname"] + " " + "Lastname:" + dr["lastname"] + " " + "Age:" + dr["age"] + " " + "Address:" + dr["address"] + " " + "MObile:" + dr["mobile"] + " " + "Salary:" + dr["salary"] + " " + "Department Number:" + dr["departementnumber"] + " " + "Start Date:" + dr["startdate"] + " " + Environment.NewLine);
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        void refresh()
        {
            try
            {
                //comboBox1.Items.Clear();
                //textBox1.Text = "";
                textBox1.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            refresh();
        }
        deleteEmployee de=new deleteEmployee();
        private void button2_Click(object sender, EventArgs e)
        {
            de.Show();
            de.TopMost=true;
            de.TopMost = false;

        }
        updateEmployee up=new updateEmployee();
        private void button3_Click(object sender, EventArgs e)
        {
            up.Show();
            up.TopMost = true;
            up.TopMost = false;


        }
        AddEmployee ad =new AddEmployee();
        private void button4_Click(object sender, EventArgs e)
        {
            ad.Show();
            ad.TopMost = true;
            ad.TopMost = false;

        }
    }
}
