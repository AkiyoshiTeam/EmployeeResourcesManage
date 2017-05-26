using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class CongThucTinhLuongBUS
    {
        public static DataTable GetCongThucTinhLuong()
        {
            return DAO.CongThucTinhLuongDAO.GetCongThucTinhLuong();
        }
    }
}
