using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Employee_Resources_Manage
{
    /// <summary>
    /// Interaction logic for TimeOutCheck.xaml
    /// </summary>
    public partial class TimeOutCheck : UserControl
    {
        List<LoaiHopDong> listLHD;
        DataTable dt = new DataTable();
        string mahdLast = "";
        public TimeOutCheck()
        {
            InitializeComponent();
            dt = BUS.HopDongBUS.GetHopDongTimeOut();
            dataGridContract.DataContext = dt;
            MaterialDataGridTextColumn col;
            col = new MaterialDataGridTextColumn();
            col.Header = "Mã Nhân Viên";
            col.Binding = new Binding("MaNV");
            dataGridContract.Columns.Add(col);
            col = new MaterialDataGridTextColumn();
            col.Header = "Họ Tên";
            col.Binding = new Binding("HoTen");
            col.Width = 200;
            dataGridContract.Columns.Add(col);
            col = new MaterialDataGridTextColumn();
            var c = new DataGridTemplateColumn();
            var template = new DataTemplate();
            var textBlockFactory = new FrameworkElementFactory(typeof(TextBlock));
            Binding bd = new Binding();
            bd.StringFormat = "{0:dd/MM/yyyy}";
            bd.Path = new PropertyPath("NgayKyHD");
            textBlockFactory.SetBinding(TextBlock.TextProperty, bd);
            template.VisualTree = textBlockFactory;
            c.CellTemplate = template;
            c.Header = "Ngày Bắt Đầu";
            dataGridContract.Columns.Add(c);
            c = new DataGridTemplateColumn();
            template = new DataTemplate();
            textBlockFactory = new FrameworkElementFactory(typeof(TextBlock));
            bd = new Binding();
            bd.StringFormat = "{0:dd/MM/yyyy}";
            bd.Path = new PropertyPath("NgayHetHan");
            textBlockFactory.SetBinding(TextBlock.TextProperty, bd);
            template.VisualTree = textBlockFactory;
            c.CellTemplate = template;
            c.Header = "Ngày Kết Thúc";
            dataGridContract.Columns.Add(c);
            col = new MaterialDataGridTextColumn();
            col.Header = "Tình Trạng HĐ";
            col.Binding = new Binding("TenTinhTrang");
            dataGridContract.Columns.Add(col);
            
        }
        
        private void dialogHost_DialogClosing(object sender, DialogClosingEventArgs eventArgs)
        {
            if ((bool)eventArgs.Parameter == true)
            {
                List<string> listMaHD = new List<string>();
                for (int i = 0; i < dataGridContract.SelectedItems.Count; i++)
                {
                    DataRowView rowSelected = (DataRowView)dataGridContract.SelectedItems[i];
                    listMaHD.Add(rowSelected[0].ToString());
                }
                BUS.HopDongBUS.UpdateTinhTrangHopDongTimeOut(listMaHD);
                RefreshData();
            }
        }

        private void RefreshData()
        {
            dt = BUS.HopDongBUS.GetHopDongTimeOut();
            dataGridContract.DataContext = dt;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridContract.SelectedItem != null)
            {
                dialogHostWarning.DataContext = "Bạn đã kiểm tra xong các hợp đồng hết hạn đã chọn?";
                dialogHostWarning.IsOpen = true;
            }
        }
    }
}
