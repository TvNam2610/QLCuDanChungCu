using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_NguoiDan
    {
        public DataTable getNguoiDan()
        {
            string query = $"SP_getNguoiDan";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable getCanHo()
        {
            string query = $"Select * from CanHo";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable getCanHo_NguoiDan()
        {
            string query = $"SP_getCanHo_ND";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public void addNguoiDan_CanHo(DKCanHo dKCanHo)
        {
            string query = $"SP_AddNguoiDan_CanHo @maNguoiDan , @maCanHo , @ngayDangKy";
            DataProvider.Instance.ExecuteQuery(query , new object[]
            {
                dKCanHo.MaND,
                dKCanHo.MaCH,
                dKCanHo.NgayDangKi
            });
        }
        public void addNguoiDan(NguoiDan nguoiDan)
        {
            string query = $"SP_AddNguoiDan @maNguoiDan , @hoTen , @ngaySinh , @gioiTinh , @soDienThoai ,  @diaChi";
            DataProvider.Instance.
                ExecuteQuery(query, new object[]
                {
                    nguoiDan.MaND,
                    nguoiDan.HoTen,
                    nguoiDan.NgaySinh,
                    nguoiDan.GioiTinh,
                    nguoiDan.SoDienThoai,
                    nguoiDan.DiaChi
                });
        }
        public void editNguoiDan(NguoiDan nguoiDan)
        {
            string query = $"SP_EditNguoiDan @maNguoiDan , @hoTen , @ngaySinh , @gioiTinh , @soDienThoai ,  @diaChi";
            DataProvider.Instance.
                ExecuteQuery(query, new object[]
                {
                    nguoiDan.MaND,
                    nguoiDan.HoTen,
                    nguoiDan.NgaySinh,
                    nguoiDan.GioiTinh,
                    nguoiDan.SoDienThoai,
                    nguoiDan.DiaChi
                });
        }
        public void deleteNguoiDan(string manguoiDan)
        {
            string query = $"Delete NguoiDan where MaND = '{manguoiDan}'";
            DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable SearchNguoiDan(string keyword)
        {
            string query = "SP_SearchNguoiDan @key ";

            return DataProvider.Instance.ExecuteQuery(query, new object[] { keyword });
        }
    }
}
