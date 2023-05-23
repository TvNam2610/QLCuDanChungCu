using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_ThanhToanDienNuoc
    {
        public DataTable getHoaDonDienNuoc()
        {
            string query = $"SP_getHDDN";
            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
