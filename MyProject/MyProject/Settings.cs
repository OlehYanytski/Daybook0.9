using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MyProject
{
    public partial  class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }
      static  string oldpassword, password;
      

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            oldpassword = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            password = textBox1.Text;
        }

        async void Change()
        {
 
            if (  Form1.pas==oldpassword   && textBox2.TextLength >= 1 )
            {
                SqlConnection connection;
                string stringConnection = Form1.connection;
                connection = new SqlConnection(stringConnection);
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("UPDATE [TablePassword] SET [password]=@pass WHERE [Id]=1 ", connection);
                command.Parameters.AddWithValue("pass", textBox2.Text);
                await command.ExecuteNonQueryAsync();
                MessageBox.Show($"Password was Changed ({ textBox2.Text})");
            }
            else
            {
                MessageBox.Show("Невірний пароль");
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {
            Change();
           
        }
    }
}
