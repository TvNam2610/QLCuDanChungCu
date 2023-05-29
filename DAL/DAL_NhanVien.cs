using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_NhanVien
    {
        public DataTable getNhanVien()
        {
            string query = $"Select nv.MaNV,nv.TenNV,nv.DiaChi,nv.SoDienThoai,nv.Email,cv.TenChucVu,ql.TenQL from NhanVien nv,ChucVu cv, QuanLy ql\r\nwhere nv.MaChucVu = cv.MaChucVu and nv.MaNQL = ql.MaQL";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable getChucVu()
        {
            string query = $"Select * from ChucVu";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable getQuanLy()
        {
            string query = $"select * from QuanLy";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public bool addNhanVien(NhanVien nhanvien)
        {
            string query = $"SP_AddNhanVien @maNhanVien , @tenNV , @diaChi , @soDienThoai , @email ,  @maChucVu , @maNQL";
            return DataProvider.Instance.
                ExecuteNonQuery(query, new object[]
                {
                    nhanvien.MaNV,
                    nhanvien.TenNV,
                    nhanvien.DiaChi,
                    nhanvien.SoDienThoai,
                    nhanvien.Email,
                    nhanvien.MachucVu,
                    nhanvien.MaNQL
                }) > 0;
        }
        public bool editNhanVien(NhanVien nhanvien)
        {
            string query = $"SP_EditNhanVien @maNhanVien , @tenNV , @diaChi , @soDienThoai , @email ,  @maChucVu , @maNQL";
            return DataProvider.Instance.
                ExecuteNonQuery(query, new object[]
                {
                    nhanvien.MaNV,
                    nhanvien.TenNV,
                    nhanvien.DiaChi,
                    nhanvien.SoDienThoai,
                    nhanvien.Email,
                    nhanvien.MachucVu,
                    nhanvien.MaNQL
                }) > 0;
        }
        public bool deleteNhanVien(string manhanvien)
        {
            string query = $"Delete NhanVien where MaNV = '{manhanvien}'";
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }

        public DataTable SearchNhanVien(string keyword)
        {
            string query = "SP_SearchNhanVien @key ";

            return DataProvider.Instance.ExecuteQuery(query, new object[] { keyword });
        }
    }
}
