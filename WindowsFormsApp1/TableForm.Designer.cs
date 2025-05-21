namespace TableEditor
{
    partial class TableForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveAsToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.addColumnToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.removeColumnToolStripButton = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 25);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(800, 425);
            this.dataGridView.TabIndex = 0;
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripButton,
            this.saveAsToolStripButton,
            this.toolStripSeparator,
            this.addColumnToolStripButton,
            this.removeColumnToolStripButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(800, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = global::TableEditor.Properties.Resources.save;
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "Сохранить";
            this.saveToolStripButton.Click += new System.EventHandler(this.SaveToolStripButton_Click);
            // 
            // saveAsToolStripButton
            // 
            this.saveAsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveAsToolStripButton.Image = global::TableEditor.Properties.Resources.saveas;
            this.saveAsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveAsToolStripButton.Name = "saveAsToolStripButton";
            this.saveAsToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveAsToolStripButton.Text = "Сохранить как...";
            this.saveAsToolStripButton.Click += new System.EventHandler(this.SaveAsToolStripButton_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // addColumnToolStripButton
            // 
            this.addColumnToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addColumnToolStripButton.Image = global::TableEditor.Properties.Resources.plus;
            this.addColumnToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addColumnToolStripButton.Name = "addColumnToolStripButton";
            this.addColumnToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.addColumnToolStripButton.Text = "Добавить колонку";
            this.addColumnToolStripButton.Click += new System.EventHandler(this.AddColumnToolStripButton_Click);
            // 
            // removeColumnToolStripButton
            // 
            this.removeColumnToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.removeColumnToolStripButton.Image = global::TableEditor.Properties.Resources.close;
            this.removeColumnToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.removeColumnToolStripButton.Name = "removeColumnToolStripButton";
            this.removeColumnToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.removeColumnToolStripButton.Text = "Удалить колонку";
            this.removeColumnToolStripButton.Click += new System.EventHandler(this.RemoveColumnToolStripButton_Click);
            // 
            // TableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.toolStrip);
            this.Name = "TableForm";
            this.Text = "TableForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TableForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripButton saveAsToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton addColumnToolStripButton;
        private System.Windows.Forms.ToolStripButton removeColumnToolStripButton;
    }
}