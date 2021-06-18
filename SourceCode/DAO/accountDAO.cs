using DACK.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACK.DAO
{
    public class accountDAO
    {
        //Mô hình singleton
        private static accountDAO instance;
        public static accountDAO Instance 
        {
            get
            {
                if (instance == null)
                    instance = new accountDAO();
                return accountDAO.instance;
            }
            private set
            {
                accountDAO.instance = value;
            }
        }
        private accountDAO() { }

        //Kiểm tra đăng nhập
        public bool Login(string userName, string passWord)
        {
            string query = "usp_Login @userName , @passWord";

            DataTable result = dataProvider.Instance.excuteQuery(query, new object[] { userName, passWord });

            return result.Rows.Count > 0;
        }

        //Lấy table Account từ csdl
        public account GetAccountByUserName(string userName)
        {
            DataTable data = dataProvider.Instance.excuteQuery("select * from Account where UserName = '" + userName + "'");
            foreach(DataRow item in data.Rows)
            {
                return new account(item);
            }
            return null;
        }

        //Thay đổi password trong csdl
        public bool updateAccount(string username, string password, string newpassword)
        {
            int result = dataProvider.Instance.ExecuteNonQuery("exec usp_UpdateAccount @username , @password , @newPassword", new object[] { username, password, newpassword });
            return result > 0;
        }

        //truy xuất từ bảng Account 2 cột Username và Type
        public DataTable getListAcc()
        {
            return dataProvider.Instance.excuteQuery("select UserName, Type from Account");
        }

        //Thêm tài khoản
        public bool addAccount(string username, int type)
        {
            string query = string.Format("insert into dbo.Account(UserName,type) values (N'{0}', {1})", username, type);
            int result = dataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        //Sửa tài khoản
        public bool editAccount(string username, int type)
        {
            string query = string.Format("update dbo.Account set type = {0} where UserName = N'{1}'", type, username);
            int result = dataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        //Xóa tài khoản
        public bool deleteAccount(string username)
        {
            string query = string.Format("delete dbo.Account where UserName = N'{0}'", username);
            int result = dataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        //Reset password
        public bool resetAccount(string username)
        {
            string query = string.Format("update dbo.Account set Password = N'0' where UserName = N'{0}'", username);
            int result = dataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
