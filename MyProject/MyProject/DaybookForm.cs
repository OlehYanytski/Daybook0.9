using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;


namespace MyProject
{
    public partial class DaybookForm : Form
    {
      public  SqlConnection sqlconnection;
        ReadDaybook rdb = new ReadDaybook();
        public  DaybookForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            Connect();
        }
        public  async void Connect() {
            string stringConnection =Form1.connection;
            sqlconnection = new SqlConnection(stringConnection);
            await sqlconnection.OpenAsync();
        }
       
        private async void button1_Click(object sender, EventArgs e)
        {           
            if (richTextBox1.Text.Length != 0)
            {
                SqlCommand command = new SqlCommand("Insert INTO [TABLETEXT] (SomeText,DataOfCreation,TimeOfCreation) VALUES(@Text,@Date,@Time)", sqlconnection);
                command.Parameters.AddWithValue("Text", richTextBox1.Text);
                command.Parameters.AddWithValue("Time", System.DateTime.Now.ToShortTimeString());
                command.Parameters.AddWithValue("Date", System.DateTime.Now.ToShortDateString());
                await command.ExecuteNonQueryAsync();
                richTextBox1.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            rdb.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            rdb.ShowDialog();
        }
                private async void label2_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length != 0)
            {
                SqlCommand command = new SqlCommand("Insert INTO [TABLETEXT] (SomeText,DataOfCreation,TimeOfCreation) VALUES(@Text,@Date,@Time)", sqlconnection);
                command.Parameters.AddWithValue("Text", richTextBox1.Text);
                command.Parameters.AddWithValue("Time", System.DateTime.Now.ToShortTimeString());
                command.Parameters.AddWithValue("Date", System.DateTime.Now.ToShortDateString());
                await command.ExecuteNonQueryAsync();
                richTextBox1.Clear();
            }
        }
    }
}
