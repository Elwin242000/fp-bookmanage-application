using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACK.DTO
{
    public class Product
    {
        public Product(int id, string name, string author, int idItem, int idItemType, int idSupplier, float price)
        {
            this.ID = id;
            this.ProductName = name;
            this.Author = author;
            this.idItem = idItem;
            this.IdItemType = idItemType;
            this.IdSupplier = idSupplier;
            this.Price = price;
        }

        //truy vấn csdl
        public Product(DataRow row)
        {
            this.ID = (int)row["id"];
            this.ProductName = row["name"].ToString();
            this.Author = row["author"].ToString();
            this.idItem = (int)row["idItem"];
            this.IdItemType = (int)row["idItemType"];
            this.IdSupplier = (int)row["idSupplier"];
            this.Price = (float)Convert.ToDouble(row["price"].ToString());
        }

        private int iD;
        private string productName;
        private string author;
        private int idItem;
        private int idItemType;
        private int idSupplier;
        private float price;

        public int ID { get => iD; set => iD = value; }
        public string ProductName { get => productName; set => productName = value; }
        public string Author { get => author; set => author = value; }
        public int IdItem { get => idItem; set => idItem = value; }
        public int IdItemType { get => idItemType; set => idItemType = value; }
        public int IdSupplier { get => idSupplier; set => idSupplier = value; }
        public float Price { get => price; set => price = value; }
    }
}
