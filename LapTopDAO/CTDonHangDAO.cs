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
    public class CTDonHangDAO
    {
        DataHelper dh = new DataHelper();
        public void LuuCTDonHang(List<ChiTietDonHang> ct)
        {
            for (int i = 0; i < ct.Count; i++)
            {
                string sql = "INSERT into CTDonHang values('" + ct[i].MaSP + "','" + ct[i].MaDonHang + "','" + ct[i].SoLuong +
               "','" + ct[i].DonGia + "')";
                dh.ExecuteNonQuery(sql);
            }
        }
        public void SaveDetailOrdered(List<ChiTietDonHang> lct)
        {
            for (int i = 0; i < lct.Count; i++)
            {
                var sql = $"insert into CTDonHang values ('{lct[i].MaSP}', '{lct[i].MaDonHang}', N'{lct[i].SoLuong}', '{lct[i].DonGia}')";
                dh.ExecuteNonQuery(sql);
            }
        }
    }
}
