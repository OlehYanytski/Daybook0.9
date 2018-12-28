using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MyProject
{

    
    public  partial class Form1 : Form
    {
        static string  password;
        public  string GetPathToDataBase()
        {
            string s = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Application.StartupPath + @"\Database1.mdf; Integrated Security = True";
            return s;
        }

        public  string Password
        {
            get
            {
                async  void Read()
                {
                    
                    SqlDataReader sqlDataReader = null;
                    try
                    {
                        string stringConnection = connection;
                        SqlConnection sqlconnection = new SqlConnection(stringConnection);
                        await sqlconnection.OpenAsync();
                        string select = String.Format($"SELECT password FROM [TablePassword] WHERE Id=1");
                        SqlCommand command = new SqlCommand(select, sqlconnection);
                        sqlDataReader = await command.ExecuteReaderAsync();
                        while (await sqlDataReader.ReadAsync())
                        {
                          label1.Text+= Convert.ToString(sqlDataReader["password"]);
                        }
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.Message);
                    }
                    finally
                    {
                        if (sqlDataReader != null) sqlDataReader.Close();

                    }
                }               
                Read();
                return label1.Text;
            }
            set
            {
                password = value;
            }
        }
       public static string pas;
        MainForm mf = new MainForm();
      public static string connection;
        public Form1()
        {
            InitializeComponent();
            connection= GetPathToDataBase();
            pas = Password;
          
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == label1.Text)//отут зробити цей метод!
            {
                pas = label1.Text;
                this.Hide();
                mf.ShowDialog();
                this.Close();
               
            }
        }

    }
}
