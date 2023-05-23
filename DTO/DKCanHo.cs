using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DKCanHo
    {
        public string MaCH { get; set; }
        public string MaND { get; set; }
        public DateTime NgayDangKi { get; set; }


        public DKCanHo() { }
        public DKCanHo(string MaND, string MaCH, DateTime NgayDangKi)
        {
            this.MaND = MaND;
            this.MaCH = MaCH;
            this.NgayDangKi = NgayDangKi;
        }
    }
}
