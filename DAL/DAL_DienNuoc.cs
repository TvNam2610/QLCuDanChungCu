using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_DienNuoc
    {
        public DataTable getDienNuoc()
        {
            string query = $"Select * from DienNuoc";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public DataTable getCanHo()
        {
            string query = $"Select * from CanHo";
            return DataProvider.Instance.ExecuteQuery(query);
        }



        public void addDienNuoc(DienNuoc diennuoc)
        {
            string query = $"SP_AddDienNuoc   @month , @year , @soDienTieuThu , @soNuocTieuThu , @maCH";
            DataProvider.Instance.
                ExecuteQuery(query, new object[]
                {
                    diennuoc.Month,
                    diennuoc.Year,
                    diennuoc.SoDienTieuThu,
                    diennuoc.SoNuocTieuThu,
                    diennuoc.MaCH
                });
        }
        public void editDienNuoc(DienNuoc diennuoc)
        {
            string query = $"SP_EditDienNuoc @month , @year , @soDienTieuThu , @soNuocTieuThu , @maCH";
            DataProvider.Instance.
                ExecuteQuery(query, new object[]
                {
                    diennuoc.Month,
                    diennuoc.Year,
                    diennuoc.SoDienTieuThu,
                    diennuoc.SoNuocTieuThu,
                    diennuoc.MaCH
                });
        }
        public void deleteDienNuoc(string madn)
        {
            string query = $"SP_DeleteDienNuoc @maDN";
            DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable SearchDienNuoc(string keyword)
        {
            string query = "SP_SearchDienNuoc @key ";

            return DataProvider.Instance.ExecuteQuery(query, new object[] { keyword });
        }
    }
}
