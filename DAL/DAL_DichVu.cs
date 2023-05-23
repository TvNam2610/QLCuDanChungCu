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
        public DataTable getCanHo()
        {
            string query = $"Select * from CanHo";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public void addDichVu(DichVu dichvu)
        {
            string query = $"SP_AddDichVu @maDichVu , @TenDichVu , @DonGia";
            DataProvider.Instance.
                ExecuteQuery(query, new object[]
                {
                    dichvu.MaDichVu,
                    dichvu.TenDichVu,
                    dichvu.DonGia
                });
        }
        public void editDichVu(DichVu dichvu)
        {
            string query = $"SP_EditDichVu @maDichVu , @TenDichVu , @DonGia";
            DataProvider.Instance.
                ExecuteQuery(query, new object[]
                {
                    dichvu.MaDichVu,
                    dichvu.TenDichVu,
                    dichvu.DonGia
                });
        }
        public void deleteDichVu(string madichvu)
        {
            string query = $"Delete DichVu where MaDichVu = '{madichvu}'";
            DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable SearchDichVu(string keyword)
        {
            string query = "SP_SearchDichVu @key ";

            return DataProvider.Instance.ExecuteQuery(query, new object[] { keyword });
        }
    }
}
