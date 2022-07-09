using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LapTopOBJ
{
    public class CauHinh
    {
        public string MaCauHinh { get; set; }
        public string BoNho { get; set; }
        public string Anh { get; set; }
        public string MaDong { get; set; }
        public CauHinh(string macauhinh, string bonho, string anh, string madong)
        {
            this.MaCauHinh = macauhinh;
            this.BoNho = bonho;
            this.Anh = anh;
            this.MaDong = madong;
        }
    }
}