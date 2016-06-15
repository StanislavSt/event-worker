using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApp
{
    public class Equipment
    {
        public int EquipmentID { get; private set; }
        public string Name { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }
        public DateTime DateHired { get; private set; }
        public Equipment(int equipmentID, string name, int quantity, decimal price)
        {
            EquipmentID = equipmentID;
            Name = name;
            Quantity = quantity;
            Price = price;
           
        }

        //public string ToString()
        //{
        //    return Name + Price;
        //}

        public void IncreaseQuantity(int q)
        {
            Quantity = Quantity + q;
        }
        public void DecreaseQuantity(int q)
        {
            Quantity = Quantity -q;
        }
        public void SetDateTimeHired(DateTime dt)
        {
            DateHired = dt;
        }
    }
}
