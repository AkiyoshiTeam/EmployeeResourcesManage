using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DAO
{
    public class NguoiDungDAO
    {
        public static DataTable DangNhap( string username)
        {
            DataProvider dataprovider = new DataProvider();
            DataTable dt = new DataTable();
            string query = "Select ND.Password,ND.MaPQ,NV.MaNV,NV.HoTen,NV.HinhAnh From NguoiDung ND join NhanVien NV on ND.MaNV = NV.MaNV Where ND.Username = '" + username + "'";
            try
            {
                dataprovider.connect();
                dt = dataprovider.ExecuteQuery_DataTble(query);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                dataprovider.disconnect();
            }
            return null;
        }

        public static void AddGhiChuDangNhap(string username, string timelogin, string timelogout)
        {
            string query = @"INSERT INTO GhiChuDangNhap (Username, TimeLogin, TimeLogout) VALUES( '" + username + "', '" + timelogin + "', '" + timelogout + "' ); ";
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

        public static DataTable GetLastDangNhap(string username)
        {
            DataProvider dataprovider = new DataProvider();
            DataTable dt = new DataTable();
            string query = "Select TOP 1 * From GhiChuDangNhap Where Username = '" + username + "' order by ID DESC";
            try
            {
                dataprovider.connect();
                dt = dataprovider.ExecuteQuery_DataTble(query);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                dataprovider.disconnect();
            }
            return null;
        }
    }
}
