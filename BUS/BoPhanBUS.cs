using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BoPhanBUS
    {
        public static DataTable GetBoPhan()
        {
            return DAO.BoPhanDAO.GetBoPhan();
        }

        public static DataSet GetBoPhanPhongBan()
        {
            return DAO.BoPhanDAO.GetBoPhanPhongBan();
        }

        public static DataTable GetBoPhanByWhere(string where)
        {
            return DAO.BoPhanDAO.GetBoPhanByWhere(where);
        }

        public static void UpdateBoPhan(DTO.BoPhanDTO bp)
        {
            DAO.BoPhanDAO.UpdateBoPhan(bp);
        }

        public static DataTable GetLastBoPhan()
        {
            return DAO.BoPhanDAO.GetLastBoPhan();
        }
        public static void AddBoPhan(DTO.BoPhanDTO bp)
        {
            DAO.BoPhanDAO.AddBoPhan(bp);
        }
        public static void ShutdownBoPhan(DTO.BoPhanDTO bp)
        {
            DAO.BoPhanDAO.ShutdownBoPhan(bp);
        }
        public static void StartBoPhan(DTO.BoPhanDTO bp)
        {
            DAO.BoPhanDAO.StartBoPhan(bp);
        }
    }
}
