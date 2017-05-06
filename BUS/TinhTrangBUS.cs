using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class TinhTrangBUS
    {
        public static DataTable GetTinhTrang()
        {
            return DAO.TinhTrangDAO.GetTinhTrang();
        }
    }
}
