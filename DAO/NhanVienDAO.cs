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
        public static DataTable GetNhanVien(TreesSearchModel TreeSearchViewModel)
        {
            string connString = "Data Source=AKIYOSHI;Initial Catalog=QLNhanVien;Integrated Security=True";
            SqlConnection conn = null;
            DataTable tb = new DataTable();
            string query = "Select ";
            bool exists = false;
            for (int i = 0; i < TreeSearchViewModel.SearchObjects.Count; i++)
            {
                for (int j = 0; j < TreeSearchViewModel.SearchObjects[i].SearchElements.Count; j++)
                {
                    for (int n = 0; n < TreeSearchViewModel.SearchObjects[i].SearchElements[j].SearchElementDetails.Count; n++)
                    {
                        if (TreeSearchViewModel.SearchObjects[i].SearchElements[j].SearchElementDetails[n].IsCheckedDetail == true)
                        {
                            if (exists == false)
                            {
                                query += TreeSearchViewModel.SearchObjects[i].SearchElements[j].SearchElementDetails[n].StrSearch;
                                exists = true;
                            }
                            else query += ", " + TreeSearchViewModel.SearchObjects[i].SearchElements[j].SearchElementDetails[n].StrSearch;
                        }
                    }
                }
            }
            query += " From NhanVien";

            if (exists == true)
            {
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
            }
            return null;
        }

        public static DataTable GetDescription(TreesSearchModel TreeSearchViewModel)
        {
            string connString = "Data Source=AKIYOSHI;Initial Catalog=QLNhanVien;Integrated Security=True";
            SqlConnection conn = null;
            DataTable tb = new DataTable();
            string query = @"select st.name[Table], sc.name[Column], sep.value[Description]
                            from sys.tables st inner join sys.columns sc on st.object_id = sc.object_id 
                            left join sys.extended_properties sep on st.object_id = sep.major_id and sc.column_id = sep.minor_id and sep.name = 'MS_Description'
                            where st.name = 'NhanVien'";
            //  and (sc.name = 'MaNV' or sc.name = 'NgayVaoLam')
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

