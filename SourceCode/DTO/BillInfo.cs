using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACK.DTO
{
    public class BillInfo
    {
        public BillInfo(int id, int idBill, int idProduct, int count)
        {
            this.ID = id;
            this.IDBill = idBill;
            this.IDProduct = idProduct;
            this.Count = count;
        }

        //truy vấn csdl
        public BillInfo(DataRow row)
        {
            this.ID = (int)row["id"];
            this.IDBill = (int)row["idBill"];
            this.IDProduct = (int)row["idProduct"];
            this.Count = (int)row["count"];
        }

        private int iD;
        private int iDBill;
        private int iDProduct;
        private int count;

        public int ID { get => iD; set => iD = value; }
        public int IDBill { get => iDBill; set => iDBill = value; }
        public int IDProduct { get => iDProduct; set => iDProduct = value; }
        public int Count { get => count; set => count = value; }
    }
}
