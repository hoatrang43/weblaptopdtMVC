using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using LapTopOBJ;

namespace LapTopDAO
{
   public class DonHangDAO
    {
        DataHelper dh = new DataHelper();
        public string ThemDonHang(DonHang donhang)
        {
            string sql = "INSERT into DonHang values('" + donhang.MaDonHang + "','" + donhang.MaKH + "','" + donhang.DiaChiNhan+
                 "','" + donhang.NgayDat + "',getdate(),'" + donhang.ThanhTien + "')";
            return dh.ExecuteNonQuery(sql);
        }
        public string AddOrder(DonHang or)
        {
            var sql = $"insert into DonHang values ('{or.MaDonHang}', '{or.MaKH}', N'{or.DiaChiNhan}',getdate(), '{or.ThanhTien}')";
            return dh.ExecuteNonQuery(sql); ;
        }
    }
}
