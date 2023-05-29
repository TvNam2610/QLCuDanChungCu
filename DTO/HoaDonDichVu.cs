using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDonDichVu
    {
        public string madkdv { get; set; }
        public DateTime NgayTT { get; set; }

        public float TongTien { get; set; }

        public string trangthai { get; set; }


        public HoaDonDichVu() { }
        public HoaDonDichVu(string madkdv , DateTime NgayTT, float TongTien, string trangthai)
        {
            this.madkdv = madkdv;
            this.NgayTT = NgayTT;
            this.TongTien = TongTien;
            this.trangthai = trangthai;
        }
    }
}
