namespace C__project
{
    partial class WorkerForm
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            Timer = new System.Windows.Forms.Timer(components);
            ProductsDGV = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            Product = new DataGridViewTextBoxColumn();
            UnitPrice = new DataGridViewTextBoxColumn();
            Quantity = new DataGridViewTextBoxColumn();
            Price = new DataGridViewTextBoxColumn();
            Remove = new DataGridViewButtonColumn();
            BarCodeTB = new TextBox();
            TotalPrice_TB = new TextBox();
            TP_textBox = new TextBox();
            SalesReport_Button = new Button();
            ButtonBack = new Button();
            ListOfProducts = new ListBox();
            SearchTB = new TextBox();
            ((System.ComponentModel.ISupportInitialize)ProductsDGV).BeginInit();
            SuspendLayout();
            // 
            // Timer
            // 
            Timer.Enabled = true;
            Timer.Tick += Timer_Tick;
            // 
            // ProductsDGV
            // 
            ProductsDGV.AllowUserToAddRows = false;
            ProductsDGV.BackgroundColor = Color.Blue;
            ProductsDGV.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Arial Black", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.Purple;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = Color.Purple;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            ProductsDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            ProductsDGV.ColumnHeadersHeight = 29;
            ProductsDGV.Columns.AddRange(new DataGridViewColumn[] { ID, Product, UnitPrice, Quantity, Price, Remove });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Arial Black", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Window;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            ProductsDGV.DefaultCellStyle = dataGridViewCellStyle2;
            ProductsDGV.EnableHeadersVisualStyles = false;
            ProductsDGV.Location = new Point(12, 92);
            ProductsDGV.Name = "ProductsDGV";
            ProductsDGV.RowHeadersVisible = false;
            ProductsDGV.RowHeadersWidth = 51;
            ProductsDGV.RowTemplate.Height = 29;
            ProductsDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ProductsDGV.Size = new Size(1844, 744);
            ProductsDGV.TabIndex = 0;
            ProductsDGV.CellContentClick += Podaci_DGV_CellContentClick;
            ProductsDGV.KeyDown += Podaci_DGV_KeyDown;
            // 
            // ID
            // 
            ID.HeaderText = "ID";
            ID.MinimumWidth = 6;
            ID.Name = "ID";
            ID.ReadOnly = true;
            ID.Width = 350;
            // 
            // Product
            // 
            Product.HeaderText = "Product";
            Product.MinimumWidth = 6;
            Product.Name = "Product";
            Product.ReadOnly = true;
            Product.Width = 500;
            // 
            // UnitPrice
            // 
            UnitPrice.HeaderText = "Unit Price";
            UnitPrice.MinimumWidth = 6;
            UnitPrice.Name = "UnitPrice";
            UnitPrice.ReadOnly = true;
            UnitPrice.Width = 270;
            // 
            // Quantity
            // 
            Quantity.HeaderText = "Quantity";
            Quantity.MinimumWidth = 6;
            Quantity.Name = "Quantity";
            Quantity.ReadOnly = true;
            Quantity.Width = 230;
            // 
            // Price
            // 
            Price.HeaderText = "Price";
            Price.MinimumWidth = 6;
            Price.Name = "Price";
            Price.ReadOnly = true;
            Price.Width = 270;
            // 
            // Remove
            // 
            Remove.HeaderText = "";
            Remove.MinimumWidth = 10;
            Remove.Name = "Remove";
            Remove.ReadOnly = true;
            Remove.Text = "";
            Remove.Width = 80;
            // 
            // BarCodeTB
            // 
            BarCodeTB.Location = new Point(120, 928);
            BarCodeTB.Name = "BarCodeTB";
            BarCodeTB.Size = new Size(203, 31);
            BarCodeTB.TabIndex = 1;
            BarCodeTB.KeyDown += BarCodeTB_KeyDown;
            // 
            // TotalPrice_TB
            // 
            TotalPrice_TB.BackColor = Color.Blue;
            TotalPrice_TB.BorderStyle = BorderStyle.None;
            TotalPrice_TB.ForeColor = Color.White;
            TotalPrice_TB.Location = new Point(1246, 808);
            TotalPrice_TB.Name = "TotalPrice_TB";
            TotalPrice_TB.Size = new Size(141, 24);
            TotalPrice_TB.TabIndex = 3;
            TotalPrice_TB.Text = "Total Price : ";
            // 
            // TP_textBox
            // 
            TP_textBox.Location = new Point(1363, 805);
            TP_textBox.Name = "TP_textBox";
            TP_textBox.Size = new Size(270, 31);
            TP_textBox.TabIndex = 4;
            TP_textBox.Text = "0.00";
            TP_textBox.TextAlign = HorizontalAlignment.Center;
            // 
            // SalesReport_Button
            // 
            SalesReport_Button.Location = new Point(1669, 906);
            SalesReport_Button.Name = "SalesReport_Button";
            SalesReport_Button.Size = new Size(230, 49);
            SalesReport_Button.TabIndex = 5;
            SalesReport_Button.Text = "Daily Sales Report";
            SalesReport_Button.UseVisualStyleBackColor = true;
            SalesReport_Button.Click += SalesReport_Button_Click;
            // 
            // ButtonBack
            // 
            ButtonBack.BackColor = Color.Blue;
            ButtonBack.FlatAppearance.BorderSize = 0;
            ButtonBack.Image = Properties.Resources.circle_left_solid;
            ButtonBack.Location = new Point(12, 919);
            ButtonBack.Name = "ButtonBack";
            ButtonBack.Size = new Size(39, 40);
            ButtonBack.TabIndex = 6;
            ButtonBack.UseVisualStyleBackColor = false;
            ButtonBack.Click += ButtonBack_Click;
            // 
            // ListOfProducts
            // 
            ListOfProducts.FormattingEnabled = true;
            ListOfProducts.ItemHeight = 24;
            ListOfProducts.Location = new Point(331, 17);
            ListOfProducts.Name = "ListOfProducts";
            ListOfProducts.Size = new Size(197, 28);
            ListOfProducts.TabIndex = 7;
            ListOfProducts.SelectedIndexChanged += ListOfProducts_SelectedIndexChanged;
            // 
            // SearchTB
            // 
            SearchTB.Location = new Point(97, 17);
            SearchTB.Name = "SearchTB";
            SearchTB.Size = new Size(202, 31);
            SearchTB.TabIndex = 8;
            // 
            // WorkerForm
            // 
            AutoScaleDimensions = new SizeF(12F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Blue;
            ClientSize = new Size(1924, 980);
            Controls.Add(SearchTB);
            Controls.Add(ListOfProducts);
            Controls.Add(ButtonBack);
            Controls.Add(SalesReport_Button);
            Controls.Add(TP_textBox);
            Controls.Add(TotalPrice_TB);
            Controls.Add(BarCodeTB);
            Controls.Add(ProductsDGV);
            Font = new Font("Arial Black", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(5);
            Name = "WorkerForm";
            Text = "Time:  09:57:23   13-11-2024";
            Load += WorkerForm_Load;
            ((System.ComponentModel.ISupportInitialize)ProductsDGV).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Timer Timer;
        private DataGridView ProductsDGV;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Product;
        private DataGridViewTextBoxColumn UnitPrice;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewTextBoxColumn Price;
        private DataGridViewButtonColumn Remove;
        private TextBox BarCodeTB;
        private TextBox TotalPrice_TB;
        private TextBox TP_textBox;
        private Button SalesReport_Button;
        private Button ButtonBack;
        private ListBox ListOfProducts;
        private TextBox SearchTB;
    }
}