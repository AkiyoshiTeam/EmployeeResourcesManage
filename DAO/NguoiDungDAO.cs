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
    }
}
