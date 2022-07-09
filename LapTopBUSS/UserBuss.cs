using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LapTopOBJ;
using LapTopDAO;

namespace LapTopBUSS
{
   public class UserBuss
    {
        UserDAO ud = new UserDAO();
        KhachHangDAO kd = new KhachHangDAO();
        public Users CheckLogin(string manv, string pw)
        {
            return ud.GetUser(manv, pw);
        }

        public KhachHang CheckKhachHang(string makh, string pw)
        {
            return kd.GetKhachHang(makh, pw);
        }
        public KhachHang ReadCustomer()
        {
            return kd.ReadCustomer();
        }
        public string ThemKH(KhachHang kh)
        {
            string mkh = Guid.NewGuid().ToString();
            kh.MaKH = mkh;
            return kd.AddKhachHang(kh);
        }
        public List<KhachHang> GetKhachHang()
        {
            return kd.LayKhachHang();
        }
    }
}
