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
            string query = @"Select * From HopDong hd join NhanVien nv on hd.MaNV = nv.MaNV join TinhTrangHopDong tthd on hd.MaTTHD=tthd.MaTTHD Where (nv.MaTT=1 OR nv.MaTT=4) AND (hd.MaTTHD=1 OR hd.MaTTHD=2) AND hd.MaHD=(select TOP 1 hd2.MaHD from HopDong hd2 where hd2.MaNV=nv.MaNV order by hd2.MaHD DESC) " +
                "Order by hd.MaNV";

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
            query += ") AND MaHD=(select TOP 1 hd2.MaHD from HopDong hd2 where hd2.MaNV=HopDong.MaNV order by hd2.MaHD DESC)";
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

        public static DataTable GetHopDongAlert(string date)
        {
            DataTable tb = new DataTable();
            string query = "Select * From HopDong hd join NhanVien nv on hd.MaNV = nv.MaNV join TinhTrangHopDong tthd on hd.MaTTHD=tthd.MaTTHD Where (nv.MaTT=1 OR nv.MaTT=4) AND hd.MaTTHD=1 and hd.NgayHetHan<='" + date + "' AND hd.MaHD=(select TOP 1 hd2.MaHD from HopDong hd2 where hd2.MaNV=nv.MaNV order by hd2.MaHD DESC)  Order by hd.MaNV";

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

        public static int GetHopDongCountAlert(string date)
        {
            DataTable tb = new DataTable();
            string query = "Select count(hd.MaHD) From HopDong hd join NhanVien nv on hd.MaNV = nv.MaNV join TinhTrangHopDong tthd on hd.MaTTHD=tthd.MaTTHD Where (nv.MaTT=1 OR nv.MaTT=4) AND hd.MaTTHD=1 and hd.NgayHetHan<='" + date + "' AND hd.MaHD=(select TOP 1 hd2.MaHD from HopDong hd2 where hd2.MaNV=nv.MaNV order by hd2.MaHD DESC) ";

            DataProvider dataProvider = new DataProvider();
            try
            {
                dataProvider.connect();
                tb = dataProvider.ExecuteQuery_DataTble(query);
                return Int32.Parse(tb.Rows[0][0].ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dataProvider.disconnect();
            }
            return 0;
        }

        public static void UpdateHopDongTimeOut()
        {
            DataTable tb = new DataTable();
            string date = DateTime.Today.ToString("yyyy-MM-dd");
            string query = "Select MaHD from HopDong where MaTTHD <>3 and NgayHetHan<'" + date + "' and MaHD not in (select hdhh.MaHD from HopDongHetHan hdhh)";
            //string query = @"Update HopDong Set MaTTHD = 3 Where MaNV = '" + hd.MaNV + "' AND MaTTHD=1";
            DataProvider dataProvider = new DataProvider();
            try
            {
                dataProvider.connect();
                tb = dataProvider.ExecuteQuery_DataTble(query);

                if (tb.Rows.Count > 0)
                {
                    query = "";
                    foreach (DataRow row in tb.Rows)
                    {
                        query += @"INSERT INTO HopDongHetHan (MaHD, TinhTrangGiaiQuyet) VALUES('" + row[0].ToString() + "', 0); ";
                    }
                    dataProvider.ExecuteUpdateQuery(query); query = "";
                    foreach (DataRow row in tb.Rows)
                    {
                        query += @"UPDATE HopDong SET HopDong.MaTTHD=2 Where MaHD= '" + row[0].ToString() + "' ";
                    }
                    dataProvider.ExecuteUpdateQuery(query);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void UpdateTinhTrangHopDongTimeOut(List<string> listMaHD)
        {
            string query = @" ";
            foreach (string mahd in listMaHD)
            {
                query += @"UPDATE HopDongHetHan SET TinhTrangGiaiQuyet=1 Where MaHD= '" + mahd + "' ";
            }
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
        }

        public static void UpdateTinhTrangTimeOut(string mahd)
        {
            string query = @"UPDATE HopDongHetHan SET TinhTrangGiaiQuyet=1 Where MaHD= '" + mahd + "' ";
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
        }

        public static DataTable GetHopDongTimeOut()
        {
            DataTable tb = new DataTable();
            string query = "Select * From HopDong hd join NhanVien nv on hd.MaNV = nv.MaNV join TinhTrangHopDong tthd on hd.MaTTHD=tthd.MaTTHD join HopDongHetHan hdhh on hdhh.MaHD=hd.MaHD Where hdhh.TinhTrangGiaiQuyet=0";

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

        public static int GetHopDongCountTimeOut()
        {
            DataTable tb = new DataTable();
            string query = "Select count(MaHD) From HopDongHetHan Where TinhTrangGiaiQuyet=0";

            DataProvider dataProvider = new DataProvider();
            try
            {
                dataProvider.connect();
                tb = dataProvider.ExecuteQuery_DataTble(query);
                return Int32.Parse(tb.Rows[0][0].ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dataProvider.disconnect();
            }
            return 0;
        }
    }
}
