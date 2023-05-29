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
        public void editDienNuoc(DienNuoc dienNuoc)
        {
            daldn.editDienNuoc(dienNuoc);
        }

        public void deleteDienNuoc(string madn)
        {
            daldn.deleteDienNuoc(madn);
        }

        public DataTable searchDienNuoc(string keyword)
        {
            return daldn.SearchDienNuoc(keyword);
        }

        public void KetXuatWord(string exportPath)
        {
            WordHelper.ExportToWord(daldn.getDienNuoc(), "Template\\DienNuoc_Template.docx", exportPath);
        }


        public void XuatExcel(string filePath)
        {
            ExcelHelper.WriteExcelFile(filePath, "Template\\DienNuoc_Template.xlsx", daldn.getDienNuoc());
        }

    }
}
