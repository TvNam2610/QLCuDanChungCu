using BUS;
using DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace TestDangKiDichVu
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestThemDV_NhapDung()
        {
            BUS_DichVu busdv = new BUS_DichVu();

            DichVu dv = new DichVu()
            {
                MaDichVu = "dv09",
                TenDichVu = "Dịch vụ trông",
                DonGia = 50000
            };

            bool result = busdv.addDichVu(dv);
            Assert.AreEqual(result, true);
        }
        [TestMethod]
        public void TestThemDV_DeTrong()
        {
            BUS_DichVu bUS_DK = new BUS_DichVu();

            DichVu dv = new DichVu()
            {
                MaDichVu = "",
                TenDichVu = "",
                DonGia = -1
            };

            bool result = bUS_DK.addDichVu(dv);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestThemDV_NhapSaiMadv()
        {
            BUS_DichVu bUS_DK = new BUS_DichVu();

            DichVu dv = new DichVu()
            {
                MaDichVu = "dv06",
                TenDichVu = "Dịch vụ chơi ",
                DonGia = 20000
            };

            bool result = bUS_DK.addDichVu(dv);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestSuaDV_ThanhCong()
        {
            BUS_DichVu bUS_DK = new BUS_DichVu();

            DichVu dv = new DichVu()
            {
                MaDichVu = "dv06",
                TenDichVu = "Dịch vụ chơi ",
                DonGia = 20000
            };

            bool result = bUS_DK.editDichVu(dv);
            Assert.AreEqual(result, true);
        }
        
        [TestMethod]
        public void TestXoaDV_ThanhCong()
        {
            BUS_DichVu bUS_DK = new BUS_DichVu();
            string madichvu = "dv05";
            

            bool result = bUS_DK.deleteDichVu(madichvu);
            Assert.AreEqual(result, false);
        }
        public void TestXoaDV_ThatBai()
        {
            BUS_DichVu bUS_DK = new BUS_DichVu();
            string maDichVu = "";

            bool result = bUS_DK.deleteDichVu( maDichVu);
            Assert.AreEqual(result, true);
        }


    }
}
