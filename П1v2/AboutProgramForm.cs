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
        public string version = "0.0.0";
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
            Form1 form1 = new Form1();
            form1.Show();
            Button button = button1;
            Form currentForm = (Form)button.FindForm();
            currentForm.Hide();
        }
    }
}
