using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TaiKhoan
    {
        public string TenDangNhap { get; set; }
        public string Matkhau { get; set; }



        public TaiKhoan() { }
        public TaiKhoan(string TenDangNhap, string MatKhau)
        {
            this.Matkhau = Matkhau;
            this.TenDangNhap = TenDangNhap;

        }
    }
}
