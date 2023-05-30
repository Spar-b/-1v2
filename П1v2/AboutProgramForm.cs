using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace П1v2
{
    public partial class AboutProgramForm : Form
    {
        public string version = "0.1.1";
        public AboutProgramForm()
        {
            InitializeComponent();
        }
        
        private void AboutProgramForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = version;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuForm menuForm = new MenuForm();
            menuForm.Show();
            Button button = button1;
            Form currentForm = (Form)button.FindForm();
            currentForm.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
