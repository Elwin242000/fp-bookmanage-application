using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACK.DTO
{
    public class account
    {
        public account (string UserName, int Type, string Password = null)
        {
            this.UserName = UserName;
            this.Type = Type;
            this.PassWord = Password;
        }

        //truy vấn csdl
        public account(DataRow row)
        {
            this.UserName = row["UserName"].ToString();
            this.Type = (int)row["Type"];
            this.PassWord = row["Password"].ToString();
        }

        private string userName;
        private string passWord;
        private int type;

        public string UserName { get => userName; set => userName = value; }
        public string PassWord { get => passWord; set => passWord = value; }
        public int Type { get => type; set => type = value; }
    }
}
