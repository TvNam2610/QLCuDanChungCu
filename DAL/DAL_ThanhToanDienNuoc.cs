using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_ThanhToanDienNuoc
    {
        public DataTable getHoaDonDienNuoc()
        {
            string query = $"SP_getHDDN";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public DataTable getTongTien(string mahoadon)
        {
            string query = $"SP_getTongtienHoaDon @mahoadon";
            return DataProvider.Instance.ExecuteQuery(query, new object[]
            {
                mahoadon
            });
        }

        public DataTable getGia()
        {
            string query = $"select GiaDien, GiaNuoc from GiaDienNuoc ";
            return DataProvider.Instance.ExecuteQuery(query);
        }


        public DataTable getCanHo()
        {
            string query = $"Select * from CanHo";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public DataTable XuatHoaDonDienNuoc(string matt)
        {
            string query = $"SP_XuatHDDN @MaTT";
            return DataProvider.Instance.ExecuteQuery(query, new object[]
            {
                matt
            });
        }
       
        public void addHoaDonDienNuoc(DienNuoc dn, HoaDonDienNuoc hd)
        {
            string query = $"SP_AddHoaDonDienNuoc @maTT , @maCH , @soDienTieuThu , @soNuocTieuThu , @ngayTT , @tongTien , @trangThai";
            DataProvider.Instance.ExecuteQuery(query, new object[]
            {
                hd.MaTT,
                dn.MaCH,
                dn.SoDienTieuThu,
                dn.SoNuocTieuThu,
                hd.NgayTT,
                hd.TongTien,
                hd.trangthai
           });
        }
      
    }
}
