using DACK.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACK.DAO
{
    public class supplierDAO
    {
        //Mô hình singleton
        private static supplierDAO instance;
        public static supplierDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new supplierDAO();
                return supplierDAO.instance;
            }
            private set
            {
                supplierDAO.instance = value;
            }
        }
        private supplierDAO() { }

        //Lấy ds nhà cung cấp
        public List<Suppliers> GetListSuppliers()
        {
            List<Suppliers> list = new List<Suppliers>();

            string query = "select * from dbo.Suppliers";
            DataTable data = dataProvider.Instance.excuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Suppliers sup = new Suppliers(item);
                list.Add(sup);
            }

            return list;
        }

        //Lấy ds nhà cung cấp theo id
        public Suppliers GetSupplierById(int id)
        {
            Suppliers sup = null;

            string query = "select * from dbo.Suppliers where id = " + id;
            DataTable data = dataProvider.Instance.excuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                sup = new Suppliers(item);
                return sup;
            }
            return sup;
        }

        //Thêm nhà cung cấp
        public bool addSupplier(string name, string address, string phone)
        {
            string query = string.Format("insert into dbo.Suppliers(name, address, phone) values (N'{0}', N'{1}', N'{2}')", name, address, phone);
            int result = dataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        //Sửa thông tin nhà cung cấp
        public bool editSupplier(int id, string name, string address, string phone)
        {
            string query = string.Format("update dbo.Suppliers set name = N'{0}', address = N'{1}', phone = N'{2}' where id = {3}", name, address, phone, id);
            int result = dataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        //Xóa nhà cung cấp
        public bool deleteSupplier(int id)
        {
            string query = string.Format("delete dbo.Suppliers where id = {0}", id);
            int result = dataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
