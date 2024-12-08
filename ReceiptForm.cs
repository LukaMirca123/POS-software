using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace C__project
{
    public partial class ReceiptForm : Form
    {

        public ReceiptForm(List<Product> products)
        {
            InitializeComponent();
            PrintReceipt(products);
        }

        private void PrintReceipt(List<Product> products)
        {
            double sum = 0.00;
            Table.RowStyles.Clear();
            Table.AutoSize = true;

            Table.RowCount += 1;

            Table.Controls.Add(new Label { Text = "PRODUCT", TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Arial", 10, FontStyle.Bold | FontStyle.Underline) }, 0, Table.RowCount);
            Table.Controls.Add(new Label { Text = "QUANTITY", TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Arial", 10, FontStyle.Bold | FontStyle.Underline) }, 1, Table.RowCount);
            Table.Controls.Add(new Label { Text = "UNIT.PRICE", TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Arial", 10, FontStyle.Bold | FontStyle.Underline) }, 2, Table.RowCount);
            Table.Controls.Add(new Label { Text = "PRICE", TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Arial", 10, FontStyle.Bold | FontStyle.Underline) }, 3, Table.RowCount);

            foreach (Product product in products)
            {
                Table.RowCount += 1;

                Table.Controls.Add(new Label { Text = product.ProductName, TextAlign = ContentAlignment.MiddleCenter }, 0, Table.RowCount);
                Table.Controls.Add(new Label { Text = product.Quantity.ToString(), TextAlign = ContentAlignment.MiddleCenter }, 1, Table.RowCount);
                Table.Controls.Add(new Label { Text = product.UnitPrice.ToString(), TextAlign = ContentAlignment.MiddleCenter }, 2, Table.RowCount);
                Table.Controls.Add(new Label { Text = (Math.Round(product.Quantity * product.UnitPrice,2)).ToString(), TextAlign = ContentAlignment.MiddleCenter }, 3, Table.RowCount);

                sum += product.Quantity * product.UnitPrice;

            }

            Table.RowCount += 1;

            Table.Controls.Add(new Label { Text = "", TextAlign = ContentAlignment.MiddleCenter }, 0, Table.RowCount);
            Table.Controls.Add(new Label { Text = "", TextAlign = ContentAlignment.MiddleCenter }, 1, Table.RowCount);
            Table.Controls.Add(new Label { Text = "", TextAlign = ContentAlignment.MiddleCenter }, 2, Table.RowCount);
            Table.Controls.Add(new Label { Text = sum.ToString(), TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Arial", 10, FontStyle.Bold) }, 3, Table.RowCount);


            Table.PerformLayout();
        }

        private void ReceiptForm_Load(object sender, EventArgs e)
        {
            TB_Time.Text = DateTime.Now.ToString("HH:mm    dd-MM-yyyy");

            this.ActiveControl = null;
        }

        private void ReceiptForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                this.Close();
            }

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }



}
