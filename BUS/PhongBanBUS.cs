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
        public static void UpdatePhongBan(DTO.PhongBanDTO pb)
        {
            DAO.PhongBanDAO.UpdatePhongBan(pb);
        }
        public static DataTable GetLastPhongBan()
        {
            return DAO.PhongBanDAO.GetLastPhongBan();
        }
        public static void AddPhongBan(DTO.PhongBanDTO pb)
        {
            DAO.PhongBanDAO.AddPhongBan(pb);
        }
        public static void ShutdownPhongBan(DTO.PhongBanDTO pb)
        {
            DAO.PhongBanDAO.ShutdownPhongBan(pb);
        }
        public static void StartPhongBan(DTO.PhongBanDTO pb)
        {
            DAO.PhongBanDAO.StartPhongBan(pb);
        }
    }
}
