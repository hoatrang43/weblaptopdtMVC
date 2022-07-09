using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using LapTopOBJ;

namespace LapTopDAO
{
    public class SanPhamDAO
    {
        DataHelper dh = new DataHelper();
        public List<SanPham> GetSanPham()
        {
            DataTable dt = dh.GetDataTable("Select * from SanPham ");
            return ToList(dt);
        }
      
        public List<SanPham> ToList(DataTable dt)
        {
            List<SanPham> l = new List<SanPham>();

            foreach (DataRow dr in dt.Rows)
            {
                SanPham s = new SanPham(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(),
                    dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), int.Parse(dr[7].ToString()));
                l.Add(s);

            }
            return l;
        }
        public string AddProduct(SanPham sp)
        {
            string sql = "INSERT into SanPham values('" + sp.MaDong + "','" + sp.MaSP + "','" + sp.TenSP +
                "','" + sp.SoMay + "','" + sp.SoSeri + "','" + sp.AnhTo + "','" + sp.AnhNho + "','" + sp.Gia + "')";
            return dh.ExecuteNonQuery(sql);
        }

        public string DeleteProduct(string id)
        {
            string st = "delete from SanPham where MaSP='" + id + "'";

            string s = dh.ExecuteNonQuery(st);
            dh.Close();
            return s;

        }
        public string EditProduct(SanPham s)
        {
          
            string st = "update SanPham set MaDong='" + s.MaDong + "', TenSP ='" +
               s.TenSP + "', SoMay = '" + s.SoMay + "', SoSeri='" + s.SoSeri + "', AnhTo='" +
               s.AnhTo + "',AnhNho='" + s.AnhNho + "',Gia='" + s.Gia +
               "' where MaSP='" + s.MaSP + "'";
            return dh.ExecuteNonQuery(st);
        }

        public List<SanPham> LaySPBanChay()

        {
            List<SanPham> l = new List<SanPham>();
            SqlDataReader dr = dh.ExcuteReader("exec SanPhamBanChay ");
            while (dr.Read())
            {
                SanPham sp = new SanPham();
                sp.MaDong = dr["MaDong"].ToString();
                sp.MaSP = dr["MaSP"].ToString();
                sp.TenSP = dr["TenSP"].ToString();
                sp.SoMay = dr["SoMay"].ToString();
                sp.SoSeri = dr["SoSeri"].ToString();
                sp.AnhTo = dr["AnhTo"].ToString();
                sp.AnhNho = dr["AnhNho"].ToString();
                sp.Gia = Convert.ToInt32(dr["Gia"]);
                l.Add(sp);
            }
            return l;

        }
        public List<SanPham> LaySPMoi()

        {
            List<SanPham> l = new List<SanPham>();
            SqlDataReader dr = dh.ExcuteReader("exec SanPhamMoi ");
            while (dr.Read())
            {
                SanPham sp = new SanPham();
                sp.MaDong = dr["MaDong"].ToString();
                sp.MaSP = dr["MaSP"].ToString();
                sp.TenSP = dr["TenSP"].ToString();
                sp.SoMay = dr["SoMay"].ToString();
                sp.SoSeri = dr["SoSeri"].ToString();
                sp.AnhTo = dr["AnhTo"].ToString();
                sp.AnhNho = dr["AnhNho"].ToString();
                sp.Gia = Convert.ToInt32(dr["Gia"]);
                l.Add(sp);
            }
            return l;

        }
        public List<SanPham> GetSanPhams( int pageIndex, int pageSize, string productName)

        {
            List<SanPham> l = new List<SanPham>();
            SqlDataReader dr = dh.ExcuteReader("exec GetSanPham " + pageIndex + "," + pageSize + ",'" + productName + "'");
            while (dr.Read())
            {
                SanPham sp = new SanPham();
                sp.MaDong = dr["MaDong"].ToString();
                sp.MaSP = dr["MaSP"].ToString();
                sp.TenSP = dr["TenSP"].ToString();
                sp.SoMay = dr["SoMay"].ToString();
                sp.SoSeri = dr["SoSeri"].ToString();             
                sp.AnhTo = dr["AnhTo"].ToString();
                sp.AnhNho = dr["AnhNho"].ToString();
                sp.Gia = Convert.ToInt32(dr["Gia"]);
                l.Add(sp);
            }
            return l;
           
        }
        public SanPhamList GetSanPhamP(int pageIndex, int pageSize, string productName)
        {
            SanPhamList spl = new SanPhamList();
            List<SanPham> l = new List<SanPham>();
            SqlDataReader dr = dh.StoreReaders("GetSanPham", pageIndex, pageSize, productName);
            while (dr.Read())//lấy về các sản phẩm của trang
            {
                SanPham s = new SanPham(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(),
                    dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), int.Parse(dr[7].ToString()));
                l.Add(s);
            }
            spl.SanPhams = l;
            dr.NextResult();
            while (dr.Read())
            {
                spl.totalCount = dr["totalCount"].ToString();
            }
            return spl;
        }
        public SanPham GetProduct1(string proID)
        {
            DataTable dt = dh.GetDataTable("Select*from SanPham where MaSP='" + proID + "'");
           
            if (dt.Rows.Count <= 0)
            {
                return null;
            }
            else
            {
                DataRow dr = dt.Rows[0];
                SanPham s = new SanPham(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(),
                    dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), int.Parse(dr[7].ToString()));
                return s;
            }
        }

        public List<SanPham> TimKiemTheoTen(string tensp)
        {
            List<SanPham> l = new List<SanPham>();
            SqlDataReader dr = dh.ExcuteReader("exec sp_TimKiemTheoTen '" + tensp + "'");
            while (dr.Read())
            {
                SanPham sp = new SanPham();
                sp.MaDong = dr["MaDong"].ToString();
                sp.MaSP = dr["MaSP"].ToString();
                sp.TenSP = dr["TenSP"].ToString();
                sp.SoMay = dr["SoMay"].ToString();
                sp.SoSeri = dr["SoSeri"].ToString();
                sp.AnhTo = dr["AnhTo"].ToString();
                sp.AnhNho = dr["AnhNho"].ToString();
                sp.Gia = Convert.ToInt32(dr["Gia"]);
                l.Add(sp);
            }
            return l;
        }
        public List<SanPham> GetSanPhamThuongHieu(string maTH)
        {
            List<SanPham> l = new List<SanPham>();
            SqlDataReader dr = dh.ExcuteReader("exec DSSPTheoThuongHieu '" +  maTH +  "'");
            while (dr.Read())
            {
                SanPham sp = new SanPham();
                sp.MaDong = dr["MaDong"].ToString();
                sp.MaSP = dr["MaSP"].ToString();
                sp.TenSP = dr["TenSP"].ToString();
                sp.SoMay = dr["SoMay"].ToString();
                sp.SoSeri = dr["SoSeri"].ToString();
                sp.AnhTo = dr["AnhTo"].ToString();
                sp.AnhNho = dr["AnhNho"].ToString();
                sp.Gia = Convert.ToInt32(dr["Gia"]);
                l.Add(sp);
            }
            return l;
        }
        public List<SanPham> GetSanPhamLoai(string maloai)
        {
            List<SanPham> l = new List<SanPham>();
            SqlDataReader dr = dh.ExcuteReader("exec DSSPTheoLoai '" + maloai + "'");
            while (dr.Read())
            {
                SanPham sp = new SanPham();
                sp.MaDong = dr["MaDong"].ToString();
                sp.MaSP = dr["MaSP"].ToString();
                sp.TenSP = dr["TenSP"].ToString();
                sp.SoMay = dr["SoMay"].ToString();
                sp.SoSeri = dr["SoSeri"].ToString();
                sp.AnhTo = dr["AnhTo"].ToString();
                sp.AnhNho = dr["AnhNho"].ToString();
                sp.Gia = Convert.ToInt32(dr["Gia"]);
                l.Add(sp);
            }
            return l;
        }
        public List<SanPham> GetSPTheoDong(string madong)
        {
            string sqlselect;
            if (madong != "")
            {
                sqlselect = "Select*from SanPham where MaDong='" + madong + "'";
            }
            else
            {
                sqlselect = "Select*from SanPham";
            }
            DataTable dt = dh.GetDataTable(sqlselect);
            return ToList(dt);
        }
        
      
    }
}