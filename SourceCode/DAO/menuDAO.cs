using DACK.DTO;
using System;
using System.Collections.Generic;   
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACK.DAO
{
    public class menuDAO
    {
        //Mô hình singleton
        private static menuDAO instance;
        public static menuDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new menuDAO();
                return menuDAO.instance;
            }
            private set
            {
                menuDAO.instance = value;
            }
        }
        private menuDAO() { }

        //Lấy thông tin menu từ csdl
        public List<Menu> GetListMenu(int id)
        {
            List<Menu> listMenu = new List<Menu>();

            string query = "select p.name, bi.count, p.price, p.price*bi.count as TotalPrice from dbo.Bills b, dbo.BillInfo bi, dbo.Products p where bi.idBill = b.id and bi.idProduct = p.id and b.status = 0 and b.idReset = " + id;
            DataTable data = dataProvider.Instance.excuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Menu menu = new Menu(item);
                listMenu.Add(menu);
            }
            return listMenu;
        }
    }
}
