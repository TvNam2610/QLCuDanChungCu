using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace BUS
{
    public class BUS_NhanVien
    {
        DAL_NhanVien dalnv = new DAL_NhanVien();
        public DataTable getNhanVien()
        {
            return dalnv.getNhanVien();
        }
       


        public bool addNhanVien(NhanVien nhanvien)
        {

            try
            {
                return dalnv.addNhanVien(nhanvien);
            }
            catch
            {
                return false;
            }
        }

        public bool editNhanVien(NhanVien nhanvien)
        {
            return dalnv.editNhanVien(nhanvien);
        }

        public bool deleteNhanVien(string manhanvien)
        {
            return dalnv.deleteNhanVien(manhanvien);
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
            WordHelper.ExportToWord(dalnv.getNhanVien(), "Template\\NhanVien_Template.docx", exportPath,
                new List<string>() { "MaNV" });
        }


        public void XuatExcel(string filePath)
        {
            ExcelHelper.WriteExcelFile(filePath, "Template\\NhanVien_Template.xlsx", dalnv.getNhanVien());
        }

        
    }
}
