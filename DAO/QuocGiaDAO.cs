using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DAO
{
    public class QuocGiaDAO
    {
        public static DataTable GetQuocGia()
        {
            DataTable tb = new DataTable();
            string query = "Select MaQG, TenQG From QuocGia";
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
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dataProvider.disconnect();
            }
            return null;
        }
    }
}
