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
using System.Runtime.Serialization.Formatters.Binary;

namespace П1v2
{
    public partial class Task5Form : Form
    {
        public List<Worker> workersList = new List<Worker>();
        DataTable table = new DataTable();
        public Task5Form()
        {
            InitializeComponent();
        }

        private void Task5Form_Load(object sender, EventArgs e)
        {
            Task2Form task2 = new Task2Form();

            вийтиToolStripMenuItem.Click += task2.вийтиToolStripMenuItem_Click;
            допомогаToolStripMenuItem.Click += task2.допомогаToolStripMenuItem_Click;
            проПрограмуToolStripMenuItem.Click += task2.проПрограмуToolStripMenuItem_Click;

            вийтиToolStripMenuItem1.Click += task2.вийтиToolStripMenuItem_Click;
            допомогаToolStripMenuItem1.Click += task2.допомогаToolStripMenuItem1_Click;
            проПрограмуToolStripMenuItem1.Click += task2.проПрограмуToolStripMenuItem1_Click;

            textBox2.KeyPress += textBox_KeyPress;
        }

        private void зберегтиЯкToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void створитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateTable();
            dataGridView1.DataSource = table;
            dataGridView1.Refresh();
        }
        private void CreateTable()
        {
            if (!table.Columns.Contains("Прізвище"))
            {
                DataColumn lastName = new DataColumn();
                lastName.ColumnName = "Прізвище";
                lastName.DataType = Type.GetType("System.String");
                table.Columns.Add(lastName);
            }

            if (!table.Columns.Contains("Зарплата"))
            {
                DataColumn salary = new DataColumn();
                salary.ColumnName = "Зарплата";
                salary.DataType = Type.GetType("System.Int32");
                table.Columns.Add(salary);
            }

            if (!table.Columns.Contains("Стать"))
            {
                DataColumn sexColumn = new DataColumn();
                sexColumn.ColumnName = "Стать";
                sexColumn.DataType = Type.GetType("System.String");
                table.Columns.Add(sexColumn);
            }
        }
        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(saveFileDialog1.FileName))
            {
                MessageBox.Show("Не введено ім'я файлу");
                return;
            }

            using (FileStream fileStream = new FileStream(saveFileDialog1.FileName, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fileStream, workersList);
            }
        }


        private void відкритиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(openFileDialog1.FileName))
            {
                MessageBox.Show("Не обрано ім'я файлу");
                return;
            }
            using (FileStream fileStream = new FileStream(openFileDialog1.FileName, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                workersList = (List<Worker>)formatter.Deserialize(fileStream);

                CreateTable();
                foreach (Worker worker in workersList)
                {
                    table.Rows.Add(worker.lastName, worker.salary, worker.sex);
                }
            }

            dataGridView1.DataSource = table;
            dataGridView1.Refresh();
        }


        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && !(e.KeyChar == '-' && textBox.Text.Length == 0))
            {
                e.Handled = true;
            }
            else if (textBox.Text.Replace("-", "").Length >= 6 && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void очиститиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            table.Rows.Clear();
            dataGridView1.Refresh();
        }

        private void додатиЕлементToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource == null)
            {
                MessageBox.Show("Жодна таблиця не завантажена", "Помилка введення", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Не введено усіх значень", "Помилка введення", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string lastname, sex; int salary;

            lastname = textBox1.Text;
            salary = Convert.ToInt32(textBox2.Text);
            sex = Convert.ToString(comboBox1.SelectedItem);

            Worker worker = new Worker(lastname, salary, sex);
            workersList.Add(worker);
            table.Rows.Add(lastname, salary, sex);
            dataGridView1.Refresh();
        }

        private void видалитиЕлементToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string lastname, sex; int salary;

            lastname = textBox1.Text;
            salary = Convert.ToInt32(textBox2.Text);
            sex = Convert.ToString(comboBox1.SelectedItem);

            for(int i=0;i<workersList.Count;i++)
            {
                if(workersList[i].lastName.Equals(lastname) && workersList[i].salary == salary && workersList[i].sex.Equals(sex))
                {
                    workersList.RemoveAt(i);
                }
            }
            RefreshTable();
        }
        public void RefreshTable()
        {
            table.Rows.Clear();
            foreach(Worker worker in workersList)
            {
                table.Rows.Add(worker.lastName,worker.salary,worker.sex);
            }
            dataGridView1.Refresh();
        }
    }

    [Serializable]
    public struct Worker
    {
        public readonly string lastName;
        public readonly int salary;
        public readonly string sex;

        public Worker(string lastname, int salary, string sex)
        {
            this.lastName = lastname;
            this.salary = salary;
            this.sex = sex;
        }
    }
}
