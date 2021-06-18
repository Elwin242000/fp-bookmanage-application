using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACK.DTO
{
    public class Items
    {
        public Items (int id, string name)
        {
            this.Id = id;
            this.ItemName = name;
        }

        //truy vấn csdl
        public Items(DataRow row)
        {
            this.Id = (int)row["id"];
            this.ItemName = row["name"].ToString();
        }

        private int id;
        private string itemName;

        public int Id { get => id; set => id = value; }
        public string ItemName { get => itemName; set => itemName = value; }
    }
}
