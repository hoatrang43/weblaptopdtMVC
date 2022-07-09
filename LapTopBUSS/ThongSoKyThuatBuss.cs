using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LapTopOBJ;
using LapTopDAO;

namespace LapTopBUSS
{
   public class ThongSoKyThuatBuss
    {
        ThongSoKyThuatDAO tskt = new ThongSoKyThuatDAO();
        public List<ThongSoKyThuat> LayThongSoKT()
        {
            return tskt.GetThongSoKT();
        }
        public SanPham GetSanPham(string proID)
        {
            return tskt.GetProduct1(proID);
        }
        public ThongSoKyThuat LayTSKTTheoMa(string masp)
        {
            return tskt.LayTSKTTheoMa(masp);
        }
        public string ThemTSKT(ThongSoKyThuat ts)
        {
            return tskt.AddTSKT(ts);
        }
        public string SuaTSKT(ThongSoKyThuat ts)
        {
            return tskt.EditTSKT(ts);
        }
    }
}
