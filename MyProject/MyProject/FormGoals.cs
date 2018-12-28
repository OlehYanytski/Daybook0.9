using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyProject
{
    public partial class FormGoals : Form
    {
        public FormGoals()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            Shows();
        }
        async void Shows()
        {
            SqlDataReader sqlDataReader=null;
            try
            {               
                string stringConnection = Form1.connection;
                SqlConnection sqlconnection = new SqlConnection(stringConnection);
                await sqlconnection.OpenAsync();
                string select = String.Format($"SELECT Goals FROM [TableGoals] WHERE [id]=1 ");
                SqlCommand command = new SqlCommand(select, sqlconnection);
                // SqlCommand command = new SqlCommand("SELECT SomeText FROM [TableText]", sqlconnection);
                sqlDataReader = await command.ExecuteReaderAsync();
                while (await sqlDataReader.ReadAsync())
                {
                    richTextBox1.Text += Convert.ToString(sqlDataReader["Goals"] );
                }

                if (richTextBox1.TextLength == 0)
                {
                    richTextBox1.Text = "Відсутні будь-які записи";
                }
            }
            catch (Exception exc)
            {
                richTextBox1.Text += exc.Message + "\n Очевидно виникла помилка.Ну що ж ви очікували від OlegEdition?";
            }
            finally
            {
                if (sqlDataReader != null) sqlDataReader.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Enabled = true;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection;
            string stringConnection =Form1.connection;
            connection = new SqlConnection(stringConnection);
            await connection.OpenAsync();
            SqlCommand command = new SqlCommand("UPDATE [TableGoals] SET [Goals]=@Goals WHERE [Id]=1 ", connection);           
            command.Parameters.AddWithValue("Goals",richTextBox1.Text);
            await command.ExecuteNonQueryAsync();
            richTextBox1.Enabled = false;
           
        }

        private void label1_Click(object sender, EventArgs e)
        {
            richTextBox1.Enabled = true;
        }

        private async void label2_Click(object sender, EventArgs e)
        {
            SqlConnection connection;
            string stringConnection =Form1.connection;
            connection = new SqlConnection(stringConnection);
            await connection.OpenAsync();
            SqlCommand command = new SqlCommand("UPDATE [TableGoals] SET [Goals]=@Goals WHERE [Id]=1 ", connection);
            command.Parameters.AddWithValue("Goals", richTextBox1.Text);
            await command.ExecuteNonQueryAsync();
            richTextBox1.Enabled = false;
        }
    }
}
