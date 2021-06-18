using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACK.DTO
{
    public class Menu
    {
        public Menu (string name, int count, float price, float totalprice = 0)
        {
            this.ProductName = name;
            this.Count = count;
            this.Price = price;
            this.TotalPrice = totalprice;
        }

        //truy vấn csdl
        public Menu(DataRow row)
        {
            this.ProductName = row["name"].ToString();
            this.Count = (int)row["count"];
            this.Price = (float)Convert.ToDouble(row["price"].ToString());
            this.TotalPrice = (float)Convert.ToDouble(row["totalprice"].ToString());
        }

        private string productName;
        private int count;
        private float price;
        private float totalPrice;

        public string ProductName { get => productName; set => productName = value; }
        public int Count { get => count; set => count = value; }
        public float Price { get => price; set => price = value; }
        public float TotalPrice { get => totalPrice; set => totalPrice = value; }
    }
}
