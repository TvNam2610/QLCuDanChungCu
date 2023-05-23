using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DichVu
    {
        public string MaDichVu { get; set; }
        public string TenDichVu { get; set; }
        public int DonGia { get; set; }


        public DichVu() { }
        public DichVu(string MaDichVu, string tenDichVu, int DonGia)
        {
            this.MaDichVu = MaDichVu;
            this.TenDichVu = tenDichVu;
            this.DonGia = DonGia;
        }
    }
}
