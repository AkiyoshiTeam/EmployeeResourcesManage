using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DAO
{
    public class ChamCongDAO
    {
        public static DataTable GetChamCongByMaCC(string macc)
        {
            DataTable tb = new DataTable();
            string query = "Select * From ChamCong cc Where cc.MaChamCong='" + macc + "'";

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

        public static DataTable GetLastChamCong()
        {
            DataTable tb = new DataTable();
            string query = "Select TOP 1 cc.MaChamCong From ChamCong cc Order by cc.MaChamCong DESC";

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

        public static void AddChamCong(DTO.ChamCongDTO cc)
        {
            string query = " INSERT INTO ChamCong(MaChamCong, Thang, Nam, NgayPhatLuong) VALUES('" + cc.MaChamCong + "', " + cc.Thang.ToString() + ", " + cc.Nam + ", '" + cc.NgayPhatLuong.ToString("yyyy-MM-dd") + "')";

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


        public static bool CheckExistsChamCong(DTO.ChamCongDTO cc)
        {
            DataTable tb = new DataTable();
            string query = "Select TOP 1 cc.MaChamCong From ChamCong cc where cc.Thang=" + cc.Thang + " and cc.Nam=" + cc.Nam + " Order by cc.MaChamCong DESC";

            DataProvider dataProvider = new DataProvider();
            try
            {
                dataProvider.connect();
                tb = dataProvider.ExecuteQuery_DataTble(query);
                dataProvider.disconnect();
                if (tb.Rows.Count == 0)
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dataProvider.disconnect();
            }
            return false;
        }
    }
}
