using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class PhongBanBUS
    {
        public static DataTable GetPhongBan()
        {
            return DAO.PhongBanDAO.GetPhongBan();
        }
        public static DataTable GetPhongBanByWhere(string where)
        {
            return DAO.PhongBanDAO.GetPhongBanByWhere(where);
        }
    }
}
