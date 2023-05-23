using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_TaiKhoan
    {
        public DataTable getTaiKhoan(string tenTaiKhoan, string matKhau)
        {
            string query = $"select * from TaiKhoan where TenDangNhap = '{tenTaiKhoan}' and MatKhau = '{matKhau}'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            return data;
        }
    }
}
