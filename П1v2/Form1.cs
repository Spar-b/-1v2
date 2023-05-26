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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            this.Hide();
            form2.Show();
        }

        public void проПрограмуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutProgramForm aboutProgram = new AboutProgramForm();
            aboutProgram.Show();

            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            Form currentForm = (Form)menuItem.GetCurrentParent().FindForm();
            currentForm.Hide();
        }

        private void допомогаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Оберіть один з перелічених варіантів роботи програми","Допомога",
                MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
