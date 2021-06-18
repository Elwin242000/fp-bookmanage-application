using DACK.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACK.DAO
{
    public class itemDAO
    {
        private static itemDAO instance;
        public static itemDAO Instance 
        { 
            get
            {
                if (instance == null)
                    instance = new itemDAO();
                return itemDAO.instance;
            }
            private set
            {
                itemDAO.instance = value;
            }
        }
        private itemDAO() { }

        //Lấy danh sách các mặt hàng
        public List<Items> GetListItem()
        {
            List<Items> list = new List<Items>();

            string query = "select * from dbo.Items";
            DataTable data = dataProvider.Instance.excuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Items Item = new Items(item);
                list.Add(Item);
            }

            return list;
        }

        //Thêm mặt hàng
        public bool addItem(string name)
        {
            string query = string.Format("insert into dbo.Items(name) values (N'{0}')", name);
            int result = dataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        //Sửa thông tin mặt hàng
        public bool editItem(int id, string name)
        {
            string query = string.Format("update dbo.Items set name = N'{0}' where id = {1}", name, id);
            int result = dataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        //Xóa mặt hàng
        public bool deleteItem(int id)
        {
            string query = string.Format("delete dbo.Items where id = {0}", id);
            int result = dataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
