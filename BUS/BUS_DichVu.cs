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

        public void addDichVu(DichVu dichvu)
        {
            daldv.addDichVu(dichvu);
        }
        public void editDichVu(DichVu dichvu)
        {
            daldv.editDichVu(dichvu);
        }

        public void deleteDichVu(string madichvu)
        {
            daldv.deleteDichVu(madichvu);
        }

        public DataTable searchDichVu(string keyword)
        {
            return daldv.SearchDichVu(keyword);
        }


        public void KetXuatWord(string exportPath)
        {
            List<DichVu> dichVuList = GetAll(daldv.getDichVu());
            List<object> objectList = new List<object>();
            foreach (DichVu dv in dichVuList)
            {
                objectList.Add((object)dv);
            }

            WordHelper.ExportToWord(objectList, "Template\\Dichvu_Template.docx", exportPath);
        }


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
            ExcelHelper.WriteExcelFile(filePath, daldv.getDichVu());
        }
    }
}
