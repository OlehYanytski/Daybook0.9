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
namespace MyProject
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }                    
                private void button10_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        private void label1_Click(object sender, EventArgs e)
        {
            new ToDoListForm().ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            new FormGoals().ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            new FormNotes().ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            new DaybookForm().ShowDialog();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void label6_Click(object sender, EventArgs e)
        {
             new Settings().ShowDialog();
        }
    }
}
