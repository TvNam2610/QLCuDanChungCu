using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DienNuoc
    {
        public string MaDN { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int SoDienTieuThu { get; set; }
        public int SoNuocTieuThu { get; set; }

        public string MaCH { get; set; }

        public DienNuoc() { }
        public DienNuoc(string MaDN, int Month, int Year, int SoDienTieuThu, int SoNuocTieuThu, string MaCH)
        {
            this.MaDN = MaDN;
            this.Month = Month;
            this.Year = Year;
            this.SoDienTieuThu = SoDienTieuThu;
            this.SoNuocTieuThu = SoNuocTieuThu;
            this.MaCH = MaCH;
        }
    }
}
