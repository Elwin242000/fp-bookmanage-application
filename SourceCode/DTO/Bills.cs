using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACK.DTO
{
    public class Bills
    {
        public Bills (int id, DateTime? DateCheckIn, DateTime? DateCheckOut, int idReset, int status, int discount)
        {
            this.Id = id;
            this.DateCheckIn = DateCheckIn;
            this.DateCheckOut = DateCheckOut;
            this.IdReset = idReset;
            this.Status = status;
            this.Discount = discount;
        }

        //truy vấn csdl
        public Bills(DataRow row)
        {
            this.Id = (int)row["id"];
            this.DateCheckIn = (DateTime?)row["DateCheckIn"];
            var DateCheckOutTemp = row["DateCheckOut"];
            if (DateCheckOutTemp.ToString() != "")
                this.DateCheckOut = (DateTime?)DateCheckOutTemp;
            this.IdReset = (int)row["idReset"];
            this.Status = (int)row["status"];
            this.Discount = (int)row["discount"];
        }

        private int id;
        private DateTime? dateCheckIn;
        private DateTime? dateCheckOut;
        private int idReset;
        private int status;
        private int discount;

        public int Id { get => id; set => id = value; }
        public DateTime? DateCheckIn { get => dateCheckIn; set => dateCheckIn = value; }
        public DateTime? DateCheckOut { get => dateCheckOut; set => dateCheckOut = value; }
        public int IdReset { get => idReset; set => idReset = value; }
        public int Status { get => status; set => status = value; }
        public int Discount { get => discount; set => discount = value; }
    }
}
