using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using C__project;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using iTextSharp.text;
using iTextSharp.text.pdf;



namespace C__project
{
    public partial class WorkerForm : Form
    {
        private LoginForm loginForm;
        private List<Product> SumProducts = new List<Product>();
        private List<Product> Products = new List<Product>();

        // Constructor
        public WorkerForm(LoginForm lf)
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;

            loginForm = lf;
        }



        // Find First Empty Row in DataGridView
        private int FindFirstEmptyRow()
        {
            for (int i = 0; i < ProductsDGV.Rows.Count; i++)
            {
                if (string.IsNullOrWhiteSpace(ProductsDGV.Rows[i].Cells["ID"].Value?.ToString()))
                {
                    return i;
                }
            }
            return -1;
        }

        // Add to the first empty row
        public void AddDataToFirstEmptyRow(string id, string product, string unitPrice, string quantity, string price)
        {
            foreach (DataGridViewRow red in ProductsDGV.Rows)
            {
                if (red.Cells["ID"].Value != null)
                {
                    if (red.Cells["ID"].Value.ToString() == id.ToString())
                    {
                        red.Cells["Quantity"].Value = (Int32.Parse(red.Cells["Quantity"].Value.ToString()) + Int32.Parse(quantity)).ToString();
                        red.Cells["Price"].Value = (Math.Round(Convert.ToDouble(red.Cells["Price"].Value) + Convert.ToDouble(price), 2)).ToString("F2");
                        return;
                    }
                }
            }

            int row = FindFirstEmptyRow();

            if (row != -1)
            {
                ProductsDGV.Rows[row].Cells["ID"].Value = id;
                ProductsDGV.Rows[row].Cells["Product"].Value = product;
                ProductsDGV.Rows[row].Cells["UnitPrice"].Value = unitPrice;
                ProductsDGV.Rows[row].Cells["Quantity"].Value = quantity;
                ProductsDGV.Rows[row].Cells["Price"].Value = price;
                ProductsDGV.Rows[row].Cells["Remove"].Value = "X";
            }
            else
            {
                MessageBox.Show("There is no empty row!");
            }
        }

        // Search Product by BarCode in DataBase
        public void SearchProductByBarcode(int barcode)
        {
            string connectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // SQL upit koji traži proizvod na osnovu bar koda (ID)
                string query = "SELECT ID, Product, UnitPrice, Quantity FROM Products WHERE ID = @Barcode";


                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Dodavanje parametra za upit (za zaštitu od SQL injection)
                    command.Parameters.AddWithValue("@Barcode", barcode);

                    // Izvršavanje upita
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            string input = Microsoft.VisualBasic.Interaction.InputBox("Enter quantity: ", "", "1");

                            if (String.IsNullOrEmpty(input))
                                return;

                            AddDataToFirstEmptyRow(reader["ID"].ToString(),
                                                   reader["Product"].ToString(),
                                                   reader["UnitPrice"].ToString(),
                                                   input,
                                                   (Math.Round(Convert.ToDouble(input) * Convert.ToDouble(reader["UnitPrice"]), 2)).ToString());

                            TotalPrice();

                        }
                        else
                        {
                            MessageBox.Show("Proizvod sa tim bar kodom nije pronađen.");
                        }
                    }
                }

                connection.Close();
            }
        }

        // Calculating total price
        public void TotalPrice()
        {
            double price = 0.00;
            foreach (DataGridViewRow row in ProductsDGV.Rows)
            {
                // Proveravaj da li je red validan (da nije prazan red)
                if (row.Cells["ID"].Value != null)
                {
                    price += Convert.ToDouble(row.Cells["Price"].Value);
                }
            }

            if (price == 0.00)
                TP_textBox.Text = "0.00";
            else
                TP_textBox.Text = price.ToString("F2");
        }

        // PrintReceipt
        public void PrintReceipt()
        {
            foreach (DataGridViewRow row in ProductsDGV.Rows)
            {
                // Proveri da li red sadrži podatke (da nije poslednji prazan red koji DataGridView koristi za unos novih redova)
                if (row.Cells["ID"].Value != null && !string.IsNullOrWhiteSpace(row.Cells["ID"].Value.ToString()))
                {
                    bool find = false;
                    foreach (Product p in SumProducts)
                    {
                        if (p.ID == row.Cells["ID"].Value.ToString())
                        {
                            p.Quantity += Int32.Parse(row.Cells["Quantity"].Value.ToString());
                            find = true;
                            break;
                        }
                    }

                    if (!find)
                        SumProducts.Add(new Product(row.Cells["ID"].Value.ToString(),
                                                    row.Cells["Product"].Value.ToString(),
                                                    Convert.ToDouble(row.Cells["UnitPrice"].Value),
                                                    Int32.Parse(row.Cells["Quantity"].Value.ToString())));

                    Products.Add(new Product(row.Cells["ID"].Value.ToString(),
                                                    row.Cells["Product"].Value.ToString(),
                                                    Convert.ToDouble(row.Cells["UnitPrice"].Value),
                                                    Int32.Parse(row.Cells["Quantity"].Value.ToString())));

                }
            }

            // Clearing DataGridView and TotalPrice
            foreach (DataGridViewRow row in ProductsDGV.Rows)
            {
                if (row.Cells["ID"].Value != null && !string.IsNullOrWhiteSpace(row.Cells["ID"].Value.ToString()))
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        cell.Value = null;
                    }
                }
            }
            TP_textBox.Text = "0.00";


            // Printing receipt on screen
            ReceiptForm receiptForm = new ReceiptForm(Products);
            receiptForm.ShowDialog();

            // Generate PDF receipt and Printing receipt 
            GeneratePDFReceipt();


            // Updating Quantity in DataBase for Products
            string connectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();


                foreach (Product p in Products)
                {
                    string query = "UPDATE Products SET Quantity = Quantity - @Quantity_ WHERE ID = @ID_;";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Quantity_", p.Quantity);
                        cmd.Parameters.AddWithValue("@ID_", p.ID);
                        cmd.ExecuteNonQuery();

                    }
                }

                connection.Close();
            }

            // Clearing List of Products for Receipt
            Products = new List<Product>();

        }

        public void GeneratePDFReceipt()
        {
            iTextSharp.text.Document document = new iTextSharp.text.Document(new iTextSharp.text.Rectangle(165f, 500f));

            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream("D:\\Receipts\\recept.pdf", FileMode.Create));

            document.Open();

            string imagePath = "D:\\PictureForReceipt\\LogoMarket.jpg";

            if (File.Exists(imagePath))
            {
                iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(imagePath);
                logo.ScaleToFit(150f, 150f);
                logo.Alignment = Element.ALIGN_CENTER;
                document.Add(logo);
            }

            BaseFont titleFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.EMBEDDED);
            iTextSharp.text.Font fontTitle = new iTextSharp.text.Font(titleFont, 13f); // Naslov računa

            // Podesi manji font za ukupnu cenu
            BaseFont baseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.EMBEDDED);
            iTextSharp.text.Font fontBase = new iTextSharp.text.Font(baseFont, 5f);

            BaseFont timeFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.EMBEDDED);
            iTextSharp.text.Font fontTime = new iTextSharp.text.Font(timeFont, 4f); // Naslov računa

            BaseFont totalPriceFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.EMBEDDED);
            iTextSharp.text.Font fontTotalPrice = new iTextSharp.text.Font(totalPriceFont, 7f); // TotalPrice

            // Time
            Paragraph time = new Paragraph("\n" + DateTime.Now.ToString("HH:mm:ss    dd-MM-yyyy") + "\n\n", fontTime);
            time.Alignment = Element.ALIGN_LEFT;
            document.Add(time);

            // Naslov
            Paragraph title = new Paragraph("Receipt", fontTitle);
            title.Alignment = Element.ALIGN_CENTER;
            document.Add(title);

            // Razdvojna linija
            Paragraph line = new Paragraph("--------------------", fontTitle);
            title.Alignment = Element.ALIGN_CENTER;
            document.Add(line);



            // Kreiraj tabelu za podatke o proizvodima (bez granica u ćelijama)
            PdfPTable table = new PdfPTable(4); // 4 kolone: Ime, Količina, Cena po komadu, Cena
            table.WidthPercentage = 100f; // Postavi širinu tabele na 100% širine stranice

            // Postavi širinu kolona
            table.SetWidths(new float[] { 3f, 1f, 2f, 2f }); // Omogućava više prostora za naziv proizvoda
            table.SpacingBefore = 5f; // Povećava razmak pre tabele
            table.SpacingAfter = 5f;  // Povećava razmak posle tabele

            double totalPrice = 0.00;

            // Dodaj podatke o proizvodima
            foreach (Product product in Products)
            {
                // Napravi funkciju jednu !!!
                PdfPCell cell = new PdfPCell(new Phrase(product.ProductName, new iTextSharp.text.Font(baseFont, 5f)));
                cell.Border = iTextSharp.text.Rectangle.NO_BORDER; // Uklanja granice
                cell.PaddingTop = 5f; // Povećava gornji razmak unutar ćelije
                cell.PaddingBottom = 5f;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(product.Quantity.ToString(), new iTextSharp.text.Font(baseFont, 5f)));
                cell.Border = iTextSharp.text.Rectangle.NO_BORDER; // Uklanja granice
                cell.PaddingTop = 5f; // Povećava gornji razmak unutar ćelije
                cell.PaddingBottom = 5f;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(product.UnitPrice.ToString("0.00"), new iTextSharp.text.Font(baseFont, 5f)));
                cell.Border = iTextSharp.text.Rectangle.NO_BORDER; // Uklanja granice
                cell.PaddingTop = 5f; // Povećava gornji razmak unutar ćelije
                cell.PaddingBottom = 5f;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase((product.Quantity * product.UnitPrice).ToString("0.00"), new iTextSharp.text.Font(titleFont, 5f)));
                cell.Border = iTextSharp.text.Rectangle.NO_BORDER; // Uklanja granice
                cell.PaddingTop = 5f; // Povećava gornji razmak unutar ćelije
                cell.PaddingBottom = 5f;
                table.AddCell(cell);

                totalPrice += Math.Round(product.Quantity * product.UnitPrice, 2);
            }

            // Dodaj tabelu u dokument
            document.Add(table);

            // Dodaj ukupnu cenu ispod tabele
            Paragraph total = new Paragraph("\n\nTotal Price: " + totalPrice.ToString("0.00"), fontTotalPrice);
            total.Alignment = Element.ALIGN_RIGHT;
            document.Add(total);

            // Razmak pre kraja dokumenta (opcionalno)
            document.Add(new Paragraph("\n"));

            float currentHeight = writer.GetVerticalPosition(false); // Trenutna pozicija kursora

            // Podesite visinu PDF-a na osnovu trenutne pozicije
            // Možete dodati neku marginu na dnu (50f je primer)
            document.SetPageSize(new iTextSharp.text.Rectangle(165f, currentHeight + 50f));

            document.Close();


        }



        // Classic for time
        private void Timer_Tick(object sender, EventArgs e)
        {
            this.Text = "Time:  " + DateTime.Now.ToString("HH:mm:ss   dd-MM-yyyy");
        }

        private void WorkerForm_Load(object sender, EventArgs e)
        {
            ProductsDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ProductsDGV.AllowUserToAddRows = false;
            ProductsDGV.AllowUserToDeleteRows = false;

            ProductsDGV.DefaultCellStyle.SelectionBackColor = ProductsDGV.DefaultCellStyle.BackColor;
            ProductsDGV.DefaultCellStyle.SelectionForeColor = ProductsDGV.DefaultCellStyle.ForeColor;

            ProductsDGV.RowCount = 23;

            

        }

        // Removing row on click on X
        private void Podaci_DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Proveri da li je kliknuto na poslednju kolonu (dugme "X")
            if (e.ColumnIndex == ProductsDGV.Columns["Remove"].Index && e.RowIndex >= 0 && ProductsDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                for (int i = e.RowIndex + 1; i < ProductsDGV.Rows.Count; i++)
                {
                    // Pomeranje vrednosti ćelija za jedan red prema gore
                    for (int j = 0; j < ProductsDGV.Columns.Count; j++)
                    {
                        ProductsDGV.Rows[i - 1].Cells[j].Value = ProductsDGV.Rows[i].Cells[j].Value;
                    }

                    // Resetovanje vrednosti u poslednjem redu
                    foreach (DataGridViewCell cell in ProductsDGV.Rows[i].Cells)
                    {
                        cell.Value = null;
                    }
                }
            }

            TotalPrice();
        }

        // When the BarCode is entered and we press Enter, we add the product...
        private void BarCodeTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(BarCodeTB.Text))
            {
                // Pozivamo funkciju koja pretražuje proizvod po bar kodu
                SearchProductByBarcode(Int32.Parse(BarCodeTB.Text));

                // Očistiti TextBox nakon skeniranja, ili ga ostaviti praznim ako je potrebno
                BarCodeTB.Clear();
            }
            else if (e.KeyCode == Keys.Back && string.IsNullOrEmpty(BarCodeTB.Text))
            {
                e.Handled = true;
            }
            else if (!(e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) && !(e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9))
            {
                e.Handled = true;
            }
        }

        // Printing Receipt with Keyboard Key ( It is currently set to CTRL+P )
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.P))
            {
                // Pozovi funkciju za štampanje računa
                PrintReceipt();

                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        // Selected row then click on " - ", " + " or " Delete " --> Substract/Add Quantity or Removing whole row
        private void Podaci_DGV_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.OemMinus || e.KeyCode == Keys.Subtract)
            {
                // Proveri da li postoji selektovani red
                if (ProductsDGV.SelectedRows.Count > 0)
                {
                    // Pristupi selektovanom redu
                    DataGridViewRow selectedRow = ProductsDGV.SelectedRows[0];

                    if (selectedRow.Cells["ID"].Value != null && Int32.Parse(selectedRow.Cells["Quantity"].Value.ToString()) > 1)
                    {
                        selectedRow.Cells["Quantity"].Value = (Int32.Parse(selectedRow.Cells["Quantity"].Value.ToString()) - 1).ToString();
                        selectedRow.Cells["Price"].Value = (Convert.ToDouble(selectedRow.Cells["Quantity"].Value) * Convert.ToDouble(selectedRow.Cells["UnitPrice"].Value)).ToString("F2");
                        TotalPrice();
                    }

                }

                // Oznaka da je događaj obrađen
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Delete)
            {
                if (ProductsDGV.SelectedRows.Count > 0)
                {
                    // Pristupi selektovanom redu
                    DataGridViewRow selectedRow = ProductsDGV.SelectedRows[0];

                    for (int i = selectedRow.Index + 1; i < ProductsDGV.Rows.Count; i++)
                    {
                        // Pomeranje vrednosti ćelija za jedan red prema gore
                        for (int j = 0; j < ProductsDGV.Columns.Count; j++)
                        {
                            ProductsDGV.Rows[i - 1].Cells[j].Value = ProductsDGV.Rows[i].Cells[j].Value;
                        }

                        // Resetovanje vrednosti u poslednjem redu
                        foreach (DataGridViewCell cell in ProductsDGV.Rows[i].Cells)
                        {
                            cell.Value = null;
                        }

                        TotalPrice();
                    }

                    e.Handled = true;
                }
            }
            else if (e.KeyCode == Keys.Add)
            {
                // Proveri da li postoji selektovani red
                if (ProductsDGV.SelectedRows.Count > 0)
                {
                    // Pristupi selektovanom redu
                    DataGridViewRow selectedRow = ProductsDGV.SelectedRows[0];

                    if (selectedRow.Cells["ID"].Value != null && Int32.Parse(selectedRow.Cells["Quantity"].Value.ToString()) > 1)
                    {
                        selectedRow.Cells["Quantity"].Value = (Int32.Parse(selectedRow.Cells["Quantity"].Value.ToString()) + 1).ToString();
                        selectedRow.Cells["Price"].Value = (Convert.ToDouble(selectedRow.Cells["Quantity"].Value) * Convert.ToDouble(selectedRow.Cells["UnitPrice"].Value)).ToString("F2");
                        TotalPrice();
                    }

                }

                // Oznaka da je događaj obrađen
                e.Handled = true;
            }
        }

        // Daily Report
        private void SalesReport_Button_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to perform the daily sales summary?",
                                           "Daily Sales Summary",
                                           MessageBoxButtons.YesNo,
                                           MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                DailyReportForm drf = new DailyReportForm(SumProducts);
                drf.Show();
                this.Close();
            }
        }

        // Button for Back to Login Form
        private void ButtonBack_Click(object sender, EventArgs e)
        {
            this.Close();
            loginForm.Show();
        }

        private void ListOfProducts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // Input ListBox for search

    }
}
