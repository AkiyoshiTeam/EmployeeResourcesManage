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
        public static DataTable GetCTCCByMANV(string manv)
        {
            DataTable tb = new DataTable();
            string query = "Select * from ChiTietChamCong Where MaNV='" + manv + "' and TrangThai = 0";
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

        public static void AddCTCC(DataTable dt, string macc)
        {
            string query = "";
            foreach (DataRow row in dt.Rows)
            {
                query += " INSERT INTO ChiTietChamCong(MaChamCong, MaNV, NgayCong, TrangThai) VALUES('" + macc + "', '" + row["MaNV"].ToString() + "', " + row["NgayCong"].ToString() + ", 0) ";
            }
            DataTable tb = DAO.ChamCongMacDinhDAO.GetDefault();
            string query2 = "";
            foreach (DataRow row in tb.Rows)
            {
                query2 += " INSERT INTO ChiTietChamCong(MaChamCong, MaNV, NgayCong, TrangThai) VALUES('" + macc + "', '" + row[0].ToString() + "', 35, 0) ";
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

        public static void UpdateCTCC(DTO.ChiTietChamCongDTO ctcc)
        {
            string query = @"UPDATE ChiTietChamCong SET TrangThai=1 Where MaChamCong='" + ctcc.MaChamCong + "' and  MaNV='" + ctcc.MaNV + "'";
            DataProvider dataProvider = new DataProvider();
            try
            {
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
    }
}
