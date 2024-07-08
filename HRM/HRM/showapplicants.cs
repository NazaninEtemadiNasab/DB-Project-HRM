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
    public partial class showapplicants : Form
    {
        public showapplicants()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                textBox1.Clear(); 
                string query = "SELECT * FROM ApplicantsTable";
                SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\beta laptop\source\repos\HRM\HRM\Database1.mdf"";Integrated Security=True");
                sqlConnection.Open();
                SqlCommand command = new SqlCommand(query, sqlConnection);
                var dr = command.ExecuteReader();
                while (dr.Read())
                {
                    textBox1.AppendText( "Id:" + " " + dr["id"] + " " + "Ssn:" + dr["ssn"]+ "Firstname:" + dr["firstname"] + " " + "Lastname:" + dr["lastname"] + " " + "Age:" + dr["age"] + " " + "Address:" + dr["address"] + " " + "MObile:" + dr["mobile"] + " " + "Email:" + dr["email"] + " " + "Job:" + dr["job"] + " " + "WorkExperience:" + dr["experience"] + " " +Environment.NewLine);
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
           
                textBox1.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void showapplicants_Load(object sender, EventArgs e)
        {
            refresh();
        }
        RejectApplicant re=new RejectApplicant();
        private void button3_Click(object sender, EventArgs e)
        {
            re.Show();
            re.TopMost = true;
            re.TopMost = false;
        }
        AccseptAplicant ap=new AccseptAplicant();
        private void button4_Click(object sender, EventArgs e)
        {
            ap.Show();
            ap.TopMost = true;
            ap.TopMost = false;

        }
    }
}
