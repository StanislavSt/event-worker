using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApp
{
    public class Product
    {
        public int ProductID { get; private set; }
        public string Name { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }

        public Product(int productid, string name, int quantity, decimal price)
        {
            ProductID = productid;
            Name = name;
            Quantity = quantity;
            Price = price;
        }

        public void DecreaseQuantity(int q)
        {
            Quantity = Quantity - q;
        }
        public void IncreaseQuantity(int q)
        {

            Quantity = Quantity + q;
        }

        public  string ToString(int q)
        {
            return Name.PadRight(20 - Name.Length) + "\tQuantity: " + q.ToString().PadRight(2) + "\tPrice: " + Price * q + " \u20AC";
        }
    }
}
