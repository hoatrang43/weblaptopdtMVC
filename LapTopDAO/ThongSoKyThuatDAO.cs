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
    public class ThongSoKyThuatDAO
    {
        DataHelper dh = new DataHelper();
        public List<ThongSoKyThuat> GetThongSoKT()
        {
            DataTable dt = dh.GetDataTable("Select * from ThongSoKyThuat ");
            return ToList(dt);
        }
     
        public List<ThongSoKyThuat> ToList(DataTable dt)
        {
            List<ThongSoKyThuat> l = new List<ThongSoKyThuat>();

            foreach (DataRow dr in dt.Rows)
            {
                ThongSoKyThuat ct = new ThongSoKyThuat(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(),
                    dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), float.Parse( dr[7].ToString()), dr[8].ToString(), dr[9].ToString(),
                     dr[10].ToString(), dr[11].ToString());
                l.Add(ct);

            }
            return l;
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

        public ThongSoKyThuat LayTSKTTheoMa(string masp)
        {
            DataTable dt = dh.GetDataTable("Select*from ThongSoKyThuat where MaSP='" + masp + "'");
            ///Product sp = new Product();
            if (dt.Rows.Count <= 0)
            {
                return null;
            }
            else
            {
                DataRow dr = dt.Rows[0];
                ThongSoKyThuat s = new ThongSoKyThuat(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(),
                    dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), float.Parse(dr[7].ToString()), dr[8].ToString(), dr[9].ToString(),
                     dr[10].ToString(), dr[11].ToString());
                return s;
            }
        }
        public string AddTSKT(ThongSoKyThuat ts)
        {
            string sql = "INSERT into ThongSoKyThuat values('" + ts.MaSP + "','" + ts.CPU + "','" + ts.RAM +
                "','" + ts.BoNho + "','" + ts.CamSau + "','" + ts.CamTruoc + "','" + ts.DungLuongPin + "','" + ts.TrongLuong
                + "','" + ts.DoPhanGiaiManHinh + "','" + ts.Sim + "','" + ts.CongKetNoi + "','" + ts.BaoMat + "')";
            return dh.ExecuteNonQuery(sql);
        }
        //public string ThemTSKT(ThongSoKyThuat tskt)
        //{
        //    var sql = $"insert into ThongSoKyThuat values ('{tskt.MaSP}', '{tskt.CPU}', N'{tskt.RAM}', '{tskt.BoNho}', '{tskt.CamSau}', '{tskt.CamTruoc}', '{tskt.DungLuongPin}', '{tskt.TrongLuong} ', '{tskt.DoPhanGiaiManHinh} ', '{tskt.Sim}', '{tskt.CongKetNoi}', '{tskt.BaoMat}')";
        //    return dh.ExecuteNonQuery(sql); ;
        //}
        public string EditTSKT(ThongSoKyThuat s)
        {
            LayTSKTTheoMa(s.MaSP);
            string st = "update ThongSoKyThuat set CPU='" + s.CPU + "', RAM ='" +
               s.RAM + "', BoNho = '" + s.BoNho + "', CamSau='" + s.CamSau + "', CamTruoc='" +
               s.CamTruoc + "',DungLuongPin='" + s.DungLuongPin + "',TrongLuong='" + s.TrongLuong +"',DoPhanGiaiManHinh='" + s.DoPhanGiaiManHinh
               + "',Sim='" + s.Sim + "',CongKetNoi='" + s.CongKetNoi + "',BaoMat='" + s.BaoMat +
               "' where MaSP='" + s.MaSP + "'";
            return dh.ExecuteNonQuery(st);
        }
        public string DeleteTSKT(string id)
        {
            string st = "delete from ThongSoKyThuat where MaSP='" + id + "'";

            string s = dh.ExecuteNonQuery(st);
            dh.Close();
            return s;

        }
    }
}
