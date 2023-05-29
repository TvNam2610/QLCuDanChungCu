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
    public class BUS_HoaDonDichVu
    {
        DAL_ThanhToanDichVu dalhd = new DAL_ThanhToanDichVu();
        public DataTable getHoaDonDichVu()
        {
            return dalhd.getHoaDonDichVu();
        }
        public DataTable getMaDK()
        {
            return dalhd.getMaDK();
        }
        public void addHoaDonDichVu(HoaDonDichVu hd)
        {
            dalhd.addHoaDonDichVu(hd);
        }
        public DataTable XuatHoaDonDichVu(string matt)
        {
            return dalhd.XuatHoaDonDichVu(matt);
        }

        public void KetXuatWord(string exportPath, string matt)
        {
            WordHelper.ExportToWord(dalhd.XuatHoaDonDichVu(matt), "Template\\HoaDonDV_Template.docx", exportPath, new List<string>() { "ngayTT"});
        }
    }
}
