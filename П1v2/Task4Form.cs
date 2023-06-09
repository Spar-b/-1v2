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
    public partial class Task4Form : Form
    {
        public List<List<int>> list = new List<List<int>>();

        public int leftConditionBound = 1;
        public int rightConditionBound = 6;
        public Task4Form()
        {
            InitializeComponent();
        }

        private void Task4Form_Load(object sender, EventArgs e)
        {
            Task2Form task2 = new Task2Form();
            проПрограмуToolStripMenuItem.Click += task2.проПрограмуToolStripMenuItem_Click;
            допомогаToolStripMenuItem.Click += task2.допомогаToolStripMenuItem_Click;
            вийтиToolStripMenuItem.Click += task2.вийтиToolStripMenuItem_Click;

            проПрограмуToolStripMenuItem1.Click += task2.проПрограмуToolStripMenuItem1_Click;
            допомогаToolStripMenuItem1.Click += task2.допомогаToolStripMenuItem1_Click;
            вийтиToolStripMenuItem1.Click += task2.вийтиToolStripMenuItem_Click;

            очиститиСписокToolStripMenuItem.Click += очиститиСписокToolStripMenuItem_Click;
            очиститиСписокToolStripMenuItem1.Click += очиститиСписокToolStripMenuItem_Click;
            обчислитиToolStripMenuItem1.Click += обчислитиToolStripMenuItem_Click;

            textBox2.KeyPress += textBox1_KeyPress;
            textBox3.KeyPress += textBox1_KeyPress;
            textBox4.KeyPress += textBox1_KeyPress;
            textBox5.KeyPress += textBox1_KeyPress;
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && !(e.KeyChar == '-' && textBox.Text.Length == 0))
            {
                e.Handled = true;
            }
            else if (textBox.Text.Replace("-", "").Length >= 3 && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox2.Text.Length == 0||textBox3.Text.Length == 0|| textBox4.Text.Length ==0 || textBox5.Text.Length == 0)
            {
                MessageBox.Show("Не введено параметри швидкого заповнення", "Помилка введення", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            listBox1.Items.Clear();
            list.Clear();

            int item;
            string row = "";
            int leftBound = int.Parse(textBox2.Text);
            int rightBound = int.Parse(textBox3.Text);
            int numRows = int.Parse(textBox4.Text);
            int numCols = int.Parse(textBox5.Text);

            Random rn = new Random();

            for(int i =0;i<numRows;i++)
            {
                List<int> rowList = new List<int>();
                for(int j = 0;j<numCols;j++)
                {
                    item = rn.Next(leftBound, rightBound + 1);
                    row += $"{item}\t";
                    rowList.Add(item);
                }
                list.Add(rowList);
                listBox1.Items.Add(row);
                row = "";
            }
        }

        private void обчислитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(list.Count == 0)
            {
                MessageBox.Show("Список порожній", "Помилка виводу", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int conditionNum = 0;
            foreach(List<int> row in list)
            {
                foreach(int item in row)
                {
                    if(item > leftConditionBound && item < rightConditionBound)
                    {
                        conditionNum++;
                    }
                }
            }
            textBox1.Text = conditionNum.ToString();
        }

        private void очиститиСписокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            list.Clear();
            textBox1.Text = null;
        }
    }
}
