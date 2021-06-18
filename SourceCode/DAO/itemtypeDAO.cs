using DACK.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACK.DAO
{
    public class itemtypeDAO
    {
        //Mô hình singleton
        private static itemtypeDAO instance;
        public static itemtypeDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new itemtypeDAO();
                return itemtypeDAO.instance;
            }
            private set
            {
                itemtypeDAO.instance = value;
            }
        }
        private itemtypeDAO() { }

        //Lấy loại mặt hàng theo id mặt hàng
        public List<ItemType> GetListItemTypeByIDItem(int id)
        {
            List<ItemType> list = new List<ItemType>();

            string query = "select * from dbo.ItemType where idItem = " + id;
            DataTable data = dataProvider.Instance.excuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                ItemType type = new ItemType(item);
                list.Add(type);
            }

            return list;
        }

        //Lấy mặt hàng theo tên mặt hàng
        public List<ItemType> GetListItems(string itemName)
        {
            List<ItemType> list = new List<ItemType>();

            string query = "select * from dbo.ItemType as a, dbo.Items as b where a.idItem = b.id and b.name = N'" + itemName + "'";
            DataTable data = dataProvider.Instance.excuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                ItemType type = new ItemType(item);
                list.Add(type);
            }

            return list;
        }

        //Lấy loại mặt hàng theo id
        public ItemType getItemTypeById(int id)
        {
            ItemType itemtype = null;

            string query = "select * from dbo.ItemType where id = " + id;
            DataTable data = dataProvider.Instance.excuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                itemtype = new ItemType(item);
                return itemtype;
            }

            return itemtype;
        }

        //Thêm thể loại sách
        public bool addBookCate(string name)
        {
            string query = string.Format("insert into dbo.ItemType(name, idItem) values (N'{0}', 1)", name);
            int result = dataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        //Sửa thông tin thể loại sách
        public bool editBookCate(int id, string name)
        {
            string query = string.Format("update dbo.ItemType set name = N'{0}' where idItem = 1 and id = {1}", name, id);
            int result = dataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        //Xóa thể loại sách
        public bool deleteBookCate(int id)
        {
            string query = string.Format("delete dbo.ItemType where id = " + id);
            int result = dataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        //Thêm loại văn phòng phẩm
        public bool addStationeryType(string name)
        {
            string query = string.Format("insert into dbo.ItemType(name, idItem) values (N'{0}', 2)", name);
            int result = dataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        //Sủa thông tin văn phòng phẩm
        public bool editStationeryType(int id, string name)
        {
            string query = string.Format("update dbo.ItemType set name = N'{0}' where idItem = 2 and id = {1}", name, id);
            int result = dataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        //Xóa loại văn phòng phẩm
        public bool deleteStationeryType(int id)
        {
            string query = string.Format("delete dbo.ItemType where id = " + id);
            int result = dataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
