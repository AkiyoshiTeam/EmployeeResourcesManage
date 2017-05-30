using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BUS
{
    public class NguoiDungBUS
    {
        public static DataTable DangNhap(string username)
        {
            return NguoiDungDAO.DangNhap(username);
        }
        public static void AddGhiChuDangNhap(string username, string timelogin, string timelogout)
        {
            DAO.NguoiDungDAO.AddGhiChuDangNhap(username, timelogin, timelogout);
        }
        public static DataTable GetLastDangNhap(string username)
        {
            return DAO.NguoiDungDAO.GetLastDangNhap(username);
        }
        public static void SetIsUpdated(string username)
        {
            DAO.NguoiDungDAO.SetIsUpdated(username);
        }
    }
}
