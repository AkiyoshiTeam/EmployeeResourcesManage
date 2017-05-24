using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DAO
{
    public class ChiTietChamCongDAO
    {
        public static void AddCTCC(DataTable dt, string macc)
        {
            string query = "";
            foreach (DataRow row in dt.Rows)
            {
                query += " INSERT INTO ChiTietChamCong(MaChamCong, MaNV, NgayCong) VALUES('" + macc + "', '" + row["MaNV"].ToString() + "', " + row["NgayCong"].ToString() + ") ";
            }
            DataTable tb = DAO.ChamCongMacDinhDAO.GetDefault();
            string query2 = "";
            foreach (DataRow row in tb.Rows)
            {
                query2 += " INSERT INTO ChiTietChamCong(MaChamCong, MaNV, NgayCong) VALUES('" + macc + "', '" + row["MaNV"].ToString() + "', 35) ";
            }
            DataProvider dataProvider = new DataProvider();
            try
            {
                dataProvider.connect();
                dataProvider.ExecuteUpdateQuery(query);
                dataProvider.ExecuteUpdateQuery(query2);
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
    }
}
