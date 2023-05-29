using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_DichVu
    {
        public DataTable getDichVu()
        {
            string query = $"Select * from DichVu";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable getDangKiDichVu()
        {
            string query = $"SP_getDangKiDichVu";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public bool addDangKiDichVu(DangKiDichVu dk)
        {
            string query = $"SP_addDangKiDichVu @madk , @mach , @madichvu , @ngaydk , @ngayhethan";
            return DataProvider.Instance.
                ExecuteNonQuery(query, new object[]
                {
                    dk.MaDKDV,
                    dk.MaCH,
                    dk.MaDichVu,
                    dk.NgayDK,
                    dk.NgayHetHan
                }) > 0;
        }
        public DataTable getCanHo()
        {
            string query = $"Select * from CanHo";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public bool addDichVu(DichVu dichvu)
        {
            string query = $"SP_AddDichVu @maDichVu , @TenDichVu , @DonGia";
            return DataProvider.Instance.
                ExecuteNonQuery(query, new object[]
                {
                    dichvu.MaDichVu,
                    dichvu.TenDichVu,
                    dichvu.DonGia
                }) > 0;
            
        }
        public bool editDichVu(DichVu dichvu)
        {
            string query = $"SP_EditDichVu @maDichVu , @TenDichVu , @DonGia";
            return DataProvider.Instance.
                ExecuteNonQuery(query, new object[]
                {
                    dichvu.MaDichVu,
                    dichvu.TenDichVu,
                    dichvu.DonGia
                }) > 0;
        }
        public bool deleteDichVu(string madichvu)
        {
            string query = $"Delete DichVu where MaDichVu = '{madichvu}'";
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }

        public DataTable SearchDichVu(string keyword)
        {
            string query = "SP_SearchDichVu @key ";

            return DataProvider.Instance.ExecuteQuery(query, new object[] { keyword });
        }
    }
}
