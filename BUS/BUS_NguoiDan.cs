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
            List<NguoiDan> nguoiDanList = GetAll(dalND.getNguoiDan());
            List<object> objectList = new List<object>();
            //CHUYỂN TỪ LIST NGƯỜI DÂN SANG LIST OBJECT ĐỂ EXPORT
            foreach (NguoiDan kh in nguoiDanList)
            {
                objectList.Add((object)kh);
            }

            WordHelper.ExportToWord(objectList, "Template\\NguoiDan_Template.docx", exportPath);
        }


        public List<NguoiDan> GetAll(DataTable tbnguoiDan)
        {
            List<NguoiDan> listND = new List<NguoiDan>();
            foreach (DataRow row in tbnguoiDan.Rows)
            {
                NguoiDan nd = new NguoiDan()
                {
                    MaND = row["MaND"].ToString(),
                    HoTen = row["HoTen"].ToString(),
                    NgaySinh = (DateTime)row["NgaySinh"],
                    GioiTinh = row["GioiTinh"].ToString(),
                    SoDienThoai = row["SoDienThoai"].ToString(),
                    DiaChi = row["DiaChi"].ToString(),
                };
                listND.Add(nd);
            }
            return listND;
        }

        public void XuatExcel(string filePath)
        {
            ExcelHelper.WriteExcelFile(filePath, dalND.getNguoiDan());
        }
    }
}
