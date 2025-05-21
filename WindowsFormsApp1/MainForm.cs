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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void NewTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var tableForm = new TableForm
            {
                MdiParent = this,
                Text = "Новая таблица " + (MdiChildren.Length + 1)
            };
            tableForm.Show();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openDialog = new OpenFileDialog
            {
                Filter = "Таблицы (*.table)|*.table|Все файлы (*.*)|*.*",
                Title = "Открыть таблицу"
            };

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var tableForm = new TableForm
                    {
                        MdiParent = this,
                        Text = Path.GetFileNameWithoutExtension(openDialog.FileName)
                    };
                    tableForm.LoadTable(openDialog.FileName);
                    tableForm.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при открытии файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Табличный редактор\nВерсия 1.0\n\nРедактор таблиц на определённую тему.", "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
