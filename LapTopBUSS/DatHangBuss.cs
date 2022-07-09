using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LapTopOBJ;
using LapTopDAO;

namespace LapTopBUSS
{
   public class DatHangBuss
    {
        DonHangDAO dh = new DonHangDAO();
        CTDonHangDAO ctdh = new CTDonHangDAO();
        KhachHangDAO kh = new KhachHangDAO();
        public void DatHang(KhachHang k, DonHang d, List<ChiTietDonHang> ct)
        {
            //tạo mã đơn hàng
            string mdh = Guid.NewGuid().ToString();
            d.MaDonHang = mdh;
            //gán mã đơn hàng cho ctdh
            for(int i=0; i < ct.Count; i++)
            {
                ct[i].MaDonHang = mdh;
            }
            dh.AddOrder(d);
            ctdh.SaveDetailOrdered(ct);
            //dh.ThemDonHang(d);
            //ctdh.LuuCTDonHang(ct);
        }
     
    }
}
