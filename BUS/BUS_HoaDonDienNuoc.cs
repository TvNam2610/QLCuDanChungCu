using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public  class BUS_HoaDonDienNuoc
    {
        DAL_ThanhToanDienNuoc dalhd = new DAL_ThanhToanDienNuoc();
        public DataTable getHoaDonDienNuoc()
        {
            return dalhd.getHoaDonDienNuoc();
        }
    }
}
