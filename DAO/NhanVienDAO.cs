using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Collections;
using System.Windows;
using System.Data;
using System.Linq.Dynamic;
using System.Data.SqlClient;
using System.Data.Common;

namespace DAO
{
    public class NhanVienDAO
    {
        public static DataTable GetNhanVien()
        {
            string connString = "Data Source=AKIYOSHI;Initial Catalog=QLNhanVien;Integrated Security=True";
            SqlConnection conn = null;
            DataTable tb = new DataTable();
            string query = "Select * from HopDong";
            try
            {
                using (conn = new SqlConnection(connString))
                {
                    conn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                    {
                        da.Fill(tb);
                    }

                }
                conn.Close();
                return tb;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return null;
        }
    }
}

