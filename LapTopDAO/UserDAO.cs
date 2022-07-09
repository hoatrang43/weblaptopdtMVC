using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using LapTopOBJ;

namespace LapTopDAO
{
    public class UserDAO
    {
        DataHelper dh = new DataHelper();
        public Users GetUser(string UserId, string pas)
        {
            string sql = "select*from Users where (MaNV ='" + UserId + "') and (Password='" + pas + "')";
            DataTable dt = dh.GetDataTable(sql);
            if (dt.Rows.Count <= 0)
                return null;
            else
            {
                Users us = new Users(dt.Rows[0].ToString(), dt.Rows[0][1].ToString(),
                    dt.Rows[0][2].ToString());
                return us;
            }

        }
    }
}
