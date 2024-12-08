using System.Windows.Forms;

namespace C__project
{
    partial class DailyReportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            SumProducts_DGV = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            Product = new DataGridViewTextBoxColumn();
            UnitPrice = new DataGridViewTextBoxColumn();
            Quantity = new DataGridViewTextBoxColumn();
            Price = new DataGridViewTextBoxColumn();
            TotalPrice_TextBox = new TextBox();
            TotalPrice_TB = new TextBox();
            ((System.ComponentModel.ISupportInitialize)SumProducts_DGV).BeginInit();
            SuspendLayout();
            // 
            // SumProducts_DGV
            // 
            SumProducts_DGV.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            SumProducts_DGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            SumProducts_DGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            SumProducts_DGV.Columns.AddRange(new DataGridViewColumn[] { ID, Product, UnitPrice, Quantity, Price });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Window;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            SumProducts_DGV.DefaultCellStyle = dataGridViewCellStyle2;
            SumProducts_DGV.Location = new Point(23, 12);
            SumProducts_DGV.Name = "SumProducts_DGV";
            SumProducts_DGV.ReadOnly = true;
            SumProducts_DGV.RowHeadersWidth = 51;
            SumProducts_DGV.Size = new Size(1238, 912);
            SumProducts_DGV.TabIndex = 0;
            // 
            // ID
            // 
            ID.HeaderText = "ID";
            ID.MinimumWidth = 6;
            ID.Name = "ID";
            ID.ReadOnly = true;
            ID.Width = 237;
            // 
            // Product
            // 
            Product.HeaderText = "Product";
            Product.MinimumWidth = 6;
            Product.Name = "Product";
            Product.ReadOnly = true;
            Product.Width = 237;
            // 
            // UnitPrice
            // 
            UnitPrice.HeaderText = "UnitPrice";
            UnitPrice.MinimumWidth = 6;
            UnitPrice.Name = "UnitPrice";
            UnitPrice.ReadOnly = true;
            UnitPrice.Width = 237;
            // 
            // Quantity
            // 
            Quantity.HeaderText = "Quantity";
            Quantity.MinimumWidth = 6;
            Quantity.Name = "Quantity";
            Quantity.ReadOnly = true;
            Quantity.Width = 237;
            // 
            // Price
            // 
            Price.HeaderText = "Price";
            Price.MinimumWidth = 6;
            Price.Name = "Price";
            Price.ReadOnly = true;
            Price.Width = 237;
            // 
            // TotalPrice_TextBox
            // 
            TotalPrice_TextBox.BorderStyle = BorderStyle.None;
            TotalPrice_TextBox.Font = new Font("Arial", 20F, FontStyle.Bold, GraphicsUnit.Point);
            TotalPrice_TextBox.Location = new Point(1395, 281);
            TotalPrice_TextBox.Name = "TotalPrice_TextBox";
            TotalPrice_TextBox.Size = new Size(220, 39);
            TotalPrice_TextBox.TabIndex = 1;
            TotalPrice_TextBox.Text = "TOTAL PRICE";
            TotalPrice_TextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // TotalPrice_TB
            // 
            TotalPrice_TB.BorderStyle = BorderStyle.None;
            TotalPrice_TB.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            TotalPrice_TB.Location = new Point(1343, 368);
            TotalPrice_TB.Name = "TotalPrice_TB";
            TotalPrice_TB.Size = new Size(317, 34);
            TotalPrice_TB.TabIndex = 2;
            TotalPrice_TB.TextAlign = HorizontalAlignment.Center;
            // 
            // DailyReportForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1705, 953);
            Controls.Add(TotalPrice_TB);
            Controls.Add(TotalPrice_TextBox);
            Controls.Add(SumProducts_DGV);
            FormBorderStyle = FormBorderStyle.None;
            Name = "DailyReportForm";
            Text = "DailyReportForm";
            WindowState = FormWindowState.Maximized;
            KeyDown += DailyReportForm_KeyDown;
            ((System.ComponentModel.ISupportInitialize)SumProducts_DGV).EndInit();
            ResumeLayout(false);
            PerformLayout();
            KeyPreview = true;
        }

        #endregion

        private DataGridView SumProducts_DGV;
        private TextBox TotalPrice_TextBox;
        private TextBox TotalPrice_TB;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Product;
        private DataGridViewTextBoxColumn UnitPrice;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewTextBoxColumn Price;
    }
}