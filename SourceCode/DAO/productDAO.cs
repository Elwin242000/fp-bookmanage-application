using DACK.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACK.DAO
{
    public class productDAO
    {
        //Mô hình singleton
        private static productDAO instance;
        public static productDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new productDAO();
                return productDAO.instance;
            }
            private set
            {
                productDAO.instance = value;
            }
        }
        private productDAO() { }

        //Lấy thông tin sản phẩm theo id loại
        public List<Product> GetListProductByIDItemType(int id)
        {
            List<Product> list = new List<Product>();

            string query = "select * from dbo.Products where idItemType = " + id;
            DataTable data = dataProvider.Instance.excuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Product pro = new Product(item);
                list.Add(pro);
            }

            return list;
        }

        //Lấy danh sách sản phẩm
        public List<Product> GetListProducts(string name)
        {
            List<Product> list = new List<Product>();

            string query = "select c.* from dbo.Items a, dbo.ItemType b, dbo.Products c, dbo.Suppliers d where b.idItem = a.id and c.idItem = a.id and c.idItemType = b.id and c.idSupplier = d.id and a.name = N'" + name + "' ";
            DataTable data = dataProvider.Instance.excuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Product pro = new Product(item);
                list.Add(pro);
            }

            return list;
        }
        
        //Thêm sách
        public bool addBook(string name, string author, int idtype, int idsup, float price)
        {
            string query = string.Format("insert into dbo.Products(name, author, idItem, idItemType, idSupplier, price) values (N'{0}', N'{1}', 1, {2}, {3}, {4})", name, author, idtype, idsup, price);
            int result = dataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        //Sửa thông tin sách
        public bool editBook(int idBook, string name, string author, int idtype, int idsup, float price)
        {
            string query = string.Format("update dbo.Products set name = N'{0}', author = N'{1}', idItemType = {2}, idSupplier = {3}, price = {4} where id = {5}", name, author, idtype, idsup, price, idBook);
            int result = dataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        //Xóa sách
        public bool deteteBook(int idBook)
        {
            billinfoDAO.Instance.deleteBillinfo(idBook);
            string query = string.Format("delete dbo.Products where id = {0}", idBook);
            int result = dataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        //Tìm kiếm sách
        public List<Product> SearchBookByName(string name)
        {
            List<Product> list = new List<Product>();

            string query = string.Format("select c.* from dbo.Items a, dbo.ItemType b, dbo.Products c, dbo.Suppliers d where b.idItem = a.id and c.idItem = a.id and c.idItemType = b.id and c.idSupplier = d.id and a.name = N'Book' and c.name like N'%{0}%'", name);
            DataTable data = dataProvider.Instance.excuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Product pro = new Product(item);
                list.Add(pro);
            }

            return list;
        }

        //Thêm văn phòng phẩm
        public bool addStationery(string name, int idtype, int idsup, float price)
        {
            string query = string.Format("insert into dbo.Products(name, idItem, idItemType, idSupplier, price) values (N'{0}', 2, {1}, {2}, {3})", name, idtype, idsup, price);
            int result = dataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        //Sửa thông tin văn phòng phẩm
        public bool editStationery(int idStationery, string name, int idtype, int idsup, float price)
        {
            string query = string.Format("update dbo.Products set name = N'{0}', idItemType = {1}, idSupplier = {2}, price = {3} where id = {4}", name, idtype, idsup, price, idStationery);
            int result = dataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        //Xóa văn phòng phẩm
        public bool deteteStationery(int idStationery)
        {
            billinfoDAO.Instance.deleteBillinfo(idStationery);
            string query = string.Format("delete dbo.Products where id = {0}", idStationery);
            int result = dataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        //Tìm kiếm văn phòng phẩm
        public List<Product> SearchStationeryByName(string name)
        {
            List<Product> list = new List<Product>();

            string query = string.Format("select c.* from dbo.Items a, dbo.ItemType b, dbo.Products c, dbo.Suppliers d where b.idItem = a.id and c.idItem = a.id and c.idItemType = b.id and c.idSupplier = d.id and a.name = N'Stationery' and c.name like N'%{0}%'", name);
            DataTable data = dataProvider.Instance.excuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Product pro = new Product(item);
                list.Add(pro);
            }

            return list;
        }
    }
}
