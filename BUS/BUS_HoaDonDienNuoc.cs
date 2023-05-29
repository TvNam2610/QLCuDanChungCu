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
    public  class BUS_HoaDonDienNuoc
    {
        DAL_ThanhToanDienNuoc dalhd = new DAL_ThanhToanDienNuoc();
        public DataTable getHoaDonDienNuoc()
        {
            return dalhd.getHoaDonDienNuoc();
        }
        public void addHoaDonDienNuoc(DienNuoc dn, HoaDonDienNuoc hd)
        {
            dalhd.addHoaDonDienNuoc(dn, hd);
        }
        public DataTable XuatHoaDonDienNuoc(string matt)
        {
            return dalhd.XuatHoaDonDienNuoc(matt);
        }

        public DataTable getGia()
        {
            return dalhd.getGia();
        }
        public DataTable getCanHo()
        {
            return dalhd.getCanHo();
        }
        
        public DataTable TaoBangHoaDon(int soDien, int soNuoc)
        {
            // Tạo DataTable và thêm cột
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("NoiDung");
            dataTable.Columns.Add("SoLuong");
            dataTable.Columns.Add("DonGia");
            dataTable.Columns.Add("ThanhTien");

            int donGiaDien = int.Parse(dalhd.getGia().Rows[0][0].ToString());
            int donGiaNuoc = int.Parse(dalhd.getGia().Rows[0][1].ToString());

            dataTable.Rows.Add("Tiền điện", soDien, donGiaDien, soDien * donGiaDien);
            dataTable.Rows.Add("Tiền nước", soNuoc, donGiaNuoc, soNuoc * donGiaNuoc);


            return dataTable;
        }


        public void KetXuatWord(string exportPath, List<int> gia)
        {
            //float tongTien = (float)dalhd.getTongTien(maHoaDon).Rows[0][1];
            WordHelper.ExportToWord2(TaoBangHoaDon(gia[0], gia[1]), "Template\\PhieuHoaDon_Template.docx", exportPath, gia[2]);
        }
    }
}
