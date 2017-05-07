using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class ChucVuBUS
    {
        public static DataTable GetChucVu()
        {
            return DAO.ChucVuDAO.GetChucVu();
        }
    }
}
