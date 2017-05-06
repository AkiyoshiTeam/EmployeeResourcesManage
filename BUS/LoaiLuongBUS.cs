using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class LoaiLuongBUS
    {
        public static DataTable GetLoaiLuong()
        {
            return DAO.LoaiLuongDAO.GetLoaiLuong();
        }
    }
}
