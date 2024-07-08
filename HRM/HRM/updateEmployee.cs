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
    public partial class updateEmployee : Form
    {
        public updateEmployee()
        {
            InitializeComponent();
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
                    comboBox1.Items.Add(dr["id"] + ":" + "Ssn:" + dr["ssn"] + "Firstname:" + dr["firstname"] + " " + "Lastname:" + dr["lastname"] + " " + "Age:" + dr["age"] + " " + "Address:" + dr["address"] + " " + "Mobile:" + dr["mobile"] + " " + "Salary:" + dr["salary"] + " " + "Department Number:" + dr["departementnumber"] + " " + "Start Date:" + dr["startdate"]);
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
                string salary = textBox7.Text;
                string dno = comboBox2.Text;
                string date = dateTimePicker1.Text;
                string query = "UPDATE EmployeeTable SET ssn='" + ssn + "', firstname='" + name + "', lastname='" + fami + "', age='" + age + "', address='" + addr + "', mobile='" + mob + "', salary='" + salary + "', departementNumber='" + dno + "', startdate='" + date + "' WHERE id='" + id_1 + "'";
                //  string query = "UPDATE EmployeeTable SET ssn='" + ssn +"'firstname='" + name +"lastname='" + fami +"'age='" + age +"'address='" + addr +"'mobile='" + mob +"'salary='" + salary + "'departementNumber='" + dno + "'startdate='" + date +"'WHERE id='" + id_1 +"'";
                SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\beta laptop\source\repos\HRM\HRM\Database1.mdf"";Integrated Security=True");
                sqlConnection.Open();
                SqlCommand command = new SqlCommand(query, sqlConnection);
                int i = command.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Update OK");
                    textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = "";
                    comboBox2.Text="";
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

       
        private void updateEmployee_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string id = comboBox1.SelectedItem.ToString();
                int index = id.IndexOf(":");
                id = id.Substring(0, index);
                id_1 = id;
                comboBox1.Items.Clear();
                string query = "SELECT * FROM EmployeeTable WHERE id='" + id + "'";
                SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\beta laptop\source\repos\HRM\HRM\Database1.mdf"";Integrated Security=True");
                sqlConnection.Open();
                SqlCommand command = new SqlCommand(query, sqlConnection);
                var dr = command.ExecuteReader();
                dr.Read();
                textBox1.Text = dr["ssn"].ToString();
                textBox2.Text = dr["firstname"].ToString();
                textBox3.Text = dr["lastname"].ToString();
                textBox4.Text = dr["age"].ToString();
                textBox5.Text = dr["address"].ToString();
                textBox6.Text = dr["mobile"].ToString();
                textBox7.Text = dr["salary"].ToString();
                comboBox2.Text = dr["departementnumber"].ToString();
                dateTimePicker1.Text = dr["startdate"].ToString();
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
     

        }
    }
}
