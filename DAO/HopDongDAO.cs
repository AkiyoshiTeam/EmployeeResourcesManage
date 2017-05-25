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
        public static DataTable GetHopDong()
        {
            DataTable tb = new DataTable();
            string query = "Select * From HopDong hd join NhanVien nv on hd.MaNV = nv.MaNV join TinhTrangHopDong tthd on hd.MaTTHD=tthd.MaTTHD Where (nv.MaTT=1 OR nv.MaTT=4) AND (hd.MaTTHD=1 OR hd.MaTTHD=2) AND hd.NgayKyHD>=ALL(select hd2.NgayKyHD from HopDong hd2 where hd2.MaNV=nv.MaNV) Order by hd.MaNV";

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
                MessageBox.Show(ex.Message);
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
                MessageBox.Show(ex.Message);
            }
        }

        public static void AddHopDongMulti(HopDongDTO hd)
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
                MessageBox.Show(ex.Message);
            }
        }

        public static void NewHopDong(HopDongDTO hd)
        {
            string query = @"Update HopDong Set MaTTHD = 3 Where MaNV = '" + hd.MaNV + "' AND MaTTHD=1";
            DataProvider dataProvider = new DataProvider();
            try
            {
                dataProvider.ExecuteUpdateQuery(query);
                query = @"INSERT INTO HopDong (MaHD, MaNV, MaLoaiHD, NgayKyHD, NgayHetHan, MaTTHD) VALUES( '" + hd.MaHD + "', '" + hd.MaNV + "', " + hd.MaLoaiHD + ", '" + hd.NgayKyHD.ToString("yyyy-MM-dd") + "', '" + hd.NgayHetHan.ToString("yyyy-MM-dd") + "', '" + hd.MaTTHD + "' ); ";
                dataProvider.ExecuteUpdateQuery(query);
                MessageBox.Show("Lập hợp đồng thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void LayoffNhanVien(DataTable dt)
        {
            string query = @"UPDATE HopDong SET MaTTHD=3 ";
            bool IsExists = false;
            foreach (DataRow row in dt.Rows)
            {
                if (IsExists == false)
                {
                    query += " WHERE MaNV IN ('" + row[0].ToString() + "' ";
                    IsExists = true;
                }
                else
                {
                    query += " , '" + row[0].ToString() + "' ";
                }
            }
            query += ") ";
            DataProvider dataProvider = new DataProvider();
            try
            {
                dataProvider.ExecuteUpdateQuery(query);
                MessageBox.Show("Sa thải nhân viên thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public static void UnLayoffNhanVien(DataTable dt)
        {
            string query = @"UPDATE HopDong SET HopDong.MaTTHD=1 ";
            bool IsExists = false;
            foreach (DataRow row in dt.Rows)
            {
                if (IsExists == false)
                {
                    query += " WHERE HopDong.MaNV IN ('" + row[0].ToString() + "' ";
                    IsExists = true;
                }
                else
                {
                    query += " , '" + row[0].ToString() + "' ";
                }
            }
            query += ") AND NgayKyHD >=ALL(Select hd.NgayKyHD From HopDong hd Where hd.MaNV = HopDong.MaNV)";
            DataProvider dataProvider = new DataProvider();
            try
            {
                dataProvider.ExecuteUpdateQuery(query);
                MessageBox.Show("Hồi phục nhân viên thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
