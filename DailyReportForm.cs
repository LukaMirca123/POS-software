using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C__project
{
    public partial class DailyReportForm : Form
    {
        public DailyReportForm(List<Product> products)
        {
            InitializeComponent();
            FillDataGridView(products);
        }

        public void FillDataGridView(List<Product> products)
        {
            double sum = 0.00;
            foreach (Product product in products)
            {
                SumProducts_DGV.Rows.Add(product.ID, product.ProductName, product.UnitPrice.ToString(), product.Quantity.ToString(), (product.UnitPrice * product.Quantity).ToString());

                sum += product.UnitPrice * Convert.ToDouble(product.Quantity);
            }

            TotalPrice_TB.Text = sum.ToString();
        }

        private void DailyReportForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to close?",
                                             "Confirm Close",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);

                // Ako korisnik odabere Yes, zatvorite formu
                if (result == DialogResult.Yes)
                {
                    this.Close();  // Zatvara formu
                }
            }
        }


    }
}
