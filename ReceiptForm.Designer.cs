namespace C__project
{
    partial class ReceiptForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReceiptForm));
            Table = new TableLayoutPanel();
            Picture = new PictureBox();
            TB_TimeText = new TextBox();
            TB_Time = new TextBox();
            Cancel = new Button();
            ((System.ComponentModel.ISupportInitialize)Picture).BeginInit();
            SuspendLayout();
            // 
            // Table
            // 
            Table.ColumnCount = 4;
            Table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            Table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 149F));
            Table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 151F));
            Table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            Table.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            Table.Location = new Point(24, 257);
            Table.Name = "Table";
            Table.RowCount = 1;
            Table.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            Table.Size = new Size(592, 59);
            Table.TabIndex = 0;
            // 
            // Picture
            // 
            Picture.Image = (Image)resources.GetObject("Picture.Image");
            Picture.Location = new Point(161, 23);
            Picture.Name = "Picture";
            Picture.Size = new Size(327, 98);
            Picture.TabIndex = 1;
            Picture.TabStop = false;
            // 
            // TB_TimeText
            // 
            TB_TimeText.BorderStyle = BorderStyle.None;
            TB_TimeText.Enabled = false;
            TB_TimeText.Location = new Point(24, 156);
            TB_TimeText.Name = "TB_TimeText";
            TB_TimeText.ReadOnly = true;
            TB_TimeText.Size = new Size(43, 20);
            TB_TimeText.TabIndex = 2;
            TB_TimeText.Text = "Time : ";
            // 
            // TB_Time
            // 
            TB_Time.BorderStyle = BorderStyle.None;
            TB_Time.Enabled = false;
            TB_Time.Location = new Point(73, 156);
            TB_Time.Name = "TB_Time";
            TB_Time.ReadOnly = true;
            TB_Time.Size = new Size(144, 20);
            TB_Time.TabIndex = 3;
            // 
            // Cancel
            // 
            Cancel.Location = new Point(-1, -2);
            Cancel.Name = "Cancel";
            Cancel.Size = new Size(10, 10);
            Cancel.TabIndex = 4;
            Cancel.UseVisualStyleBackColor = true;
            Cancel.Click += Cancel_Click;
            // 
            // ReceiptForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = Cancel;
            ClientSize = new Size(654, 866);
            Controls.Add(Cancel);
            Controls.Add(TB_Time);
            Controls.Add(TB_TimeText);
            Controls.Add(Picture);
            Controls.Add(Table);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ReceiptForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Receipt";
            Load += ReceiptForm_Load;
            KeyDown += ReceiptForm_KeyDown;
            ((System.ComponentModel.ISupportInitialize)Picture).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel Table;
        private PictureBox Picture;
        private TextBox TB_TimeText;
        private TextBox TB_Time;
        private Button Cancel;


    }
}