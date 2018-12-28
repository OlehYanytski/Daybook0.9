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

namespace MyProject//тут гамнокод
{
    public partial class FormNotes : Form
    {
        public FormNotes()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            //вибрали всі теми
            Shows();           
        }
       

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            textBox1.Clear();
        }

        private async void button2_Click(object sender, EventArgs e)
        {  //вводити назву,в окреме вікно і дивитися по назві ,в автозагрузку добавити всі назви
            richTextBox1.Clear();
            SqlDataReader sqlDataReader = null;          
            try
            {

                string stringConnection = Form1.connection;
                SqlConnection sqlconnection = new SqlConnection(stringConnection);
                await sqlconnection.OpenAsync();
                string select = String.Format($"SELECT Notes,DateOfCreation FROM [TableNotes] WHERE '{textBox1.Text}'=NameNotes");
                SqlCommand command = new SqlCommand(select, sqlconnection);
                sqlDataReader = await command.ExecuteReaderAsync();
                while (await sqlDataReader.ReadAsync())
                {
                    richTextBox1.Text += Convert.ToString(sqlDataReader["Notes"] + "\n");
                }
                if (richTextBox1.TextLength == 0)
                {
                    richTextBox1.Text = "Вказаного запису не існує";
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
        private async void button1_Click(object sender, EventArgs e)
        {           
            if (richTextBox1.Text.Length != 0 && textBox1.Text.Length !=0)
            {
                SqlConnection connection;
                string stringConnection = Form1.connection;
                connection = new SqlConnection(stringConnection);
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("Insert INTO [TableNotes] (Notes,DateOfCreation,NameNotes) VALUES(@Text,@Date,@Name)", connection);
                command.Parameters.AddWithValue("Text", richTextBox1.Text);
                command.Parameters.AddWithValue("Date", System.DateTime.Now.ToShortDateString());
                command.Parameters.AddWithValue("Name",textBox1.Text);
                    
                await command.ExecuteNonQueryAsync();
                richTextBox1.Clear();
                textBox1.Clear();
            }
            else
            {
                MessageBox.Show("Fill in all required fields");
            }
        }
        async void  Shows()
        {
            richTextBox1.Clear();
            SqlDataReader sqlDataReader = null;

            try
            {
                string stringConnection = Form1.connection;
                SqlConnection sqlconnection = new SqlConnection(stringConnection);
                await sqlconnection.OpenAsync();
                string select = String.Format($"SELECT NameNotes FROM [TableNotes] ");
                SqlCommand command = new SqlCommand(select, sqlconnection);
                // SqlCommand command = new SqlCommand("SELECT SomeText FROM [TableText]", sqlconnection);
                sqlDataReader = await command.ExecuteReaderAsync();
                while (await sqlDataReader.ReadAsync())
                {
                    richTextBox1.Text += Convert.ToString(sqlDataReader["NameNotes"] + "\n");
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
        private   void button4_Click(object sender, EventArgs e)
        {
           Shows();
        }
        private async void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Length != 0 && richTextBox1.Text == "delete" || richTextBox1.Text == "Delete" || richTextBox1.Text == "DELETE")
                {
                    SqlConnection connection;
                    string stringConnection = Form1.connection;
                    connection = new SqlConnection(stringConnection);
                    await connection.OpenAsync();
                    SqlCommand command = new SqlCommand($"DELETE FROM [TableNotes] WHERE '{textBox1.Text}'=NameNotes", connection);
                    await command.ExecuteNonQueryAsync();
                    richTextBox1.Clear();
                    textBox1.Clear();
                }
                else
                {
                    MessageBox.Show("Enter 'Delete' in RichTextBox and 'NameNotes'in TextBox ");
                }
            }
            catch(Exception exc)
            {
                richTextBox1.Text = exc.Message;
            }           
        }
        private void label1_Click(object sender, EventArgs e)
        {
            Shows();
        }

        private async void label2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            SqlDataReader sqlDataReader = null;
            try
            {

                string stringConnection = Form1.connection;
                SqlConnection sqlconnection = new SqlConnection(stringConnection);
                await sqlconnection.OpenAsync();
                string select = String.Format($"SELECT Notes,DateOfCreation FROM [TableNotes] WHERE '{textBox1.Text}'=NameNotes");
                SqlCommand command = new SqlCommand(select, sqlconnection);
                // SqlCommand command = new SqlCommand("SELECT SomeText FROM [TableText]", sqlconnection);
                sqlDataReader = await command.ExecuteReaderAsync();
                while (await sqlDataReader.ReadAsync())
                {
                    richTextBox1.Text += Convert.ToString(sqlDataReader["Notes"] + "\n");
                }

                if (richTextBox1.TextLength == 0)
                {
                    richTextBox1.Text = "Вказаного запису не існує";
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

        private void label3_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            textBox1.Clear();
        }

        private async void label4_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Length != 0 && richTextBox1.Text == "delete" || richTextBox1.Text == "Delete" || richTextBox1.Text == "DELETE")
                {
                    SqlConnection connection;
                    string stringConnection = Form1.connection;
                    connection = new SqlConnection(stringConnection);
                    await connection.OpenAsync();
                    SqlCommand command = new SqlCommand($"DELETE FROM [TableNotes] WHERE '{textBox1.Text}'=NameNotes", connection);
                    await command.ExecuteNonQueryAsync();
                    richTextBox1.Clear();
                    textBox1.Clear();
                }
                else
                {
                    MessageBox.Show("Enter 'Delete' in RichTextBox and 'NameNotes'in TextBox ");
                }
            }
            catch (Exception exc)
            {
                richTextBox1.Text = exc.Message;
            }

        }
        private async void label5_Click(object sender, EventArgs e)
        {

            if (richTextBox1.Text.Length != 0 && textBox1.Text.Length != 0)
            {
                SqlConnection connection;
                string stringConnection = Form1.connection;
                connection = new SqlConnection(stringConnection);
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("Insert INTO [TableNotes] (Notes,DateOfCreation,NameNotes) VALUES(@Text,@Date,@Name)", connection);
                command.Parameters.AddWithValue("Text", richTextBox1.Text);
                command.Parameters.AddWithValue("Date", System.DateTime.Now.ToShortDateString());
                command.Parameters.AddWithValue("Name", textBox1.Text);
                await command.ExecuteNonQueryAsync();
                richTextBox1.Clear();
                textBox1.Clear();
            }
            else
            {
                MessageBox.Show("Fill in all required fields");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Щоб написати замітку потрібно написати текст і назву замітки\n" +
                "Щоб видалити замітку в відповідному полі введіть назву і в полі для написанню замітки напишіть 'Delete' і нажміть на кнопку 'видалити' ");
        }
    }
}
