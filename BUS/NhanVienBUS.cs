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

        public static DataTable GetNhanVienByElementForChoose(string mabp, string mapb, string malhd, string matt)
        {
            return DAO.NhanVienDAO.GetNhanVienByElementForChoose(mabp, mapb, malhd, matt);
        }

        public static DataSet GetNhanVienByElementForEdit(DataTable tbTemp)
        {
            return DAO.NhanVienDAO.GetNhanVienByElementForEdit(tbTemp);
        }
        public static bool UpdateNhanVienByElementForEdit(DataTable tbTemp1, DataTable tbTemp2)
        {
            return DAO.NhanVienDAO.UpdateNhanVienByElementForEdit(tbTemp1, tbTemp2);
        }
        public static DataTable GetLastNhanVien()
        {
            return DAO.NhanVienDAO.GetLastNhanVien();
        }
        public static void AddNhanVien(NhanVienDTO nv, ThongTinChiTietNhanVienDTO ttct)
        {
            DAO.NhanVienDAO.AddNhanVien(nv, ttct);
        }
        public static void AddNhanVienMulti(NhanVienDTO nv, ThongTinChiTietNhanVienDTO ttct)
        {
            DAO.NhanVienDAO.AddNhanVienMulti(nv, ttct);
        }
        public static DataTable GetNhanVienByElementForLayoff(DataTable tbTemp)
        {
            return DAO.NhanVienDAO.GetNhanVienByElementForLayoff(tbTemp);
        }
        public static void LayoffNhanVien(DataTable dt)
        {
            DAO.NhanVienDAO.LayoffNhanVien(dt);
        }
        public static void UnLayoffNhanVien(DataTable dt)
        {
            DAO.NhanVienDAO.UnLayoffNhanVien(dt);
        }
        public static DataTable GetNhanVienByWhere(string strWhere)
        {
            return DAO.NhanVienDAO.GetNhanVienByWhere(strWhere);
        }
        public static DataTable GetNhanVienDuocKhenThuong()
        {
            return DAO.NhanVienDAO.GetNhanVienDuocKhenThuong();
        }
        public static DataTable GetNhanVienBiKyLuat()
        {
            return DAO.NhanVienDAO.GetNhanVienBiKyLuat();
        }
        public static DataTable GetNhanVienBPPB(string where)
        {
            return DAO.NhanVienDAO.GetNhanVienBPPB(where);
        }
    }
}
