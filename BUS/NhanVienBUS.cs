using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Collections;
using System.Data;

namespace BUS
{
    public class NhanVienBUS
    {

        public static DataTable GetNhanVien()
        {
            return DAO.NhanVienDAO.GetNhanVien();
        }
    }
}
