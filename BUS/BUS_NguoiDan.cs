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
    public class BUS_NguoiDan
    {
        DAL_NguoiDan dalND = new DAL_NguoiDan();
        public DataTable getNguoiDan()
        {
            return dalND.getNguoiDan();
        }

        public DataTable getCanHo_NguoiDan()
        {
            return dalND.getCanHo_NguoiDan();
        }
        public void addNguoiDan(NguoiDan nguoidan)
        {
            dalND.addNguoiDan(nguoidan);
        }

        public void editNguoiDan(NguoiDan nguoidan)
        {
            dalND.editNguoiDan(nguoidan);
        }

        public void deleteNguoiDan(string manguoidan)
        {
            dalND.deleteNguoiDan(manguoidan);
        }

        public DataTable searchNguoiDan(string keyword)
        {
            return dalND.SearchNguoiDan(keyword);
        }

        public DataTable getCanHo()
        {
            return dalND.getCanHo();
        }

        public void addNguoiDan_CanHo(DKCanHo dKCanHo)
        {
            dalND.addNguoiDan_CanHo(dKCanHo);
        }

        public void KetXuatWord(string exportPath)
        {
            WordHelper.ExportToWord(dalND.getNguoiDan(), "Template\\NguoiDan_Template.docx", exportPath, 
                new List<string>() {"MaND" , "MaCH"});
        }


        public void XuatExcel(string filePath)
        {
            ExcelHelper.WriteExcelFile(filePath, "Template\\NguoiDan_Template.xlsx", dalND.getNguoiDan());
        }
    }
}
