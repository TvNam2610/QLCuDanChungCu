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
    public class BUS_DienNuoc
    {
        DAL_DienNuoc daldn = new DAL_DienNuoc();
        public DataTable getDienNuoc()
        {
            return daldn.getDienNuoc();
        }
        public DataTable getCanHo()
        {
            return daldn.getCanHo();
        }

        public void addDienNuoc(DienNuoc dienNuoc)
        {
            daldn.addDienNuoc(dienNuoc);
        }
        public void editDichVu(DienNuoc dienNuoc)
        {
            daldn.editDienNuoc(dienNuoc);
        }

        public void deleteDichVu(string madn)
        {
            daldn.deleteDienNuoc(madn);
        }

        public DataTable searchDichVu(string keyword)
        {
            return daldn.SearchDienNuoc(keyword);
        }


        public void KetXuatWord(string exportPath)
        {
            List<DienNuoc> dienNuocList = GetAll(daldn.getDienNuoc());
            List<object> objectList = new List<object>();
            foreach (DienNuoc dn in dienNuocList)
            {
                objectList.Add((object)dn);
            }

            WordHelper.ExportToWord(objectList, "Template\\DienNuoc_Template.docx", exportPath);
        }


        public List<DienNuoc> GetAll(DataTable tbdienNuoc)
        {
            List<DienNuoc> listDN = new List<DienNuoc>();
            foreach (DataRow row in tbdienNuoc.Rows)
            {
                DienNuoc dn = new DienNuoc()
                {
                    MaDN = row["MaDN"].ToString(),
                    Month = (int)row["Month"],
                    Year = (int)row["Year"],
                    SoDienTieuThu = (int)row["SoDienTieuThu"],
                    SoNuocTieuThu = (int)row["SoNuocTieuThu"],
                    MaCH = row["MaCH"].ToString()
                };
                listDN.Add(dn);
            }
            return listDN;
        }

        public void XuatExcel(string filePath)
        {
            ExcelHelper.WriteExcelFile(filePath, daldn.getDienNuoc());
        }
    }
}
