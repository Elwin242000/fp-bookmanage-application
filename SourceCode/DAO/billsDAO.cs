using DACK.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACK.DAO
{
    public class billsDAO
    {
        //Mô hình singleton
        private static billsDAO instance;
        public static billsDAO Instance 
        { 
            get
            {
                if (instance == null)
                    instance = new billsDAO();
                return billsDAO.instance;
            }
            private set
            {
                billsDAO.instance = value;
            }
        }
        private billsDAO() { }

        //Khởi tạo bill mới
        public int GetUncheckedBillID(int id)
        {
            DataTable data = dataProvider.Instance.excuteQuery("select * from dbo.Bills where idReset = " + id + " and status = 0");

            if (data.Rows.Count > 0)
            {
                Bills bill = new Bills(data.Rows[0]);
                return bill.Id;
            }
            return -1;
        }

        //Thêm bill
        public void InsertBills(int id)
        {
            dataProvider.Instance.excuteQuery("exec usp_InsertBill @idReset", new object[] { id });
        }

        //Lấy bill có id lớn nhất
        public int GetMaxIDBill()
        {
            try 
            {
                return (int)dataProvider.Instance.excuteScalar("select MAX(id) from dbo.Bills");
            }
            catch 
            {
                return 1;
            }
        }

        //thanh toán hóa đơn, update bên csdl
        public void Payment(int id, int discount, float totalprice)
        {
            string query = "update dbo.Bills set DateCheckOut = GETDATE(), status = 1, " + "discount = " + discount + ", TotalPrice = " + totalprice + " where id = " + id ;
            dataProvider.Instance.ExecuteNonQuery(query);
        }

        //Lấy bill theo ngày
        public DataTable GetListBillsByDate(DateTime checkin, DateTime checkout)
        {
            return dataProvider.Instance.excuteQuery("exec usp_ListBillDate @checkIn , @checkOut", new object[] { checkin, checkout });
        }
    }
}
