using DAL;
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
    }
}
