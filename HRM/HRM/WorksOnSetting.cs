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
    public partial class WorksOnSetting : Form
    {
        public WorksOnSetting()
        {
            InitializeComponent();
        }
        private void button4_Click(object sender, EventArgs e)
        {

            try
            {
                textBox1.Clear();
                string query = "SELECT * FROM WorkmsOnTable";
                SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\beta laptop\source\repos\HRM\HRM\Database1.mdf"";Integrated Security=True");
                sqlConnection.Open();
                SqlCommand command = new SqlCommand(query, sqlConnection);
                var dr = command.ExecuteReader();
                while (dr.Read())
                {
                    
                    textBox1.AppendText("Id:" + " " + dr["id"] + " " + "ESsn:" + dr["Essn"] + "P ID:" + dr["pid"] + " " + "Hours:" + dr["Hours"] + Environment.NewLine);
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
