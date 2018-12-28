using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MyProject//тут гамнокод
{
    public partial class ReadDaybook : Form
    {
        int id = 1;
        public ReadDaybook()
        {
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;           
        }

        private  async void button1_Click(object sender, EventArgs e) 
        {
            
            string path="";
            for (int i = 0; i < 10; i++)
                  path += dateTimePicker1.Value.ToString()[i];
                richTextBox1.Clear();
            SqlDataReader sqlDataReader = null;
            try
            {
                string stringConnection = Form1.connection;
                SqlConnection sqlconnection = new SqlConnection(stringConnection);
                await sqlconnection.OpenAsync();
                string select = String.Format($"SELECT SomeText,TimeOfCreation FROM [TableText] WHERE CONVERT  (varchar,DataOfCreation)='{path}'");
                SqlCommand command = new SqlCommand(select, sqlconnection);
                sqlDataReader = await command.ExecuteReaderAsync();
                        while (await sqlDataReader.ReadAsync())
                        {
                            richTextBox1.Text += Convert.ToString(sqlDataReader["TimeOfCreation"])+"\n" +Convert.ToString(sqlDataReader["SomeText"]+"\n");
                        }
                
                if(richTextBox1.TextLength==0)
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
        private  async void buttondown_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length != 0)
            {
                string path = "";
                for (int i = 0; i < 10; i++)
                    path += dateTimePicker1.Value.ToString()[i];
                richTextBox1.Clear();
                SqlDataReader sqlDataReader = null;
                try
                {
                    string stringConnection = Form1.connection;
                    SqlConnection sqlconnection = new SqlConnection(stringConnection);
                    await sqlconnection.OpenAsync();
                    string select = String.Format($"SELECT SomeText,TimeOfCreation FROM [TableText] WHERE  Id= (SELECT Id-1 FROM [TableText] WHERE CONVERT  (varchar,DataOfCreation)='{path}') ");
                    SqlCommand command = new SqlCommand(select, sqlconnection);
                    sqlDataReader = await command.ExecuteReaderAsync();
                    

                    while (await sqlDataReader.ReadAsync())
                    {
                        richTextBox1.Text += Convert.ToString(sqlDataReader["TimeOfCreation"]) + "\n" + Convert.ToString(sqlDataReader["SomeText"] + "\n");
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
        }

        private async void buttonup_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length != 0)
            {
                string path = "";
                for (int i = 0; i < 10; i++)
                    path += dateTimePicker1.Value.ToString()[i];
                richTextBox1.Clear();
                SqlDataReader sqlDataReader = null;
                try
                {
                    string stringConnection = Form1.connection;
                    SqlConnection sqlconnection = new SqlConnection(stringConnection);
                    await sqlconnection.OpenAsync();
                    // SqlCommand comand = new SqlCommand("Select Id From [Table] WHERE", sqlconnection);
                    string select = String.Format($"SELECT SomeText,TimeOfCreation FROM [TableText] WHERE  Id= (SELECT Id+1 FROM [TableText] WHERE CONVERT  (varchar,DataOfCreation)='{path}') ");
                    SqlCommand command = new SqlCommand(select, sqlconnection);
                    // SqlCommand command = new SqlCommand("SELECT SomeText FROM [TableText]", sqlconnection);
                    sqlDataReader = await command.ExecuteReaderAsync();


                    while (await sqlDataReader.ReadAsync())
                    {
                        richTextBox1.Text += Convert.ToString(sqlDataReader["TimeOfCreation"]) + "\n" + Convert.ToString(sqlDataReader["SomeText"] + "\n");
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
        }

        private async void label1_Click(object sender, EventArgs e)
        {
            string path = "";
            for (int i = 0; i < 10; i++)
                path += dateTimePicker1.Value.ToString()[i];
            richTextBox1.Clear();
            SqlDataReader sqlDataReader = null;
            try
            {
                string stringConnection = Form1.connection;
                SqlConnection sqlconnection = new SqlConnection(stringConnection);
                await sqlconnection.OpenAsync();
                string select = String.Format($"SELECT SomeText,TimeOfCreation,Id FROM [TableText] WHERE CONVERT  (varchar,DataOfCreation)='{path}'");
                SqlCommand command = new SqlCommand(select, sqlconnection);
                // SqlCommand command = new SqlCommand("SELECT SomeText FROM [TableText]", sqlconnection);
                sqlDataReader = await command.ExecuteReaderAsync();


                while (await sqlDataReader.ReadAsync())
                {
                    try {
                        richTextBox1.Text += Convert.ToString(sqlDataReader["TimeOfCreation"]) + "\n" + Convert.ToString(sqlDataReader["SomeText"] + "\n");
                    }
                    finally
                    {
                        id = Convert.ToInt32(sqlDataReader["Id"]);
                    }
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

        private async void label2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            int localid = --id ;
            SqlDataReader sqlDataReader = null;
            try
            {
                string stringConnection = Form1.connection;
                SqlConnection sqlconnection = new SqlConnection(stringConnection);
                await sqlconnection.OpenAsync();
                string select = String.Format($"SELECT SomeText,TimeOfCreation FROM [TableText] WHERE Id={localid.ToString()} ");
                SqlCommand command = new SqlCommand(select, sqlconnection);
                // SqlCommand command = new SqlCommand("SELECT SomeText FROM [TableText]", sqlconnection);
                sqlDataReader = await command.ExecuteReaderAsync();


                while (await sqlDataReader.ReadAsync())
                {
                    richTextBox1.Text += Convert.ToString(sqlDataReader["TimeOfCreation"]) + "\n" + Convert.ToString(sqlDataReader["SomeText"] + "\n");
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

        private async void label3_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            int localid = ++id ;
            SqlDataReader sqlDataReader = null;
            try
            {
                string stringConnection = Form1.connection;
                SqlConnection sqlconnection = new SqlConnection(stringConnection);
                await sqlconnection.OpenAsync();
                string select = String.Format($"SELECT SomeText,TimeOfCreation FROM [TableText] WHERE Id={localid.ToString()} ");
                SqlCommand command = new SqlCommand(select, sqlconnection);
                // SqlCommand command = new SqlCommand("SELECT SomeText FROM [TableText]", sqlconnection);
                sqlDataReader = await command.ExecuteReaderAsync();


                while (await sqlDataReader.ReadAsync())
                {
                    richTextBox1.Text += Convert.ToString(sqlDataReader["TimeOfCreation"]) + "\n" + Convert.ToString(sqlDataReader["SomeText"] + "\n");
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

        private async void label4_Click(object sender, EventArgs e)
        {
            SqlDataReader sqlDataReader = null;
            try
            {
                                
                int localid;
                Int32.TryParse(richTextBox1.Text,out localid);
                richTextBox1.Clear();
                string stringConnection = Form1.connection;
                SqlConnection sqlconnection = new SqlConnection(stringConnection);
                await sqlconnection.OpenAsync();
                string select = String.Format($"SELECT SomeText,TimeOfCreation FROM [TableText] WHERE Id={localid.ToString()} ");
                SqlCommand command = new SqlCommand(select, sqlconnection);
                // SqlCommand command = new SqlCommand("SELECT SomeText FROM [TableText]", sqlconnection);
                sqlDataReader = await command.ExecuteReaderAsync();


                while (await sqlDataReader.ReadAsync())
                {
                    richTextBox1.Text += Convert.ToString(sqlDataReader["TimeOfCreation"]) + "\n" + Convert.ToString(sqlDataReader["SomeText"] + "\n");
                }

                if (richTextBox1.TextLength == 0)
                {
                    richTextBox1.Text = "Вказаного запису не існує,введіть id в текстове поле(номер запису)";
                }
            }
            catch (Exception exc)
            {
                richTextBox1.Text += exc.Message + "\n Очевидно виникла помилка.ВВедіть id?";
            }
            finally
            {
                if (sqlDataReader != null) sqlDataReader.Close();
            }
        }
    }
}
