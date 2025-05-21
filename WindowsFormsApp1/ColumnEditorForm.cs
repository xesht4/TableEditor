using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TableEditor
{
    public partial class ColumnEditorForm : Form
    {
        public string ColumnName => textBoxName.Text;
        public Type ColumnType => (Type)comboBoxType.SelectedItem;

        public ColumnEditorForm()
        {
            InitializeComponent();

            // Добавляем основные типы данных
            comboBoxType.Items.Add(typeof(string));
            comboBoxType.Items.Add(typeof(int));
            comboBoxType.Items.Add(typeof(double));
            comboBoxType.Items.Add(typeof(DateTime));
            comboBoxType.Items.Add(typeof(bool));

            comboBoxType.SelectedIndex = 0;
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ColumnName))
            {
                MessageBox.Show("Введите название колонки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        
    }
}
