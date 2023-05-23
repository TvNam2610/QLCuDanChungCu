using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CanHo
    {
        public string MaCH { get; set; }
        public int TangLau { get; set; }
        public string MaToaNha { get; set; }
        

        public CanHo() { }
        public CanHo(string MaCH, int TangLau, string MaToaNha)
        {
            this.MaCH = MaCH;
            this.TangLau = TangLau;
            this.MaToaNha = MaToaNha;
        }
    }
}
