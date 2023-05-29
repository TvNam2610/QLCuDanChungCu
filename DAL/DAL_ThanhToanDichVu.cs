using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_ThanhToanDichVu
    {
        public DataTable getHoaDonDichVu()
        {
            string query = $"SP_getHoaDonDV";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        
        public DataTable getMaDK()
        {
            string query = $"Select * from DangKiDichVu";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        
        public DataTable XuatHoaDonDichVu(string matt)
        {
            string query = $"SP_XuatHDDV @MaTT";
            return DataProvider.Instance.ExecuteQuery(query, new object[]
            {
                matt
            });
        }

        public void addHoaDonDichVu(HoaDonDichVu hd)
        {
            string query = $"SP_AddHoaDonDichVu  @madkdv , @ngayTT , @tongTien , @trangThai";
            DataProvider.Instance.ExecuteQuery(query, new object[]
            {
                hd.madkdv,
                hd.NgayTT,
                hd.TongTien,
                hd.trangthai
           });
        }
        
    }
}
