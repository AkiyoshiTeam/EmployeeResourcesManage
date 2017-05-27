using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DAO
{
    public class CongThucTinhLuongDAO
    {
        public static DataTable GetCongThucTinhLuong()
        {
            DataTable tb = new DataTable();
            string query = "select CongThuc from CongThucTinhLuong";
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

        public static void UpdateCongThuc(string ct)
        {
            string query = @"Update CongThucTinhLuong Set CongThuc ='" + ct + "' Where ID = 1";
            DataProvider dataProvider = new DataProvider();
            try
            {
                dataProvider.ExecuteUpdateQuery(query);
                MessageBox.Show("Update công thức thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
