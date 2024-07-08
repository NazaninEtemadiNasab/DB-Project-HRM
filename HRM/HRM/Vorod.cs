using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HRM
{
    public partial class Vorod : Form
    {
        private SqlConnection connection;

        public Vorod()
        {
            InitializeComponent();

            // Set up the database connection
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\beta laptop\source\repos\HRM\HRM\Database1.mdf"";Integrated Security=True";
            connection = new SqlConnection(connectionString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = maskedTextBox1.Text;

            string query = "SELECT * FROM AdloginTable WHERE Username = @Username AND Password = @Password";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    // Admin found, allow access
                    Admin admin = new Admin();
                    admin.Show();
                }
                else
                {
                    // No admin found, show error message
                    MessageBox.Show("Incorrect username or password. Please try again.");
                }

                reader.Close();
            }

            connection.Close();
        }
    }
}



/*using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRM
{
    public partial class Vorod : Form
    {
        public Vorod()
        {
            InitializeComponent();
        }
        Admin admin = new Admin();
            private void button1_Click(object sender, EventArgs e)
            {
                string username = textBox1.Text;
                string password = maskedTextBox1.Text;

                if (username == "admin" && password == "admin")
                {
               
                    admin.Show();
                    admin.TopMost = true;
                    admin.TopMost = false;
                }
                else
                {
                    MessageBox.Show("Incorrect username or password. Please try again.");
                }
            }


        

    }
}
*/