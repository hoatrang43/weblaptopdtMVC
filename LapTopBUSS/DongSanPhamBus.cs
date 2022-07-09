using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LapTopOBJ;
using LapTopDAO;
namespace LapTopBUSS
{
    public class DongSanPhamBus
    {
        DongSanPhamDAO dongDAO = new DongSanPhamDAO();
        public List<DongSanPham> LayDongSanPham()
        {
            return dongDAO.GetDongSanPham();
        }

    }
}