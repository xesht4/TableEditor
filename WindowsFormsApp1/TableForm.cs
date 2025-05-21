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

namespace TableEditor
{
    public partial class TableForm : Form
    {
        private DataTable _dataTable;
        private string _currentFilePath;
        private bool _isModified = true;
        private void DataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            _isModified = true;
        }

        public TableForm()
        {
            InitializeComponent();
            InitializeNewTable("Книги"); // Тема: Книги
            // Настройка обработки ошибок
            dataGridView.DataError += DataGridView_DataError;
        }

        private void InitializeNewTable(string tableName)
        {
            _dataTable = new DataTable(tableName);

            // Стандартные колонки для темы "Книги"
            _dataTable.Columns.Add("ID", typeof(int));
            _dataTable.Columns.Add("Название", typeof(string));
            _dataTable.Columns.Add("Автор", typeof(string));
            _dataTable.Columns.Add("Год издания", typeof(int));
            _dataTable.Columns.Add("Жанр", typeof(string));
            _dataTable.Columns.Add("Рейтинг", typeof(double));

            dataGridView.DataSource = _dataTable;
            dataGridView.AllowUserToAddRows = true;
        }

        public void LoadTable(string filePath)
        {
            try
            {
                _dataTable = new DataTable();
                _dataTable.ReadXml(filePath);
                dataGridView.DataSource = _dataTable;
                _currentFilePath = filePath;
                Text = Path.GetFileNameWithoutExtension(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке таблицы: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveTable(string filePath)
        {
            try
            {
                _dataTable.WriteXml(filePath, XmlWriteMode.WriteSchema);
                _currentFilePath = filePath;
                Text = Path.GetFileNameWithoutExtension(filePath);
                _isModified = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении таблицы: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveToolStripButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentFilePath))
            {
                SaveAsToolStripButton_Click(sender, e);
            }
            else
            {
                SaveTable(_currentFilePath);
            }
        }

        private void SaveAsToolStripButton_Click(object sender, EventArgs e)
        {
            var saveDialog = new SaveFileDialog
            {
                Filter = "Таблицы (*.table)|*.table|Все файлы (*.*)|*.*",
                Title = "Сохранить таблицу",
                DefaultExt = "table"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                SaveTable(saveDialog.FileName);
            }
        }

        private void AddColumnToolStripButton_Click(object sender, EventArgs e)
        {
            var columnDialog = new ColumnEditorForm();
            if (columnDialog.ShowDialog() == DialogResult.OK)
            {
                _dataTable.Columns.Add(columnDialog.ColumnName, columnDialog.ColumnType);
            }
        }

        private void RemoveColumnToolStripButton_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentCell != null)
            {
                var columnName = dataGridView.Columns[dataGridView.CurrentCell.ColumnIndex].Name;
                if (MessageBox.Show($"Удалить колонку '{columnName}'?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _dataTable.Columns.Remove(columnName);
                }
            }
            else
            {
                MessageBox.Show("Выберите колонку для удаления", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void TableForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isModified)
            {
                var result = MessageBox.Show("Сохранить изменения перед закрытием?", "Подтверждение", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    SaveToolStripButton_Click(sender, e);
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }
        private void DataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
            e.ThrowException = false;

            int row = e.RowIndex;
            int col = e.ColumnIndex;

            if (dataGridView.IsCurrentCellDirty)
            {
                dataGridView.CancelEdit();
                
                dataGridView.InvalidateCell(col, row);
            }
            
            MessageBox.Show($"Невозможно сохранить значение.\n" +
                          $"Ожидается: {dataGridView.Columns[col].ValueType.Name}\n" +
                          $"Введено: {dataGridView[col, row].EditedFormattedValue}",
                          "Ошибка ввода",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Error);
        }
    }
}