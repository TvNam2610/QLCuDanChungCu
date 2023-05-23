using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_ThanhToanDichVu
    {
        public DataTable getHoaDonDichVu()
        {
            string query = $"SP_getHDDV";
            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
