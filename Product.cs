using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__project
{
    public class Product
    {
        private string id;
        private string productName;
        private double unitPrice;
        private int quantity;

        // Properties
        public string ID { get { return id; } set {  id = value; } }
        public string ProductName { get { return productName; } set {  productName = value; } }
        public double UnitPrice { get {  return unitPrice; } set {  unitPrice = value; } }
        public int Quantity { get { return quantity; } set { quantity = value; } }   

        // Constructor
        public Product(string ID, string ProductName, double UnitPrice, int Quantity)
        {
            this.ID = ID;
            this.ProductName = ProductName;
            this.UnitPrice = UnitPrice;
            this.Quantity = Quantity;
        }
    }
}
