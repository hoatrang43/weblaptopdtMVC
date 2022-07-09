using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LapTopOBJ;
using LapTopDAO;

namespace LapTopBUSS
{
    public class SanPhamBuss
    {
        SanPhamDAO spd = new SanPhamDAO();
        public List<SanPham> LaySanPham()
        {
            return spd.GetSanPham();

        }
        public void ThemSP(SanPham s, ThongSoKyThuat ts)
        {
            spd.AddProduct(s);
            tskt.AddTSKT(ts);

        }    
       
        public void SuaSP1(SanPham s, ThongSoKyThuat ts)
        {
            spd.EditProduct(s);
            tskt.EditTSKT(ts);
        }
        public void XoaSP1(string id)
        {
            spd.DeleteProduct(id);
            tskt.DeleteTSKT(id);
        }

        public string XoaSP(string id)
        {
            return spd.DeleteProduct(id);
        }
        public string SuaSP(SanPham s)
        {
            return spd.EditProduct(s);
        }
        public SanPhamList GetSanPhamP(int pageIndex, int pageSize, string productName)
        {
            return spd.GetSanPhamP(pageIndex, pageSize, productName);
        }
        public SanPham GetSanPham(string proID)
        {
            return spd.GetProduct1(proID);
        }
        public List<SanPham> TimKiemSPTheoTen(string tensp)
        {
            return spd.TimKiemTheoTen(tensp);
        }
        public List<SanPham> LaySanPhamThuongHieu(string maTH)
        {
            return spd.GetSanPhamThuongHieu(maTH);
        }
        public List<SanPham> LaySanPhamLoai(string maloai)
        {
            return spd.GetSanPhamLoai(maloai);
        }
        public List<SanPham> GetSPMoi()
        {
            return spd.LaySPMoi();
        }
        public List<SanPham> GetSPBanChay()
        {
            return spd.LaySPBanChay();
        }
        public List<SanPham> LaySPTheoDong(string madong)
        {
            return spd.GetSPTheoDong(madong);
        }
        ThongSoKyThuatDAO tskt = new ThongSoKyThuatDAO();
      
      
        public List<SanPham> GetProductsP(int pageIndex, int PageSize, string productName)
        {
            return spd.GetSanPhams(pageIndex, PageSize, productName);
        }
    }
}