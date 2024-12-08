namespace C__project
{
    partial class AddEditProductForm
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
            IDTB = new TextBox();
            ProductNameTB = new TextBox();
            QuantityTB = new TextBox();
            UnitPriceTB = new TextBox();
            InputID = new TextBox();
            InputProduct = new TextBox();
            InputQuantity = new TextBox();
            InputUnitPrice = new TextBox();
            OKButton = new Button();
            SuspendLayout();
            // 
            // IDTB
            // 
            IDTB.BorderStyle = BorderStyle.None;
            IDTB.Enabled = false;
            IDTB.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            IDTB.Location = new Point(63, 62);
            IDTB.Name = "IDTB";
            IDTB.ReadOnly = true;
            IDTB.Size = new Size(125, 20);
            IDTB.TabIndex = 0;
            IDTB.Text = "ID : ";
            IDTB.TextAlign = HorizontalAlignment.Center;
            // 
            // ProductNameTB
            // 
            ProductNameTB.BorderStyle = BorderStyle.None;
            ProductNameTB.Enabled = false;
            ProductNameTB.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            ProductNameTB.Location = new Point(22, 114);
            ProductNameTB.Name = "ProductNameTB";
            ProductNameTB.ReadOnly = true;
            ProductNameTB.Size = new Size(125, 20);
            ProductNameTB.TabIndex = 1;
            ProductNameTB.Text = "ProductName : ";
            ProductNameTB.TextAlign = HorizontalAlignment.Center;
            // 
            // QuantityTB
            // 
            QuantityTB.BorderStyle = BorderStyle.None;
            QuantityTB.Enabled = false;
            QuantityTB.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            QuantityTB.Location = new Point(63, 170);
            QuantityTB.Name = "QuantityTB";
            QuantityTB.ReadOnly = true;
            QuantityTB.Size = new Size(125, 20);
            QuantityTB.TabIndex = 2;
            QuantityTB.Text = " Quantity :";
            // 
            // UnitPriceTB
            // 
            UnitPriceTB.BorderStyle = BorderStyle.None;
            UnitPriceTB.Enabled = false;
            UnitPriceTB.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            UnitPriceTB.Location = new Point(63, 233);
            UnitPriceTB.Name = "UnitPriceTB";
            UnitPriceTB.ReadOnly = true;
            UnitPriceTB.Size = new Size(125, 20);
            UnitPriceTB.TabIndex = 3;
            UnitPriceTB.Text = "UnitPrice :";
            // 
            // InputID
            // 
            InputID.Font = new Font("Arial Narrow", 9F, FontStyle.Regular, GraphicsUnit.Point);
            InputID.Location = new Point(170, 59);
            InputID.Name = "InputID";
            InputID.Size = new Size(171, 25);
            InputID.TabIndex = 4;
            InputID.KeyPress += InputID_KeyPress;
            // 
            // InputProduct
            // 
            InputProduct.Font = new Font("Arial Narrow", 9F, FontStyle.Regular, GraphicsUnit.Point);
            InputProduct.Location = new Point(170, 111);
            InputProduct.Name = "InputProduct";
            InputProduct.Size = new Size(171, 25);
            InputProduct.TabIndex = 5;
            // 
            // InputQuantity
            // 
            InputQuantity.Font = new Font("Arial Narrow", 9F, FontStyle.Regular, GraphicsUnit.Point);
            InputQuantity.Location = new Point(170, 167);
            InputQuantity.Name = "InputQuantity";
            InputQuantity.Size = new Size(171, 25);
            InputQuantity.TabIndex = 6;
            InputQuantity.KeyPress += InputQuantity_KeyPress;
            // 
            // InputUnitPrice
            // 
            InputUnitPrice.Font = new Font("Arial Narrow", 9F, FontStyle.Regular, GraphicsUnit.Point);
            InputUnitPrice.Location = new Point(170, 230);
            InputUnitPrice.Name = "InputUnitPrice";
            InputUnitPrice.Size = new Size(171, 25);
            InputUnitPrice.TabIndex = 7;
            InputUnitPrice.KeyPress += InputUnitPrice_KeyPress;
            // 
            // OKButton
            // 
            OKButton.BackColor = SystemColors.ActiveCaption;
            OKButton.Font = new Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            OKButton.Location = new Point(160, 307);
            OKButton.Name = "OKButton";
            OKButton.Size = new Size(118, 72);
            OKButton.TabIndex = 8;
            OKButton.Text = "OK";
            OKButton.UseVisualStyleBackColor = false;
            OKButton.Click += OKButton_Click;
            // 
            // AddEditProductForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(432, 420);
            Controls.Add(OKButton);
            Controls.Add(InputUnitPrice);
            Controls.Add(InputQuantity);
            Controls.Add(InputProduct);
            Controls.Add(InputID);
            Controls.Add(UnitPriceTB);
            Controls.Add(QuantityTB);
            Controls.Add(ProductNameTB);
            Controls.Add(IDTB);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "AddEditProductForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            TopMost = true;
            Load += AddEditProductForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox IDTB;
        private TextBox ProductNameTB;
        private TextBox QuantityTB;
        private TextBox UnitPriceTB;
        private TextBox InputID;
        private TextBox InputProduct;
        private TextBox InputQuantity;
        private TextBox InputUnitPrice;
        private Button OKButton;
    }
}