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
        private DataTable table = new DataTable();
        private int selectedRowIndex = -1;
        private DataTable maleMinimumSalaryTable = new DataTable();
        private DataTable femaleMinimumSalaryTable = new DataTable();
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

            dataGridView1.CellClick += dataGridView1_CellClick;
            textBox2.KeyPress += textBox_KeyPress;
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

            if (!maleMinimumSalaryTable.Columns.Contains("Прізвище"))
            {
                DataColumn lastName = new DataColumn();
                lastName.ColumnName = "Прізвище";
                lastName.DataType = Type.GetType("System.String");
                maleMinimumSalaryTable.Columns.Add(lastName);
            }

            if (!maleMinimumSalaryTable.Columns.Contains("Зарплата"))
            {
                DataColumn salary = new DataColumn();
                salary.ColumnName = "Зарплата";
                salary.DataType = Type.GetType("System.Int32");
                maleMinimumSalaryTable.Columns.Add(salary);
            }

            if (!maleMinimumSalaryTable.Columns.Contains("Стать"))
            {
                DataColumn sexColumn = new DataColumn();
                sexColumn.ColumnName = "Стать";
                sexColumn.DataType = Type.GetType("System.String");
                maleMinimumSalaryTable.Columns.Add(sexColumn);
            }

            if (!femaleMinimumSalaryTable.Columns.Contains("Прізвище"))
            {
                DataColumn lastName = new DataColumn();
                lastName.ColumnName = "Прізвище";
                lastName.DataType = Type.GetType("System.String");
                femaleMinimumSalaryTable.Columns.Add(lastName);
            }

            if (!femaleMinimumSalaryTable.Columns.Contains("Зарплата"))
            {
                DataColumn salary = new DataColumn();
                salary.ColumnName = "Зарплата";
                salary.DataType = Type.GetType("System.Int32");
                femaleMinimumSalaryTable.Columns.Add(salary);
            }

            if (!femaleMinimumSalaryTable.Columns.Contains("Стать"))
            {
                DataColumn sexColumn = new DataColumn();
                sexColumn.ColumnName = "Стать";
                sexColumn.DataType = Type.GetType("System.String");
                femaleMinimumSalaryTable.Columns.Add(sexColumn);
            }
        }
        private void зберегтиЯкToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
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

            MessageBox.Show("Успішно збережено","Операція успішна",MessageBoxButtons.OK,MessageBoxIcon.Information);
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
            table.Rows.Clear();
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

            MessageBox.Show("Успішно відкрито файл","Операція успішна",MessageBoxButtons.OK,MessageBoxIcon.Information);
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
            if (workersList.Count == 0)
            {
                MessageBox.Show("Список порожній", "Помилка обчислень", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string lastname, sex;
            int salary;
            bool workerRemoved = false;

            lastname = textBox1.Text;
            salary = Convert.ToInt32(textBox2.Text);
            sex = Convert.ToString(comboBox1.SelectedItem);

            List<int> indicesToRemove = new List<int>();

            for (int i = 0; i < workersList.Count; i++)
            {
                if (workersList[i].lastName.Equals(lastname) && workersList[i].salary == salary && workersList[i].sex.Equals(sex))
                {
                    indicesToRemove.Add(i);
                    workerRemoved = true;
                }
            }

            for (int i = indicesToRemove.Count - 1; i >= 0; i--)
            {
                workersList.RemoveAt(indicesToRemove[i]);
            }

            RefreshTable();

            if (workerRemoved)
            {
                MessageBox.Show($"Успішно видалено робітників з прізвищем {lastname}", "Операція успішна", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Не знайдено робітників, що відповідають заданим параметрам", "Невдала операція", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
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

        private void обчислитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(workersList.Count == 0)
            {
                MessageBox.Show("Список порожній","Помилка обчислень",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            int maleMinimumWage = 999999, femaleMinimumWage = 999999;

            maleMinimumSalaryTable.Rows.Clear();
            femaleMinimumSalaryTable.Rows.Clear();

            foreach(Worker worker in workersList)
            {
                if(worker.sex.Equals("Чоловіча") && worker.salary < maleMinimumWage)
                {
                    maleMinimumWage = worker.salary;
                }
                if (worker.sex.Equals("Жіноча") && worker.salary < femaleMinimumWage)
                {
                    femaleMinimumWage = worker.salary;
                }
            }
            foreach(Worker worker in workersList)
            {
                if (worker.sex.Equals("Чоловіча") && worker.salary == maleMinimumWage)
                {
                    maleMinimumSalaryTable.Rows.Add(worker.lastName, worker.salary, worker.sex);
                }
                if (worker.sex.Equals("Жіноча") && worker.salary == femaleMinimumWage)
                {
                    femaleMinimumSalaryTable.Rows.Add(worker.lastName, worker.salary, worker.sex);
                }
            }
            if(maleMinimumWage == 999999)
            {
                MessageBox.Show("У списку немає жодного чоловіка","Операція невдала",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            else
            {
                dataGridView2.DataSource = maleMinimumSalaryTable;
                dataGridView2.Refresh();
            }

            if (femaleMinimumWage == 999999)
            {
                MessageBox.Show("У списку немає жодної жінки", "Операція невдала", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                dataGridView3.DataSource = femaleMinimumSalaryTable;
                dataGridView3.Refresh();
            }
        }

        private void редагуватиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex >= 0)
            {
                if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || comboBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("Не введено усіх значень", "Помилка введення", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string lastname = textBox1.Text;
                int salary = Convert.ToInt32(textBox2.Text);
                string sex = Convert.ToString(comboBox1.SelectedItem);

                Worker editedWorker = new Worker(lastname, salary, sex);
                workersList[selectedRowIndex] = editedWorker;
                RefreshTable();

                MessageBox.Show("Робітника успішно змінено", "Операція успішна", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Оберіть рядок для редагування", "Помилка вибору", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRowIndex = e.RowIndex;
            if (selectedRowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedRowIndex];
                textBox1.Text = Convert.ToString(selectedRow.Cells["Прізвище"].Value);
                textBox2.Text = Convert.ToString(selectedRow.Cells["Зарплата"].Value);
                comboBox1.SelectedItem = Convert.ToString(selectedRow.Cells["Стать"].Value);
            }
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
