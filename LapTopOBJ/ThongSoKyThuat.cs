using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LapTopOBJ
{
    public class ThongSoKyThuat
    {
        public string MaSP { get; set; }
        public string CPU{ get; set; }
        public string RAM { get; set; }
        public string BoNho { get; set; }
        public string CamSau { get; set; }
        public string CamTruoc { get; set; }
        public string DungLuongPin { get; set; }
        public float TrongLuong { get; set; }
        public string DoPhanGiaiManHinh { get; set; }
        public string Sim { get; set; }
        public string CongKetNoi { get; set; }
        public string BaoMat { get; set; }
       
        public ThongSoKyThuat() { }
        public ThongSoKyThuat(string masp, string cpu, string ram, string bonho, string camsau, string camtruoc,
            string DLpin, float trongluong, string dophangiai, string sim, string ketnoi, string baomat)
        {
            this.MaSP = masp;
            this.CPU = cpu;
            this.RAM = ram;
            this.BoNho = bonho;
            this.CamSau = camsau;
            this.CamTruoc = camtruoc;
            this.DungLuongPin = DLpin;
            this.TrongLuong = trongluong;
            this.DoPhanGiaiManHinh = dophangiai;
            this.Sim = sim;
            this.CongKetNoi = ketnoi;
            this.BaoMat = baomat;          
        }
    }
}