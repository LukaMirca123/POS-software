using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C__project
{
    public partial class AddEditProductForm : Form
    {
        private Product newProduct;
        public Product NewProduct { get { return newProduct; } private set { } }
        public AddEditProductForm(Product product)
        {
            InitializeComponent();


            FillData(product);

            this.ActiveControl = OKButton;
        }

        public void FillData(Product product)
        {
            if (product != null)
            {
                InputID.Text = product.ID;
                InputProduct.Text = product.ProductName;
                InputQuantity.Text = product.Quantity.ToString();
                InputUnitPrice.Text = product.UnitPrice.ToString();
            }
        }

        private void InputID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;

        }



        private void InputQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void InputUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Dozvoljava samo jednu tačku
            if (e.KeyChar == '.' && InputUnitPrice.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            // Chech for ID
            if (string.IsNullOrWhiteSpace(InputID.Text))
            {
                MessageBox.Show("ID field cannot be empty. Please enter a valid number...");
                return;
            }
            else if (InputID.Text.Contains(" ") || InputID.Text == "0")
            {
                MessageBox.Show("Invalid ID. Please enter a valid number...");
                return;
            }

            // Check for ProductName
            if (string.IsNullOrWhiteSpace(InputProduct.Text))
            {
                MessageBox.Show("ProductName field cannot be empty. Please enter a valid ProductName...");
                return;
            }


            // Check for Quantity
            if (string.IsNullOrWhiteSpace(InputProduct.Text))
            {
                MessageBox.Show("Quantity field cannot be empty. Please enter a valid number...");
                return;
            }
            else if (InputQuantity.Text.Contains(" ") || InputQuantity.Text == "0")
            {
                MessageBox.Show("Invalid Quantity. Please enter a valid number...");
                return;
            }


            // Check for UnitPrice
            if (string.IsNullOrWhiteSpace(InputUnitPrice.Text))
            {
                MessageBox.Show("UnitPrice field cannot be empty. Please enter a valid number...");
                return;
            }
            Regex regex = new Regex(@"^\d+\.\d+$");

            if (!regex.IsMatch(InputUnitPrice.Text))
            {
                MessageBox.Show("Invalid format UnitPrice. Please enter a value in the format 'number.number'... ");
                return;
            }
            else if (InputUnitPrice.Text == "0.00")
            {
                MessageBox.Show("Invalid UnitPrice. Please enter a number above zero...");
                return;
            }


            newProduct = new Product
            (
                InputID.Text.ToString(),
                InputProduct.Text.ToString(),
                Convert.ToDouble(InputUnitPrice.Text),
                Int32.Parse(InputQuantity.Text)
            );

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void AddEditProductForm_Load(object sender, EventArgs e)
        {
            this.Select();
        }
    }
}
