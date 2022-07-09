using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LapTopOBJ;
using LapTopDAO;

namespace LapTopBUSS
{
   public class NhanVienBuss
    {
        NhanVienDAO nvd = new NhanVienDAO();
        public List<NhanVien> LayNhanVien()
        {
            return nvd.GetNhanVien();
        }
        public string ThemNV(NhanVien nv)
        {
            nv.TenNV = nv.TenNV.Trim();
            return nvd.AddNhanVien(nv);
        }
        public string XoaNV(string id)
        {
            return nvd.DeleteNhanVien(id);
        }
        public string SuaNV(NhanVien s)
        {
            return nvd.EditNhanVien(s);
        }
    }
}
