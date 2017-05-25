using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DAO
{
    public class ChamCongMacDinhDAO
    {
        public static DataTable GetDefault()
        {
            DataTable tb = new DataTable();
            string query = "Select nv.MaNV as 'Mã nhân viên', nv.HoTen as 'Họ tên' From NhanVien nv Where nv.MaNV IN (select ccmd.MaNV from ChamCongMacDinh ccmd)";

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

        public static DataTable GetNotDefault()
        {
            DataTable tb = new DataTable();
            string query = "Select nv.MaNV as 'Mã nhân viên', nv.HoTen as 'Họ tên' From NhanVien nv  Where nv.MaNV NOT IN (select ccmd.MaNV from ChamCongMacDinh ccmd) ";

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

        public static void AddDefault(List<string> listNV)
        {
            string query = "";
            foreach (string str in listNV)
            {
                query += " INSERT INTO ChamCongMacDinh(MaNV) VALUES('" + str + "') ";
            }

            DataProvider dataProvider = new DataProvider();
            try
            {
                dataProvider.connect();
                dataProvider.ExecuteUpdateQuery(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                dataProvider.disconnect();
            }
        }

        public static void RemoveDefault(List<string> listNV)
        {
            bool isExists = false;
            string query = "DELETE From ChamCongMacDinh Where MaNV in (";
            foreach (string str in listNV)
            {
                if (isExists)
                {
                    query += ",'" + str + "'";
                }
                else
                {
                    query += "'" + str + "'";
                    isExists = true;
                }
            }
            query += ")";

            DataProvider dataProvider = new DataProvider();
            try
            {
                dataProvider.connect();
                dataProvider.ExecuteUpdateQuery(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                dataProvider.disconnect();
            }
        }
    }
}
