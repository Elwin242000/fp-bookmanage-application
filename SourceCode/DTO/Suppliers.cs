using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACK.DTO
{
    public class Suppliers
    {
        public Suppliers (int id, string name, string address, string phone)
        {
            this.ID = id;
            this.SupplierName = name;
            this.Address = address;
            this.Phone = phone;
        }

        //truy vấn csdl
        public Suppliers(DataRow row)
        {
            this.ID = (int)row["id"];
            this.SupplierName = row["name"].ToString();
            this.Address = row["address"].ToString();
            this.Phone = row["phone"].ToString();
        }

        private int iD;
        private string supplierName;
        private string address;
        private string phone;

        public int ID { get => iD; set => iD = value; }
        public string SupplierName { get => supplierName; set => supplierName = value; }
        public string Address { get => address; set => address = value; }
        public string Phone { get => phone; set => phone = value; }
    }
}
