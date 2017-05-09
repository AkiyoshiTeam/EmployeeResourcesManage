using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class TinhTPBUS
    {
        public static DataTable GetTinhTP()
        {
            return DAO.TinhTPDAO.GetTinhTP();
        }
    }
}
