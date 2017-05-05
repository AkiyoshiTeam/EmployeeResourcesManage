using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DAO
{
    public class DescriptionForTree
    {
        public static DataSet GetDescriptionForTree()
        {
            DataSet dtSet = new DataSet();
            string queryNV = @"select st.name[Table], sc.name[Column], sep.value[Description]
                            from sys.tables st inner join sys.columns sc on st.object_id = sc.object_id 
                            left join sys.extended_properties sep on st.object_id = sep.major_id and sc.column_id = sep.minor_id and sep.name = 'MS_Description'
                            where st.name = 'NhanVien' ";
            string queryTTCT = @"select st.name[Table], sc.name[Column], sep.value[Description]
                            from sys.tables st inner join sys.columns sc on st.object_id = sc.object_id 
                            left join sys.extended_properties sep on st.object_id = sep.major_id and sc.column_id = sep.minor_id and sep.name = 'MS_Description'
                            where st.name = 'ThongTinChiTietNhanVien' ";

            DataProvider dataProvider = new DataProvider();
            try
            {
                dataProvider.connect();
                DataTable tb = dataProvider.ExecuteQuery_DataTble(queryNV).Copy();
                tb.TableName = "DesNhanVien";
                dtSet.Tables.Add(tb);
                tb = dataProvider.ExecuteQuery_DataTble(queryTTCT).Copy();
                tb.TableName = "DesTTCT";
                dtSet.Tables.Add(tb);
                dataProvider.disconnect();
                return dtSet;
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
