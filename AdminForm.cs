using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C__project
{
    public partial class AdminForm : Form
    {
    
        private LoginForm loginForm;


        // Constructor
        public AdminForm(LoginForm lf)
        {
            InitializeComponent();
            this.loginForm = lf;

            FillDataGridView();
        }



        // Filling Table with data from DataBase
        public void FillDataGridView()
        {
            string connString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False";

            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();


                string query = "SELECT ID, Product, UnitPrice, Quantity FROM Products ";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Kreiranje DataTable za punjenje podataka
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);

                    // Postavljanje podataka u DataGridView
                    foreach (DataRow row in dataTable.Rows)
                    {
                        Products.Rows.Add(
                            row["ID"],
                            row["Product"],
                            row["UnitPrice"],
                            row["Quantity"]
                            );

                    }


                    reader.Close();

                    connection.Close();
                }
            }

        }




        // Add Product with Click on Button
        private void AddButton_Click(object sender, EventArgs e)
        {
            using (var form = new AddEditProductForm(null))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Product product = form.NewProduct;


                    string connString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False";

                    using (SqlConnection connection = new SqlConnection(connString))
                    {
                        connection.Open();


                        string query = "SELECT COUNT(*) FROM Products WHERE ID = @ID";

                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@ID", product.ID);

                            int count = (int)cmd.ExecuteScalar(); // Vraća broj redova koji zadovoljavaju uslov

                            if (count == 0)
                            {
                                // Ako projekat ne postoji, dodajte ga
                                string insertQuery = "INSERT INTO Products VALUES (@ID, @ProductName,@UnitPrice,@Quantity)";
                                using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                                {
                                    insertCommand.Parameters.AddWithValue("@ID", Int32.Parse(product.ID));
                                    insertCommand.Parameters.AddWithValue("@ProductName", product.ProductName);
                                    insertCommand.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);
                                    insertCommand.Parameters.AddWithValue("@Quantity", product.Quantity);

                                    Products.Rows.Add(product.ID, product.ProductName, product.UnitPrice, product.Quantity);

                                    insertCommand.ExecuteNonQuery(); // Izvrši upit za dodavanje
                                }
                            }
                            else
                            {
                                MessageBox.Show("A product with the given ID already exists...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }


                }
            }
        }

        // Button for Back to LoginForm
        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
            loginForm.Show();
        }

        // Editing the product in the selected row ( In DataBase too )
        private void EditButton_Click(object sender, EventArgs e)
        {
            if (Products.SelectedRows.Count <= 0 || Products.SelectedRows[0].Index < 0)
                return;

            Product p = new Product(
                        Products.SelectedRows[0].Cells["ID"].Value.ToString(),
                        Products.SelectedRows[0].Cells["Product"].Value.ToString(),
                        Convert.ToDouble(Products.SelectedRows[0].Cells["UnitPrice"].Value),
                        Int32.Parse(Products.SelectedRows[0].Cells["Quantity"].Value.ToString())
                        );

            using (var form = new AddEditProductForm(p))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Product product = form.NewProduct;

                    bool idChanged = false;
                    bool nameChanged = false;
                    bool quantityChanged = false;
                    bool unitPriceChanged = false;

                    if (p.ID != product.ID)
                        idChanged = true;
                    if (p.ProductName != product.ProductName)
                        nameChanged = true;
                    if (p.Quantity != product.Quantity)
                        quantityChanged = true;
                    if (p.UnitPrice != product.UnitPrice)
                        unitPriceChanged = true;

                    if (!idChanged && !nameChanged && !quantityChanged && !unitPriceChanged)
                        return;


                    // Changing into DataBase
                    string connString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False";

                    using (SqlConnection connection = new SqlConnection(connString))
                    {
                        connection.Open();

                        if (idChanged)
                        {
                            string query = "UPDATE Products SET ID = @ID1 WHERE ID = @ID2";

                            using (SqlCommand cmd = new SqlCommand(query, connection))
                            {
                                cmd.Parameters.AddWithValue("@ID1", product.ID);
                                cmd.Parameters.AddWithValue("@ID2", p.ID);

                                cmd.ExecuteNonQuery();
                            }
                        }

                        if (nameChanged)
                        {
                            string query = "UPDATE Products SET Product = @Product WHERE ID = @ID";

                            using (SqlCommand cmd = new SqlCommand(query, connection))
                            {
                                cmd.Parameters.AddWithValue("@Product", product.ProductName);
                                cmd.Parameters.AddWithValue("@ID", p.ID);

                                cmd.ExecuteNonQuery();
                            }
                        }

                        if (quantityChanged)
                        {
                            string query = "UPDATE Products SET Quantity = @Quantity WHERE ID = @ID";

                            using (SqlCommand cmd = new SqlCommand(query, connection))
                            {
                                cmd.Parameters.AddWithValue("@Quantity", product.Quantity);
                                cmd.Parameters.AddWithValue("@ID", p.ID);

                                cmd.ExecuteNonQuery();
                            }
                        }

                        if (unitPriceChanged)
                        {
                            string query = "UPDATE Products SET UnitPrice = @UnitPrice WHERE ID = @ID";

                            using (SqlCommand cmd = new SqlCommand(query, connection))
                            {
                                cmd.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);
                                cmd.Parameters.AddWithValue("@ID", p.ID);

                                cmd.ExecuteNonQuery();
                            }
                        }

                        connection.Close();

                    }

                    // Changing into DataGridView
                    if (idChanged)
                        Products.SelectedRows[0].Cells["ID"].Value = product.ID;

                    if (nameChanged)
                        Products.SelectedRows[0].Cells["ProductName"].Value = product.ProductName;

                    if (quantityChanged)
                        Products.SelectedRows[0].Cells["Quantity"].Value = product.Quantity.ToString();

                    if (unitPriceChanged)
                        Products.SelectedRows[0].Cells["UnitPrice"].Value = product.UnitPrice.ToString();
                }
            }
        }

        // Removing the product in the selected row ( In DataBase too )
        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (Products.SelectedRows.Count <= 0 || Products.SelectedRows[0].Index < 0)
                return;

            DialogResult result = MessageBox.Show(
                "Are you sure you want to remove this product?",
                "Confirming...",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // Removing from DataBase
                string connString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False";

                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();

                    string query = "DELETE FROM Products WHERE ID = @ID";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID", Int32.Parse(Products.SelectedRows[0].Cells["ID"].Value.ToString()));

                        cmd.ExecuteNonQuery();
                    }

                    connection.Close();
                }

                // Removing from DataGridView
                Products.Rows.RemoveAt(Products.SelectedRows[0].Index);


            }
        }


    }
}
