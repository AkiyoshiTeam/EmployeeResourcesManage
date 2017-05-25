using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DAO
{
    public class PhongBanDAO
    {
        public static DataTable GetPhongBan()
        {
            DataTable tb = new DataTable();
            string query = "Select MaPB, TenPB, MaBP From PhongBan";
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

        public static DataTable GetPhongBanByWhere(string where)
        {
            DataTable tb = new DataTable();
            string query = "Select * From PhongBan pb " + where;
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

        public static DataTable GetLastPhongBan()
        {
            DataTable tb = new DataTable();
            string query = "Select TOP 1 pb.MaPB From PhongBan pb Order by pb.MaPB DESC";

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

        public static void UpdatePhongBan(DTO.PhongBanDTO pb)
        {
            string query = @"UPDATE PhongBan SET  TenPB= N'" + pb.TenPB + "', TruongPB='" + pb.TruongPB + "', ViTri=N'" + pb.ViTri + "' Where MaPB = '" + pb.MaPB + "'";
            DataProvider dataProvider = new DataProvider();
            try
            {
                dataProvider.ExecuteUpdateQuery(query);
                MessageBox.Show("Update phòng ban thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void AddPhongBan(DTO.PhongBanDTO pb)
        {
            string query = @"INSERT INTO PhongBan (MaPB, TenPB, ViTri, MaBP, MaTT) VALUES( '" + pb.MaPB + "', N'" + pb.TenPB + "', N'" + pb.ViTri + "', '"+pb.MaBP+"', 1); ";
            DataProvider dataProvider = new DataProvider();
            try
            {
                dataProvider.ExecuteUpdateQuery(query);
                MessageBox.Show("Thêm phòng ban thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void ShutdownPhongBan(DTO.PhongBanDTO pb)
        {
            string query = @"UPDATE PhongBan SET MaTT=2 Where MaPB = '" + pb.MaPB + "'";
            DataProvider dataProvider = new DataProvider();
            try
            {
                dataProvider.ExecuteUpdateQuery(query);
                MessageBox.Show("Đã ngừng hoạt động phòng ban!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void StartPhongBan(DTO.PhongBanDTO pb)
        {
            string query = @"UPDATE PhongBan SET MaTT=1 Where MaPB = '" + pb.MaPB + "'";
            DataProvider dataProvider = new DataProvider();
            try
            {
                dataProvider.ExecuteUpdateQuery(query);
                MessageBox.Show("Đã tái hoạt động phòng ban!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
