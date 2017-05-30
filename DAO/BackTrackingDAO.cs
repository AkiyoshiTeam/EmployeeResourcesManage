using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DAO
{
    public class BackTrackingDAO
    {
        public static DataTable GetAudit(string where)
        {
            DataTable tb = new DataTable();
            string query = " Select MaTheoDoi as 'ID', HanhDong as 'Hành động', Bang as 'Bảng', ID as 'Mã thay đổi', TruongThayDoi as 'Trường thay đổi', GiaTriCu as 'Giá trị cũ', GiaTriMoi as 'Giá trị mới', NgayGhiLai as 'Ngày ghi lại', NguoiDung as 'Người thay đổi' from Audit " + where + " order by MaTheoDoi DESC ";
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
    }
}
