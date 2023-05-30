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
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();

            
        }


        public void проПрограмуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutProgramForm aboutProgram = new AboutProgramForm();
            aboutProgram.Show();

        }

        public void допомогаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpForm helpForm = new HelpForm();
            helpForm.Show();

        }
        private void завдання1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Task1Form form2 = new Task1Form();
            form2.Show();
        }

        private void вийтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void завдання2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Task2Form task2 = new Task2Form();
            task2.Show();
        }
        private void menuForm_Load(object sender, EventArgs e)
        {
            завдання1ToolStripMenuItem1.Click += завдання1ToolStripMenuItem_Click;
            завдання2ToolStripMenuItem1.Click += завдання2ToolStripMenuItem_Click;
            вийтиToolStripMenuItem1.Click += вийтиToolStripMenuItem_Click;

            Task2Form task2 = new Task2Form();
            допомогаToolStripMenuItem1.Click += task2.допомогаToolStripMenuItem1_Click;
            проПрограмуToolStripMenuItem1.Click += task2.проПрограмуToolStripMenuItem1_Click;
        }
    }
}
