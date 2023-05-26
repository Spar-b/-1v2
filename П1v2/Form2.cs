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
    public partial class Form2 : Form
    {
        private double g = 9.8;
        public Form2()
        {
            InitializeComponent();
            textBox1.KeyPress += textBox_KeyPress;
        }

        private void вийтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void назаддоМенюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();

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

        private void обрахуватиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Не обрано величину для обрахунку","Помилка введення",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if(textBox1.Text.Length == 0)
            {
                MessageBox.Show("Не введено значення у текстове поле", "Помилка введення", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            switch(comboBox1.SelectedIndex)
            {
                case 0:
                    {
                        double v = Convert.ToDouble(textBox1.Text);
                        double result = (v * v) / (2 * g);
                        textBox2.Text = result.ToString("0.000");
                    }break;
                case 1:
                    {
                        double h = Convert.ToDouble(textBox1.Text);
                        double result = Math.Sqrt(2 * g * h);
                        textBox2.Text = result.ToString("0.000");
                    }
                    break;
                case 2:
                    {
                        double h = Convert.ToDouble(textBox1.Text);
                        double result;
                        if (h == 0)
                        {
                            MessageBox.Show("Помилка, ділення на нуль","Помилка обрахунків", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else result = Math.Sqrt(2 * g) / h;
                        textBox2.Text = result.ToString("0.000");
                    }
                    break;
                case 3:
                    {
                        double t = Convert.ToDouble(textBox1.Text);
                        double result = 0.5 * g * t * t;
                        textBox2.Text = result.ToString("0.000");
                    }
                    break;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = null;
            label2.Text = null;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(comboBox1.SelectedIndex)
            {
                case 0:
                    {
                        label1.Text = "Початкова швидкість (м/с)";
                        label2.Text = "Висота підйому (м)";
                    }break;
                case 1:
                    {
                        label1.Text = "Висота підйому (м)";
                        label2.Text = "Початкова швидкість (м/с)";
                    }
                    break;
                case 2:
                    {
                        label1.Text = "Висота підйому (м)";
                        label2.Text = "Час підйому (с)";
                    }
                    break;
                case 3:
                    {
                        label1.Text = "Час підйому (с)";
                        label2.Text = "Висота підйому (м)";
                    }
                    break;

            }
        }

        private void допомогаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Оберіть бажану дію та введіть відповідні вхідні дані, " +
                "після того натисніть 'Обчислити'","Допомога",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void проПрограмуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.проПрограмуToolStripMenuItem_Click(sender, e);
        }
    }
}
