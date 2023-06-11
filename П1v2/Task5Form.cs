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
    public partial class Task5Form : Form
    {
        DataTable table = new DataTable();
        DataSet enterData = new DataSet();
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

            dataGridView1.CellValidating += dataGridView1_CellValidating;
            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
        }

        private void зберегтиЯкToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            
        }

        private void створитиToolStripMenuItem_Click(object sender, EventArgs e)
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

            dataGridView1.DataSource = table;
            dataGridView1.Refresh();
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string newCellValue = e.FormattedValue.ToString();

            if (string.IsNullOrWhiteSpace(newCellValue))
            {
                dataGridView1.Rows[e.RowIndex].ErrorText = "Please enter a value in the cell.";
                e.Cancel = true;
            }

            if (e.ColumnIndex == dataGridView1.Columns["Зарплата"].Index)
            {
                if (!int.TryParse(newCellValue, out int salary))
                {
                    dataGridView1.Rows[e.RowIndex].ErrorText = "Please enter a valid integer value.";
                    e.Cancel = true;
                }
            }
        }
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if (string.IsNullOrWhiteSpace(cell.Value?.ToString()))
            {
                dataGridView1.Rows[e.RowIndex].ErrorText = "Please enter a value in the cell.";
            }
            else
            {
                dataGridView1.Rows[e.RowIndex].ErrorText = string.Empty;
            }
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(saveFileDialog1.FileName))
            {
                MessageBox.Show("Не введено ім'я файлу");
                return;
            }
            table.TableName = "База даних";
            enterData.WriteXml(saveFileDialog1.FileName);
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

            enterData.ReadXml(openFileDialog1.FileName);
            string XMLstring = enterData.GetXml();

            if (enterData.Tables.Count > 0)
            {
                table = enterData.Tables[0];
                dataGridView1.DataSource = table;
            }
        }

    }
}
