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
    public partial class AddEmployee : Form
    {
        public AddEmployee()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string ssn = textBox1.Text;
                string name = textBox2.Text;
                string fami = textBox3.Text;
                string age = textBox4.Text;
                string addr = textBox5.Text;
                string mob = textBox6.Text;
                string salary = textBox6.Text;
                string dno = comboBox2.Text;
                string date = dateTimePicker1.Text;
                string query = "INSERT INTO EmployeeTable (ssn,firstname,lastname,age,address,mobile,salary,departementnumber,startdate)" +
                    "VALUES ('" + ssn + "','" + name + "','" + fami + "','" + age + "','" + addr + "','" + mob + "','" + salary + "','" + dno + "','" + date + "')";
                SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\beta laptop\source\repos\HRM\HRM\Database1.mdf"";Integrated Security=True");
                sqlConnection.Open();
                SqlCommand command = new SqlCommand(query, sqlConnection);
                int i = command.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Successfully.");
                    textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = "";
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
