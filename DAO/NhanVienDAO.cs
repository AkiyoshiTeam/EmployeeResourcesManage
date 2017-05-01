using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Collections;
using System.Windows;
using System.Data;

namespace DAO
{
    public class NhanVienDAO
    {
        public static IEnumerable GetNhanVien()
        {
            try
            {
                QLNhanVienEntities context = new QLNhanVienEntities();
                var query = context.NhanViens.ToList();
                return query.ToList();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.StackTrace);
            }
            return null;

        }

        public static DataTable GetTableNhanVien()
        {
            try
            {
                QLNhanVienEntities context = new QLNhanVienEntities();
                //var query = context.NhanViens.ToList();
                var query = (from nv in context.NhanViens
                            select new
                            {
                                nv.MaNV,
                                nv.HoTen,
                                nv.NgayVaoLam,
                                nv.MaCV,
                                nv.MaBP
                            }).ToList();

                return DAO.IEnumerableToDataTable.ToDataTable(query);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.StackTrace);
            }
            return null;

        }
    }
}

