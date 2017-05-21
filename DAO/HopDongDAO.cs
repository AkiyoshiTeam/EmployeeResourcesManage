using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DAO
{
    public class HopDongDAO
    {
        public static DataTable GetLastHopDong()
        {
            DataTable tb = new DataTable();
            string query = "Select TOP 1 hd.MaHD From HopDong hd Order by hd.MaHD DESC";

            DataProvider dataProvider = new DataProvider();
            try
            {
                dataProvider.connect();
                tb = dataProvider.ExecuteQuery_DataTble(query);
                return tb;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                dataProvider.disconnect();
            }
            return null;
        }

        public static void AddHopDong(HopDongDTO hd)
        {
            string query = @"INSERT INTO HopDong (MaHD, MaNV, MaLoaiHD, NgayKyHD, NgayHetHan, MaTTHD) VALUES( '" + hd.MaHD + "', '" + hd.MaNV + "', " + hd.MaLoaiHD + ", '" + hd.NgayKyHD.ToString("yyyy-MM-dd") + "', '" + hd.NgayHetHan.ToString("yyyy-MM-dd") + "', '" + hd.MaTTHD + "' ); ";
            DataProvider dataProvider = new DataProvider();
            try
            {
                dataProvider.ExecuteUpdateQuery(query);
                MessageBox.Show("Thêm hợp đồng thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                MessageBox.Show(ex.Message);
            }
        }
    }
}
