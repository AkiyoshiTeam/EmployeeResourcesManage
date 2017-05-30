using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BackTrackingBUS
    {
        public static DataTable GetAudit(string where)
        {
            return DAO.BackTrackingDAO.GetAudit(where);
        }
    }
}
