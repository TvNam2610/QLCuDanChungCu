using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_NhanVien
    {
        DAL_NhanVien dalnv = new DAL_NhanVien();
        public DataTable getNhanVien()
        {
            return dalnv.getNhanVien();
        }
       


        public void addNhanVien(NhanVien nhanvien)
        {
            dalnv.addNhanVien(nhanvien);
        }

        public void editNhanVien(NhanVien nhanvien)
        {
            dalnv.editNhanVien(nhanvien);
        }

        public void deleteNhanVien(string manhanvien)
        {
            dalnv.deleteNhanVien(manhanvien);
        }

        public DataTable searchNhanVien(string keyword)
        {
            return dalnv.SearchNhanVien(keyword);
        }

        public DataTable getChucVu()
        {
            return dalnv.getChucVu();
        }
        public DataTable getQuanLy()
        {
            return dalnv.getQuanLy();
        }

        public void KetXuatWord(string exportPath)
        {
            List<NhanVien> nhanVienList = GetAll(dalnv.getNhanVien());
            List<object> objectList = new List<object>();
            foreach (NhanVien nv in nhanVienList)
            {
                objectList.Add((object)nv);
            }

            WordHelper.ExportToWord(objectList, "Template\\NhanVien_Template.docx", exportPath);
        }


        public List<NhanVien> GetAll(DataTable tbnhanVien)
        {
            List<NhanVien> listNV = new List<NhanVien>();
            foreach (DataRow row in tbnhanVien.Rows)
            {
                NhanVien nv = new NhanVien()
                {
                    MaNV = row["MaNV"].ToString(),
                    TenNV = row["TenNV"].ToString(),
                    DiaChi = row["DiaChi"].ToString(),
                    SoDienThoai = row["SoDienThoai"].ToString(),
                    Email = row["Email"].ToString(),
                    MachucVu = row["MaChucVu"].ToString(),
                    MaNQL = row["MaNQL"].ToString()
                };
                listNV.Add(nv);
            }
            return listNV;
        }

        public void XuatExcel(string filePath)
        {
            ExcelHelper.WriteExcelFile(filePath, dalnv.getNhanVien());
        }
    }
}
