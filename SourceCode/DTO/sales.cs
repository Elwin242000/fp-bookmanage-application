using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACK.DTO
{
    public class sales
    {
        public sales(string name, int count)
        {
            this.SalesName = name;
            this.Count = count;
        }

        //truy vấn csdl
        public sales(DataRow row)
        {
            this.SalesName = row["name"].ToString();
            this.Count = (int)row["count"];
        }

        private string salesName;
        private int count;

        public string SalesName { get => salesName; set => salesName = value; }
        public int Count { get => count; set => count = value; }
    }
}
