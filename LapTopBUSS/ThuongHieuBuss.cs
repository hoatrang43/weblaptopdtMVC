using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LapTopOBJ;
using LapTopDAO;
namespace LapTopBUSS
{
    public class ThuongHieuBuss
    {
        ThuongHieuDAO thd = new ThuongHieuDAO();
        public List<ThuongHieu> LayThuongHieu()
        {
            return thd.GetThuongHieu();
        }
        public List<ThuongHieu> LayThuongHieuTheoLoai(string maloai)
        {
            return thd.GetThuongHieuTheoLoai(maloai);
        }
        public string AddThuongHieu(ThuongHieu th)
        {
            return thd.AddThuongHieu(th);
        }

    }

}