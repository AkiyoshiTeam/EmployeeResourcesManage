using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BangLuongBUS
    {
        public static void AddBangLuong(string manv, string macc, string luongcb, string phucap, string hoadon, string tongluong)
        {
            DAO.BangLuongDAO.AddBangLuong(manv, macc, luongcb, phucap, hoadon, tongluong);
        }
        public static DataTable GetBangLuong(string manv)
        {
            return DAO.BangLuongDAO.GetBangLuong(manv);
        }
    }
}
