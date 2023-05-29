using BUS;
using DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestNhanVien
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestThemNhanVien_ThanhCong()
        {
            BUS_NhanVien busnv = new BUS_NhanVien();

            NhanVien nv = new NhanVien()
            {
                MaNV = "nv015",
                TenNV = "Hoan",
                DiaChi = "Hưng Yên",
                SoDienThoai = "098766421",
                Email = "h3@gmail.com",
                MachucVu = "cv03" ,
                MaNQL = "ql01"
            };
            bool result = busnv.addNhanVien(nv);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestThemNhanVien_ThatBai()
        {
            BUS_NhanVien busnv = new BUS_NhanVien();

            NhanVien kh = new NhanVien()
            {
                MaNV = "nv015",
                TenNV = "Hoan",
                DiaChi = "Hưng Yên",
                SoDienThoai = "098766421",
                Email = "h3@gmail.com",
                MachucVu = "cv03",
                MaNQL = "ql01"
            };
            bool result = busnv.addNhanVien(kh);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestSuaNhanVien_ThanhCong()
        {
            BUS_NhanVien busnv = new BUS_NhanVien();

            NhanVien kh = new NhanVien()
            {
                MaNV = "nv015",
                TenNV = "Hoan tran",
                DiaChi = "Hưng Yên",
                SoDienThoai = "098766421",
                Email = "h3@gmail.com",
                MachucVu = "cv03",
                MaNQL = "ql01"
            };
            bool result = busnv.editNhanVien(kh);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestSuaNhanVien_Thatbai()
        {
            BUS_NhanVien busnv = new BUS_NhanVien();

            NhanVien kh = new NhanVien()
            {
                MaNV = "nv016",
                TenNV = "Hoan tran",
                DiaChi = "Hưng Yên",
                SoDienThoai = "098766421",
                Email = "h3@gmail.com",
                MachucVu = "cv03",
                MaNQL = "ql01"
            };
            bool result = busnv.editNhanVien(kh);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestXoaNhanVien_ThatBai()
        {
            BUS_NhanVien busnv = new BUS_NhanVien();
            string manv = "nv01000";

            bool result = busnv.deleteNhanVien(manv);
            Assert.AreEqual(result, false);
        }


    }
}
