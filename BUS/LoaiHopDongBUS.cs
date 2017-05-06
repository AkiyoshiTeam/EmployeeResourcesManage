using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class LoaiHopDongBUS
    {
        public static DataTable GetLoaiHopDong()
        {
            return DAO.LoaiHopDongDAO.GetLoaiHopDong();
        }
    }
}
