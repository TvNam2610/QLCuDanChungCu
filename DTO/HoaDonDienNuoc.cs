﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDonDienNuoc
    {
        public string MaTT { get; set; }
        public string MaGia { get; set; }
        public string MaDN { get; set; }
        public DateTime NgayTT { get; set; }

        public float TongTien { get; set; }

        public string trangthai { get; set; }


        public HoaDonDienNuoc() { }
        public HoaDonDienNuoc(string MaTT, string MaGia, string MaDN, DateTime NgayTT, float TongTien, string trangthai)
        {
            this.MaTT = MaTT;
            this.MaGia = MaGia;
            this.MaDN = MaDN;
            this.NgayTT = NgayTT;
            this.TongTien = TongTien;
            this.trangthai = trangthai;
        }
    }
}
