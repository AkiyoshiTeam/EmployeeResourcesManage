using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Collections;
using System.Windows;

namespace DAO
{
    public class NhanVienDAO
    {
        public static IEnumerable GetNhanVien()
        {
            try
            {
                QLNhanVienEntities context = new QLNhanVienEntities();
                //var query = context.NhanVien.ToList();
                var query = from nv in context.NhanViens
                            select new
                            {
                                nv.MaNV,
                                nv.HoTen,
                                nv.NgayVaoLam,
                                nv.MaCV,
                                nv.MaBP
                            };

                return query.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            return null;

            //var query = from nv in context.NhanVien
            //            select new NhanVienDTO()
            //            {
            //                Id = nv.MaNV,
            //                Name = nv.HoTen,
            //                DateInto = nv.NgayVaoLam,
            //                MaCV = nv.MaCV,
            //                MaBP = nv.MaBP,
            //                MaPB = nv.MaPB,
            //                MaHD = nv.MaHD,
            //                MaLL = nv.MaLoaiLuong,
            //                MaTTCT = nv.MaTTCT,
            //                Image = nv.HinhAnh
            //            };

        }
    }
}

