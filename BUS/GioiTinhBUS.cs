using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BUS
{
    public class GioiTinhBUS
    {
        public static DataTable GetGioiTinh()
        {
            return DAO.GioiTinhDAO.GetGioiTinh();
        }
    }
}
