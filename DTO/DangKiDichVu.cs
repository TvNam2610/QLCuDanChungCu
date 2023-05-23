using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DangKiDichVu
    {
        public string MaDKDV { get; set; }
        public string MaCH { get; set; }
        public string MaDichVu { get; set; }
        public DateTime NgayDK { get; set; }
        public DateTime NgayHetHan { get; set; }


        public DangKiDichVu() { }
        public DangKiDichVu(string MaDKDV, string MaCH, string MaDichVu, DateTime NgayDK, DateTime NgayHetHan)
        {
            this.MaDKDV = MaDKDV;
            this.MaCH = MaCH;
            this.MaDichVu = MaDichVu;
            this.NgayDK = NgayDK;
            this.NgayHetHan = NgayHetHan;
        }
    }
}
