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

namespace П1v2
{
    public partial class Task2Form : Form
    {
        public double precision = 0.001;
        public string filepath = "file1.txt";
        public bool isFileEmpty = true;
        public Task2Form()
        {
            InitializeComponent();
            Form1 menu = new Form1();
            проПрограмуToolStripMenuItem.Click += menu.проПрограмуToolStripMenuItem_Click;
            допомогаToolStripMenuItem.Click += menu.допомогаToolStripMenuItem_Click;

            Form2 task1 = new Form2();
            назаддоМенюToolStripMenuItem.Click += task1.назаддоМенюToolStripMenuItem_Click;

            обчислитиToolStripMenuItem1.Click += обчислитиToolStripMenuItem_Click;
            прочитатиЗФайлуToolStripMenuItem1.Click += прочитатиЗФайлуToolStripMenuItem_Click;
            проПрограмуToolStripMenuItem1.Click += проПрограмуToolStripMenuItem1_Click;
            допомогаToolStripMenuItem1.Click += допомогаToolStripMenuItem1_Click;
            вийтиToolStripMenuItem1.Click += вийтиToolStripMenuItem_Click;
            назадДоМенюToolStripMenuItem1.Click += назаддоМенюToolStripMenuItem_Click;
        }

        public void вийтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        public void обчислитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double i = 1, y = 1;
            listBox1.Items.Clear();
            while(y > precision)
            {
                y = Math.Pow(i, 2) / ((i+1)* Math.Pow(3,i));
                if (checkBox1.Checked)
                    listBox1.Items.Add($"i:\t{i.ToString("0.000")}\ty:\t{y.ToString("0.000")}");
                if(checkBox2.Checked)
                {
                    using (StreamWriter writer = new StreamWriter(filepath,true))
                    {
                        writer.WriteLine($"i:\t{i.ToString("0.000")}\ty:\t{y.ToString("0.000")}");
                        isFileEmpty = false;
                    }
                }
                i += precision;
            }
        }

        private void Task2Form_Load(object sender, EventArgs e)
        {
            StreamWriter writer = new StreamWriter(filepath);
            isFileEmpty = true;
        }

        public void прочитатиЗФайлуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if(isFileEmpty)
            {
                MessageBox.Show("Файл порожній", "Помилка введення", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (StreamReader reader = new StreamReader(filepath))
            {
                string m = reader.ReadToEnd();
                string[] lines = m.Split('\n');
                foreach(string line in lines)
                {
                    listBox1.Items.Add(line);
                }
            }

        }

        public void допомогаToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            HelpForm helpForm = new HelpForm();
            helpForm.Show();

            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            ContextMenuStrip contextMenu = (ContextMenuStrip)menuItem.Owner;
            Control control = contextMenu.SourceControl;
            Form currentForm = control.FindForm();
            currentForm.Hide();
        }
        public void проПрограмуToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutProgramForm aboutProgram = new AboutProgramForm();
            aboutProgram.Show();

            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            ContextMenuStrip contextMenu = (ContextMenuStrip)menuItem.Owner;
            Control control = contextMenu.SourceControl;
            Form currentForm = control.FindForm();
            currentForm.Hide();
        }
        public void назаддоМенюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();

            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            ContextMenuStrip contextMenu = (ContextMenuStrip)menuItem.Owner;
            Control control = contextMenu.SourceControl;
            Form currentForm = control.FindForm();
            currentForm.Close();
        }

    }
}
