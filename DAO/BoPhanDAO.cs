using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DAO
{
    public class BoPhanDAO
    {
        public static DataTable GetBoPhan()
        {
            DataTable tb = new DataTable();
            string query = "Select MaBP, TenBP From BoPhan";
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

        public static DataSet GetBoPhanPhongBan()
        {
            DataTable tb = new DataTable();
            string query1 = "select * from BoPhan bp order by bp.Mabp";
            string query2 = "select * from PhongBan pb join BoPhan bp on pb.MaBP=bp.MaBP order by bp.Mabp";
            DataProvider dataProvider = new DataProvider();
            try
            {
                DataSet ds = new DataSet();
                dataProvider.connect();
                tb = dataProvider.ExecuteQuery_DataTble(query1);
                DataTable dts1 = new DataTable();
                dts1 = tb.Copy();
                dts1.TableName = "BoPhan";
                ds.Tables.Add(dts1);
                tb = dataProvider.ExecuteQuery_DataTble(query2);
                DataTable dts2 = new DataTable();
                dts2 = tb.Copy();
                dts2.TableName = "BoPhanPhongBan";
                ds.Tables.Add(dts2);
                return ds;
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

        public static DataTable GetBoPhanByWhere(string where)
        {
            DataTable tb = new DataTable();
            string query = "Select * From BoPhan bp " + where;
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

        public static DataTable GetLastBoPhan()
        {
            DataTable tb = new DataTable();
            string query = "Select TOP 1 bp.MaBP From BoPhan bp Order by bp.MaBP DESC";

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

        public static void UpdateBoPhan(DTO.BoPhanDTO bp)
        {
            string query = @"UPDATE BoPhan SET  TenBP= N'" + bp.TenBP + "', TruongBP='" + bp.TruongBP + "' Where MaBP = '" + bp.MaBP + "'";
            DataProvider dataProvider = new DataProvider();
            try
            {
                dataProvider.ExecuteUpdateQuery(query);
                MessageBox.Show("Update bộ phận thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void AddBoPhan(DTO.BoPhanDTO bp)
        {
            string query = @"INSERT INTO BoPhan (MaBP, TenBP, MaTT) VALUES( '" + bp.MaBP + "', N'" + bp.TenBP + "', 1); ";
            DataProvider dataProvider = new DataProvider();
            try
            {
                dataProvider.ExecuteUpdateQuery(query);
                MessageBox.Show("Thêm bộ phận thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public static void ShutdownBoPhan(DTO.BoPhanDTO bp)
        {
            string query = @"UPDATE BoPhan SET MaTT=2 Where MaBP = '" + bp.MaBP + "'";
            string query2 = @"UPDATE PhongBan SET MaTT=2 Where MaBP = '" + bp.MaBP + "'";
            DataProvider dataProvider = new DataProvider();
            try
            {
                dataProvider.ExecuteUpdateQuery(query);
                dataProvider.ExecuteUpdateQuery(query2);
                MessageBox.Show("Đã ngừng hoạt động bộ phận!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void StartBoPhan(DTO.BoPhanDTO bp)
        {
            string query = @"UPDATE BoPhan SET MaTT=1 Where MaBP = '" + bp.MaBP + "'";
            DataProvider dataProvider = new DataProvider();
            try
            {
                dataProvider.ExecuteUpdateQuery(query);
                MessageBox.Show("Đã tái hoạt động bộ phận!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
