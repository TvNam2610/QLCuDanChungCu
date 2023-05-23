using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NguoiDan
    {
        public string MaND { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string SoDienThoai { get; set; }

        public string DiaChi { get; set; }

        public NguoiDan() { }
        public NguoiDan(string MaND, string HoTen, DateTime NgaySinh, string GioiTinh, string SoDienThoai, string DiaChi)
        {
            this.MaND = MaND;
            this.HoTen = HoTen;
            this.NgaySinh = NgaySinh;
            this.GioiTinh = GioiTinh;
            this.SoDienThoai = SoDienThoai;
            this.DiaChi = DiaChi;
        }
    }
}
