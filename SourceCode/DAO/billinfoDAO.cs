using DACK.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DACK.DAO
{
    //Mô hình singleton
    public class billinfoDAO
    {
        private static billinfoDAO instance;
        public static billinfoDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new billinfoDAO();
                return billinfoDAO.instance;
            }
            private set
            {
                billinfoDAO.instance = value;
            }
        }
        private billinfoDAO() { }

        //Lấy danh sách chi tiết hóa đơn từ csdl
        public List<BillInfo> GetListBillInfo(int id)
        {
            List<BillInfo> list = new List<BillInfo>();

            DataTable data = dataProvider.Instance.excuteQuery("select * from dbo.BillInfo where idBill = " + id);

            foreach(DataRow item in data.Rows)
            {
                BillInfo bi = new BillInfo(item);
                list.Add(bi);
            }

            return list;
        }

        //Thêm chi tiết hóa đơn
        public void InsertBillInfo(int idBill, int idProduct, int count)
        {
            dataProvider.Instance.ExecuteNonQuery("usp_InsertBillInfo @idBill , @idProduct , @count", new object[] { idBill, idProduct, count });
        }

        //Xóa chi tiết hóa đơn
        public void deleteBillinfo(int id)
        {
            dataProvider.Instance.excuteQuery("delete dbo.BillInfo where idProduct = " + id);
        }


    }
}
