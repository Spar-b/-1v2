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
            проПрограмуToolStripMenuItem.Click += проПрограмуToolStripMenuItem_Click;
            допомогаToolStripMenuItem.Click += допомогаToolStripMenuItem_Click;


            обчислитиToolStripMenuItem1.Click += обчислитиToolStripMenuItem_Click;
            прочитатиЗФайлуToolStripMenuItem1.Click += прочитатиЗФайлуToolStripMenuItem_Click;
            проПрограмуToolStripMenuItem1.Click += проПрограмуToolStripMenuItem1_Click;
            допомогаToolStripMenuItem1.Click += допомогаToolStripMenuItem1_Click;
            вийтиToolStripMenuItem1.Click += вийтиToolStripMenuItem_Click;
        }

        public void вийтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        public void проПрограмуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutProgramForm aboutProgram = new AboutProgramForm();
            aboutProgram.Show();

            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            Form currentForm = (Form)menuItem.GetCurrentParent().FindForm();
            currentForm.Hide();
        }

        public void допомогаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpForm helpForm = new HelpForm();
            helpForm.Show();

            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            Form currentForm = (Form)menuItem.GetCurrentParent().FindForm();
            currentForm.Hide();
        }
        public void обчислитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double y,sum=0;int i = 1;
            using (StreamWriter w = new StreamWriter(filepath))
            {
                w.WriteLine("i\ty");
            }
            listBox1.Items.Clear();
            if (checkBox1.Checked)
                listBox1.Items.Add("i\ty");
            y = Math.Pow(i, 2) / ((i + 1) * Math.Pow(3, i));
            while (y > precision)
            {
                y = Math.Pow(i, 2) / ((i + 1) * Math.Pow(3, i));
                sum += y;
                if (checkBox1.Checked)
                    listBox1.Items.Add($"{i}\t{y.ToString("0.000")}");
                if (checkBox2.Checked)
                {
                    using (StreamWriter writer = new StreamWriter(filepath, true))
                    {
                        writer.WriteLine($"{i}\t{y.ToString("0.000")}");
                        isFileEmpty = false;
                    }
                }
                i++;
            }
            if (checkBox1.Checked) textBox1.Text = sum.ToString("0.000");
            if (checkBox2.Checked)
            {
                using (StreamWriter writer = new StreamWriter(filepath, true))
                {
                    writer.WriteLine($"{sum.ToString("0.000")}");
                }
            }
        }

        private void Task2Form_Load(object sender, EventArgs e)
        {
            using (StreamWriter writer = new StreamWriter(filepath))
            {

            }
            isFileEmpty = true;
        }

        public void прочитатиЗФайлуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (isFileEmpty)
            {
                MessageBox.Show("Файл порожній", "Помилка введення", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (StreamReader reader = new StreamReader(filepath))
            {
                string content = reader.ReadToEnd();
                string[] lines = content.Split('\n');
                int numLines = lines.Length;
                for (int i = 0; i < numLines; i++)
                {
                    if (i == numLines - 2)
                        textBox1.Text = lines[i].Trim();
                    else
                        listBox1.Items.Add(lines[i].Trim());
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
            MenuForm menuForm = new MenuForm();
            menuForm.Show();

            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            ContextMenuStrip contextMenu = (ContextMenuStrip)menuItem.Owner;
            Control control = contextMenu.SourceControl;
            Form currentForm = control.FindForm();
            currentForm.Close();
        }

    }
}
