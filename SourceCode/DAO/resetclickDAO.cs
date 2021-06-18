using DACK.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACK.DAO
{
    public class resetclickDAO
    {
        //Mô hình singleton
        private static resetclickDAO instance;
        public static resetclickDAO Instance 
        { 
            get
            {
                if (instance == null)
                    instance = new resetclickDAO();
                return resetclickDAO.instance;
            }
            private set
            {
                resetclickDAO.instance = value;
            }
        }

        //Chiều dài, chiều rộng
        public static int width = 50;
        public static int hight = 50;

        private resetclickDAO() { }

        //Load reset button
        public List<ResetClick> LoadButtonClick()
        {
            List<ResetClick> list = new List<ResetClick>();

            string query = "usp_GetResetButton";
            DataTable data = dataProvider.Instance.excuteQuery(query);
            
            foreach (DataRow item in data.Rows)
            {
                ResetClick rc = new ResetClick(item);
                list.Add(rc);
            }

            return list;
        }
    }
}
