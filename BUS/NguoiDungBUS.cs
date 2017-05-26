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
    }
}
