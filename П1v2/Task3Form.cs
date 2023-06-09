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
    public partial class Task3Form : Form
    {
        List<int> temperatureList = new List<int>();
        private string currentMonth;
        public Task3Form()
        {
            InitializeComponent();
        }

        private void Task3Form_Load(object sender, EventArgs e)
        {
            Task2Form task2 = new Task2Form();
            проПрограмуToolStripMenuItem.Click += task2.проПрограмуToolStripMenuItem_Click;
            допомогаToolStripMenuItem.Click += task2.допомогаToolStripMenuItem_Click;
            вийтиToolStripMenuItem.Click += task2.вийтиToolStripMenuItem_Click;

            обчислитиToolStripMenuItem1.Click += обчислитиToolStripMenuItem_Click;
            проПрограмуToolStripMenuItem1.Click += task2.проПрограмуToolStripMenuItem1_Click;
            допомогаToolStripMenuItem1.Click += task2.допомогаToolStripMenuItem1_Click;
            вийтиToolStripMenuItem1.Click += task2.вийтиToolStripMenuItem_Click;

            label2.Text = null;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && !(e.KeyChar == '-' && textBox.Text.Length == 0))
            {
                e.Handled = true;
            }
            else if (textBox.Text.Replace("-", "").Length >= 2 && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length == 0)
            {
                MessageBox.Show("Не введено значення","Помилка введення",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            int value = Convert.ToInt32(textBox1.Text);

            temperatureList.Add(value);
            listBox1.Items.Add(temperatureList.Count.ToString() + ":\t" + value.ToString());


            textBox1.Text = null;
        }

        public void очиститиСписокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            temperatureList.Clear();

            MessageBox.Show("Список успішно очищено","Очищення",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        }

        private void обчислитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label2.Text = null;
            if(temperatureList.Count==0)
            {
                MessageBox.Show("Список порожній","Помилка обчислень",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (comboBox1.SelectedIndex == -1)
                currentMonth = "Вересень";
            else
                currentMonth = comboBox1.SelectedItem.ToString();

            int maxTemperature = -999;
            double averageTemperature = temperatureList.Average();
            bool multipleMaxTemperature = false;
            List<int> maxTemperatureIndexes = new List<int>();

            int currentIndex = 0;
            foreach (int temperature in temperatureList)
            {
                if (temperature > maxTemperature)
                {
                    maxTemperature = temperature;
                    maxTemperatureIndexes.Clear();
                    maxTemperatureIndexes.Add(currentIndex);
                    multipleMaxTemperature = false;
                }
                else if (temperature == maxTemperature)
                {
                    multipleMaxTemperature = true;
                    maxTemperatureIndexes.Add(currentIndex);
                }
                currentIndex++;
            }

            string warmestDayString;
            if (!multipleMaxTemperature)
            {
                warmestDayString = $"Найтепліший день: {currentMonth} {maxTemperatureIndexes[0] + 1}\n";
            }
            else
            {
                warmestDayString = $"Найтепліші дні: {currentMonth} ";
                warmestDayString += string.Join(", ", maxTemperatureIndexes.Select(index => (index + 1).ToString()));
                warmestDayString = warmestDayString.TrimEnd(',', ' ') + "\n";
            }

            label2.Text = $"{warmestDayString}" +
                    $"Максимальна температура: {maxTemperature}\n" +
                    $"Середня температура: {averageTemperature.ToString("0.00")}";


        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
            else if (textBox.Text.Length >= 2 && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        public void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Enabled = radioButton1.Checked;
            groupBox1.Enabled = radioButton2.Checked;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            temperatureList.Clear();

            int leftBound, rightBound, num, value;

            Random rd = new Random();
            leftBound = Convert.ToInt32(textBox2.Text);
            rightBound = Convert.ToInt32(textBox3.Text);
            num = Convert.ToInt32(textBox4.Text);

            for(int i=0;i<num;i++)
            {
                value = rd.Next(leftBound,rightBound+1);
                temperatureList.Add(value);
                listBox1.Items.Add(temperatureList.Count.ToString() + ":\t" + value.ToString());
            }
        }
    }
}
