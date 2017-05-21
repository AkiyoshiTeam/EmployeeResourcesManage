using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DAO
{
    public class TinhTrangHopDongDAO
    {
        public static DataTable GetTinhTrangHopDong()
        {
            DataTable tb = new DataTable();
            string query = "Select MaTTHD, TenTinhTrang From TinhTrangHopDong";

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
    }
}
