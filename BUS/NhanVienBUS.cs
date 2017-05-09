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

        public static DataTable GetNhanVienByElementForChoose(string mabp, string mapb, string malhd, string mall, string matt)
        {
            return DAO.NhanVienDAO.GetNhanVienByElementForChoose(mabp, mapb, malhd, mall, matt);
        }

        public static DataSet GetNhanVienByElementForEdit(DataTable tbTemp)
        {
            return DAO.NhanVienDAO.GetNhanVienByElementForEdit(tbTemp);
        }
        public static bool UpdateNhanVienByElementForEdit(DataTable tbTemp1, DataTable tbTemp2)
        {
            return DAO.NhanVienDAO.UpdateNhanVienByElementForEdit(tbTemp1, tbTemp2);
        }
    }
}
