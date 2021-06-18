using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DACK.DTO
{
    public class ItemType
    {
        public ItemType(int id, string name, int idItem)
        {
            this.ID = id;
            this.ItemTypeName = name;
            this.IDitem = idItem;
        }

        //truy vấn csdl
        public ItemType(DataRow row)
        {
            this.ID = (int)row["id"];
            this.ItemTypeName = row["name"].ToString();
            this.IDitem = (int)row["idItem"];
        }

        private int iD;
        private string itemTypeName;
        private int iDitem;

        public int ID { get => iD; set => iD = value; }
        public string ItemTypeName { get => itemTypeName; set => itemTypeName = value; }
        public int IDitem { get => iDitem; set => iDitem = value; }
    }
}
