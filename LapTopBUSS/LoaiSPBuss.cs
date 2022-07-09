using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LapTopOBJ;
using LapTopDAO;
namespace LapTopBUSS
{
    public class LoaiSPBuss
    {
        LoaiSPDAO loaid = new LoaiSPDAO();
        public List<LoaiSanPham> LayLoaiSP()
        {
            return loaid.GetLoaiSP();
        }
    }
}