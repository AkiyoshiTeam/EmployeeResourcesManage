using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class ChamCongMacDinhBUS
    {
        public static DataTable GetDefault()
        { return DAO.ChamCongMacDinhDAO.GetDefault(); }
        public static DataTable GetNotDefault()
        { return DAO.ChamCongMacDinhDAO.GetNotDefault(); }
        public static void AddDefault(List<string> list)
        { DAO.ChamCongMacDinhDAO.AddDefault(list); }
        public static void RemoveDefault(List<string> list)
        { DAO.ChamCongMacDinhDAO.RemoveDefault(list); }
    }
}
