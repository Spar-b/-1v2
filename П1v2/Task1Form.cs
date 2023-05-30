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
    public partial class Task1Form : Form
    {
        private double g = 9.8;
        public Task1Form()
        {
            InitializeComponent();
            
        }

        private void вийтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        public void назаддоМенюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuForm menuForm = new MenuForm();
            menuForm.Show();

            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            Form currentForm = (Form)menuItem.GetCurrentParent().FindForm(); 
            currentForm.Close();
        }
        public void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '\b')
            {
                e.Handled = true; 
            }
            else if (e.KeyChar == ',' && (textBox.Text.Contains(',') || textBox.Text.Length == 0))
            {
                e.Handled = true;
            }
            else if (char.IsDigit(e.KeyChar) && textBox.Text.Contains(','))
            {
                int commaIndex = textBox.Text.IndexOf(',');
                int digitsAfterComma = textBox.Text.Length - commaIndex - 1;

                if (digitsAfterComma >= 3)
                {
                    e.Handled = true;
                }
            }
            else if (textBox.Text.Length >= 10 && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("Не введено значення у текстове поле", "Помилка введення",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    {
                        label1.Text = "Початкова швидкість (м/с)";
                        label2.Text = "Висота підйому (м)";
                        double v = Convert.ToDouble(textBox1.Text);
                        double result = (v * v) / (2 * g);
                        textBox2.Text = result.ToString("0.000");
                    }
                    break;
                case 1:
                    {
                        label1.Text = "Висота підйому (м)";
                        label2.Text = "Початкова швидкість (м/с)";
                        double h = Convert.ToDouble(textBox1.Text);
                        double result = Math.Sqrt(2 * g * h);
                        textBox2.Text = result.ToString("0.000");
                    }
                    break;
                case 2:
                    {
                        label1.Text = "Висота підйому (м)";
                        label2.Text = "Час підйому (с)";
                        double h = Convert.ToDouble(textBox1.Text);
                        double result;
                        if (h == 0)
                        {
                            MessageBox.Show("Помилка, ділення на нуль", "Помилка обрахунків",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else result = Math.Sqrt(2 * g) / h;
                        textBox2.Text = result.ToString("0.000");
                    }
                    break;
                case 3:
                    {
                        label1.Text = "Час підйому (с)";
                        label2.Text = "Висота підйому (м)";
                        double t = Convert.ToDouble(textBox1.Text);
                        double result = 0.5 * g * t * t;
                        textBox2.Text = result.ToString("0.000");
                    }
                    break;
            }
        }

        private void Task1Form_Load(object sender, EventArgs e)
        {
            textBox1.KeyPress += textBox_KeyPress;
            MenuForm menuForm = new MenuForm();
            допомогаToolStripMenuItem.Click += допомогаToolStripMenuItem_Click;

            Task2Form task2 = new Task2Form();
            проПрограмуToolStripMenuItem1.Click += task2.проПрограмуToolStripMenuItem1_Click;
            допомогаToolStripMenuItem1.Click += task2.допомогаToolStripMenuItem1_Click;
            вийтиToolStripMenuItem1.Click += task2.вийтиToolStripMenuItem_Click;

            label1.Text = null;
            label2.Text = null;
            label3.Text = "Завдання №1:\na) висота підйому тіла, кинутого вертикально вгору\nб) початкова швидкість тіла, кинутого вертикально вгору, висота підйому якого дорівнює h\nв) час підйому тіла \nг) висота підйому тіла\nПримітка: Прискорення вільного падіння g = 9,8 м / сек2";

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
    }
}
