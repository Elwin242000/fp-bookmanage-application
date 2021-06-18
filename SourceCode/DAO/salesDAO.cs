using DACK.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACK.DAO
{
    public class salesDAO
    {
        //Mô hình singleton
        private static salesDAO instance;
        public static salesDAO Instance 
        { 
            get
            {
                if (instance == null)
                    instance = new salesDAO();
                return salesDAO.instance;
            }
            private set
            {
                salesDAO.instance = value;
            }
        }
        private salesDAO() { }

        //Lấy thông tin số lượng sản phẩm sách
        public List<sales> GetCountBookSales(DateTime checkIn, DateTime checkOut)
        {
            List<sales> list = new List<sales>();

            string query = string.Format("select a.name, sum(count) as [count] from dbo.Products a, dbo.Bills b, dbo.BillInfo c where c.idBill = b.id and c.idProduct = a.id and b.DateCheckIn >= '{0}' and b.DateCheckOut <= '{1}' and b.status = 1 and a.idItem = 1  group by a.name", checkIn, checkOut);
            DataTable data = dataProvider.Instance.excuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                sales bi = new sales(item);
                list.Add(bi);
            }

            return list;
        }

        //Lấy thông tin số lượng sản phẩm vật phẩm văn phòng
        public List<sales> GetCountStationerySales(DateTime checkIn, DateTime checkOut)
        {
            List<sales> list = new List<sales>();

            string query = string.Format("select a.name, sum(count) as [count] from dbo.Products a, dbo.Bills b, dbo.BillInfo c where c.idBill = b.id and c.idProduct = a.id and b.DateCheckIn >= '{0}' and b.DateCheckOut <= '{1}' and b.status = 1 and a.idItem = 2  group by a.name", checkIn, checkOut);
            DataTable data = dataProvider.Instance.excuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                sales bi = new sales(item);
                list.Add(bi);
            }

            return list;
        }
    }
}
