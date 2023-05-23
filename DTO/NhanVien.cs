using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVien
    {
        public string MaNV { get; set; }
        public string TenNV { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }

        public string MachucVu { get; set; }

        public string MaNQL { get; set; }

        public NhanVien() { }
        public NhanVien(string MaNV, string TenNV,string DiaChi, string SoDienThoai, string Email, string MaChucVu, string maNQL)
        {
            this.MaNV = MaNV;
            this.TenNV = TenNV;
            this.DiaChi = DiaChi;
            this.SoDienThoai = SoDienThoai;
            this.Email = Email;
            this.MachucVu = MaChucVu;
            this.MaNQL = maNQL;
        }
    }
}

