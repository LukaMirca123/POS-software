using System.Windows.Forms;

namespace C__project
{
    partial class AdminForm
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
            Products = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            Product = new DataGridViewTextBoxColumn();
            UnitPrice = new DataGridViewTextBoxColumn();
            Quantity = new DataGridViewTextBoxColumn();
            AddButton = new Button();
            BackButton = new Button();
            EditButton = new Button();
            RemoveButton = new Button();
            ((System.ComponentModel.ISupportInitialize)Products).BeginInit();
            SuspendLayout();
            // 
            // Products
            // 
            Products.AllowUserToAddRows = false;
            Products.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Arial", 11F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            Products.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            Products.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Products.Columns.AddRange(new DataGridViewColumn[] { ID, Product, UnitPrice, Quantity });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Arial Narrow", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = Color.LightBlue;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            Products.DefaultCellStyle = dataGridViewCellStyle2;
            Products.EnableHeadersVisualStyles = false;
            Products.Location = new Point(28, 39);
            Products.Margin = new Padding(2, 3, 2, 3);
            Products.MultiSelect = false;
            Products.Name = "Products";
            Products.ReadOnly = true;
            Products.RowHeadersVisible = false;
            Products.RowHeadersWidth = 51;
            Products.RowTemplate.Height = 29;
            Products.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Products.Size = new Size(1506, 854);
            Products.TabIndex = 0;
            // 
            // AddButton
            // 
            AddButton.BackColor = Color.MediumSeaGreen;
            AddButton.Font = new Font("Arial", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            AddButton.ForeColor = Color.White;
            AddButton.Location = new Point(1593, 39);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(245, 113);
            AddButton.TabIndex = 1;
            AddButton.Text = "Add Product";
            AddButton.UseVisualStyleBackColor = false;
            AddButton.Click += AddButton_Click;
            // 
            // BackButton
            // 
            BackButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            BackButton.Image = Properties.Resources.circle_left_solid;
            BackButton.Location = new Point(28, 945);
            BackButton.Name = "BackButton";
            BackButton.Size = new Size(39, 41);
            BackButton.TabIndex = 2;
            BackButton.UseVisualStyleBackColor = true;
            BackButton.Click += BackButton_Click;
            // 
            // EditButton
            // 
            EditButton.BackColor = Color.MediumSeaGreen;
            EditButton.Font = new Font("Arial", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            EditButton.ForeColor = Color.White;
            EditButton.Location = new Point(1593, 192);
            EditButton.Name = "EditButton";
            EditButton.Size = new Size(245, 113);
            EditButton.TabIndex = 3;
            EditButton.Text = "Edit Product";
            EditButton.UseVisualStyleBackColor = false;
            EditButton.Click += EditButton_Click;
            // 
            // RemoveButton
            // 
            RemoveButton.BackColor = Color.MediumSeaGreen;
            RemoveButton.Font = new Font("Arial", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            RemoveButton.ForeColor = Color.White;
            RemoveButton.Location = new Point(1593, 350);
            RemoveButton.Name = "RemoveButton";
            RemoveButton.Size = new Size(245, 113);
            RemoveButton.TabIndex = 4;
            RemoveButton.Text = "Remove Product";
            RemoveButton.UseVisualStyleBackColor = false;
            RemoveButton.Click += RemoveButton_Click;
            // 
            // ID
            // 
            ID.HeaderText = "  ID";
            ID.MinimumWidth = 6;
            ID.Name = "ID";
            ID.ReadOnly = true;
            ID.Width = 320;
            // 
            // Product
            // 
            Product.HeaderText = "  Product";
            Product.MinimumWidth = 6;
            Product.Name = "Product";
            Product.ReadOnly = true;
            Product.Width = 394;
            // 
            // UnitPrice
            // 
            UnitPrice.HeaderText = "  UnitPrice";
            UnitPrice.MinimumWidth = 6;
            UnitPrice.Name = "UnitPrice";
            UnitPrice.ReadOnly = true;
            UnitPrice.Width = 394;
            // 
            // Quantity
            // 
            Quantity.HeaderText = "  Quantity";
            Quantity.MinimumWidth = 6;
            Quantity.Name = "Quantity";
            Quantity.ReadOnly = true;
            Quantity.Width = 394;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1878, 998);
            Controls.Add(RemoveButton);
            Controls.Add(EditButton);
            Controls.Add(BackButton);
            Controls.Add(AddButton);
            Controls.Add(Products);
            Font = new Font("Arial Narrow", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Name = "AdminForm";
            ShowIcon = false;
            Text = "ADMIN";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)Products).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView Products;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Product;
        private DataGridViewTextBoxColumn UnitPrice;
        private DataGridViewTextBoxColumn Quantity;
        private Button AddButton;
        private Button BackButton;
        private Button EditButton;
        private Button RemoveButton;
    }
}