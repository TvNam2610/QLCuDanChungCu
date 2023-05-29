using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Data;

namespace BUS
{
    public  class BUS_DichVu
    {
        DAL_DichVu daldv = new DAL_DichVu();
        public DataTable getDichVu()
        {
            return daldv.getDichVu();
        }
        public DataTable getDangKiDichVu()
        {
            return daldv.getDangKiDichVu();
        }
        public DataTable getCanHo()
        {
            return daldv.getCanHo();
        }

        public bool addDangKiDichVu(DangKiDichVu dk)
        {
            
            return daldv.addDangKiDichVu(dk);
            
        }
        public bool addDichVu(DichVu dichvu)
        {
            try
            {
                return daldv.addDichVu(dichvu);
            }
            catch
            {
                return false;
            }
        }
        public bool editDichVu(DichVu dichvu)
        {
            return daldv.editDichVu(dichvu);
        }

        public bool deleteDichVu(string madichvu)
        {
            return daldv.deleteDichVu(madichvu);
        }

        public DataTable searchDichVu(string keyword)
        {
            return daldv.SearchDichVu(keyword);
        }


        /*public void KetXuatWord(string exportPath)
        {
            WordHelper.ExportToWord(daldv.getDichVu(), "Template\\KhachHang_Template.docx", exportPath, new List<string>()
            {
                "MaKhachHang",
                "CCCD"
            });
        }*/


        public List<DichVu> GetAll(DataTable tbdichvu)
        {
            List<DichVu> listNV = new List<DichVu>();
            foreach (DataRow row in tbdichvu.Rows)
            {
                DichVu nv = new DichVu()
                {
                    MaDichVu = row["MaDichVu"].ToString(),
                    TenDichVu = row["TenDichVu"].ToString(),
                    DonGia = (int) row["DonGia"]
                   
                };
                listNV.Add(nv);
            }
            return listNV;
        }

        public void XuatExcel(string filePath)
        {
            //ExcelHelper.WriteExcelFile(filePath, daldv.getDichVu());
        }
    }
}
