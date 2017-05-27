using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DAO
{
    public class BangLuongDAO
    {
        public static void AddBangLuong(string manv, string macc, string luongcb, string phucap, string hoadon, string tongluong)
        {
            string query = "";
            query += " INSERT INTO BangLuong(MaNV, MaChamCong, LuongCB, PhuCap, HoaDon, TongLuong) VALUES('" + manv + "', '" + macc + "', " + luongcb + ", " + phucap + ", " + hoadon + ", " + tongluong + ") ";
            DataProvider dataProvider = new DataProvider();
            try
            {
                dataProvider.connect();
                dataProvider.ExecuteUpdateQuery(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dataProvider.disconnect();
            }
        }

        public static DataTable GetBangLuong(string manv)
        {
            DataTable tb = new DataTable();
            string query = " select cc.Thang as 'Tháng', cc.Nam as 'Năm', bl.LuongCB as 'Lương căn bản', ctcc.NgayCong as 'Ngày công', bl.PhuCap as 'Phụ cấp', bl.HoaDon as 'Hóa đơn chi trả', bl.TongLuong as 'Tổng lương đã tính thuế' from BangLuong bl join ChamCong cc on bl.MaChamCong = cc.MaChamCong join ChiTietChamCong ctcc on cc.MaChamCong=ctcc.MaChamCong where bl.MaNV = ctcc.MaNV and bl.MaNV = '" + manv + "'";
            DataProvider dataProvider = new DataProvider();
            try
            {
                dataProvider.connect();
                tb = dataProvider.ExecuteQuery_DataTble(query);
                return tb;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dataProvider.disconnect();
            }
            return null;
        }

        public static void DeleteBangLuongByTime(string thang, string nam)
        {
            string query = "delete BangLuong where MaChamCong = (select MaChamCong from ChamCong where " + thang + " and " + nam + ")";
            DataProvider dataProvider = new DataProvider();
            try
            {
                dataProvider.connect();
                dataProvider.ExecuteUpdateQuery(query);
                query = "update ChiTietChamCong set TrangThai = 0 where MaChamCong = (select MaChamCong from ChamCong where " + thang + " and " + nam + ")";
                dataProvider.ExecuteUpdateQuery(query);
                MessageBox.Show("Xóa bảng lương thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dataProvider.disconnect();
            }
        }

        public static void DeleteBangLuongByID(string manv)
        {
            string query = "delete BangLuong where MaNV = '" + manv + "'";
            DataProvider dataProvider = new DataProvider();
            try
            {
                dataProvider.connect();
                dataProvider.ExecuteUpdateQuery(query);
                query = "update ChiTietChamCong set TrangThai = 0 where MaNV = '" + manv + "'";
                dataProvider.ExecuteUpdateQuery(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dataProvider.disconnect();
            }
        }
    }
}
