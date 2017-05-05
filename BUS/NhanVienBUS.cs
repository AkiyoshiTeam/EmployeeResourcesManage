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
        public static DataTable GetNhanVien(TreesSearchModel TreeSearchViewModel)
        {
            return DAO.NhanVienDAO.GetNhanVien(TreeSearchViewModel);
        }

        public static DataTable GetDescriptionSelected(TreesSearchModel TreeSearchViewModel)
        {
            return DAO.NhanVienDAO.GetDescriptionSelected(TreeSearchViewModel);
        }

        public static DataTable GetNhanVienForChoose()
        {
            return DAO.NhanVienDAO.GetNhanVienForChoose();
        }
    }
}
