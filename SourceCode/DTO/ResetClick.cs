using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACK.DTO
{
    public class ResetClick
    {
        public ResetClick(int id, string name)
        {
            this.Id = id;
            this.RcName = name;
        }

        //truy vấn csdl
        public ResetClick(DataRow row)
        {
            this.Id = (int)row["id"];
            this.RcName = row["name"].ToString();
        }

        private int id;
        private string rcName;

        public int Id { get => id; set => id = value; }
        public string RcName { get => rcName; set => rcName = value; }
    }
}
