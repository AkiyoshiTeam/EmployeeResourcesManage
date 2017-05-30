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
    /// Interaction logic for BackTracking.xaml
    /// </summary>
    /// 
    public class BackTrackingFilter
    {
        string iD;
        string name;

        public string ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
    }
    public partial class BackTracking : UserControl
    {
        DataTable dt = new DataTable();
        List<BackTrackingFilter> listFilter = new List<BackTrackingFilter>();
        public BackTracking()
        {
            InitializeComponent();
            BackTrackingFilter fil = new BackTrackingFilter();
            fil.ID = " where 1=1 ";
            fil.Name = "Tất cả";
            listFilter.Add(fil);

            fil = new BackTrackingFilter();
            fil.ID = " where (Bang='NhanVien' or Bang='ThongTinChiTietNhanVien') ";
            fil.Name = "Nhân Viên, Thông Tin Chi Tiết";
            listFilter.Add(fil);

            fil = new BackTrackingFilter();
            fil.ID = " where Bang='HopDong' ";
            fil.Name = "Hợp Đồng";
            listFilter.Add(fil);

            fil = new BackTrackingFilter();
            fil.ID = " where (Bang='PhongBan' or Bang='BoPhan') ";
            fil.Name = "Phòng Ban, Bộ Phận";
            listFilter.Add(fil);

            fil = new BackTrackingFilter();
            fil.ID = " where (Bang='PhuCap' or Bang='CongThucTinhLuong') ";
            fil.Name = "Phụ Cấp, Công Thức Tính Lương";
            listFilter.Add(fil);

            fil = new BackTrackingFilter();
            fil.ID = " where Bang='BangLuong' ";
            fil.Name = "Bảng Lương";
            listFilter.Add(fil);

            cbLoc.ItemsSource = listFilter;
            cbLoc.SelectedValuePath = "ID";
            cbLoc.DisplayMemberPath = "Name";
            cbLoc.SelectedValue = " where 1=1 ";

            dpNgayBD.SelectedDate = DateTime.Today.AddDays(-7);
            dpNgayKT.SelectedDate = DateTime.Today;

            dt = BUS.BackTrackingBUS.GetAudit(" where 1=1 ");
            dataGridAudit.DataContext = dt;

            cbLoc.SelectionChanged += cbLoc_SelectionChanged;
            dpNgayBD.SelectedDateChanged += dpChange_SelectedDateChanged;
            dpNgayKT.SelectedDateChanged += dpChange_SelectedDateChanged;
        }

        private void DatePicker_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void dialogHost_DialogClosing(object sender, DialogClosingEventArgs eventArgs)
        {
            if ((bool)eventArgs.Parameter == true)
            {
                //DTO.HopDongDTO hd = new DTO.HopDongDTO();
                //hd.MaHD = tbMaHD.Text;
                //hd.MaNV = tbMaNV.Text;
                //hd.MaLoaiHD = Int16.Parse(cbMaLoaiHD.SelectedValue.ToString());
                //hd.NgayKyHD = Convert.ToDateTime(dpNgayKyHD.Text);
                //if (dpNgayHetHan.SelectedDate != null && dpNgayHetHan.Text != "")
                //    hd.NgayHetHan = Convert.ToDateTime(dpNgayHetHan.Text);
                //else hd.NgayHetHan = Convert.ToDateTime("1/1/2500");
                //hd.MaTTHD = 1;
                //BUS.NguoiDungBUS.SetIsUpdated(Login.Account);
                //BUS.HopDongBUS.NewHopDong(hd);
                //RefreshData();
            }
        }

        private void cbLoc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tgLocNgay.IsChecked == true)
                dt = BUS.BackTrackingBUS.GetAudit(cbLoc.SelectedValue.ToString() + " and NgayGhiLai >= '" + Convert.ToDateTime(dpNgayBD.Text).ToString("yyyy-MM-dd") + "' and NgayGhiLai <='" + Convert.ToDateTime(dpNgayKT.Text).ToString("yyyy-MM-dd") + "'");
            else dt = BUS.BackTrackingBUS.GetAudit(cbLoc.SelectedValue.ToString());
            dataGridAudit.DataContext = dt;
        }

        private void dpChange_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tgLocNgay.IsChecked == true)
                dt = BUS.BackTrackingBUS.GetAudit(cbLoc.SelectedValue.ToString() + " and NgayGhiLai >= '" + Convert.ToDateTime(dpNgayBD.Text).ToString("yyyy-MM-dd") + "' and NgayGhiLai <='" + Convert.ToDateTime(dpNgayKT.Text).ToString("yyyy-MM-dd") + "'");
            else dt = BUS.BackTrackingBUS.GetAudit(cbLoc.SelectedValue.ToString());
            dataGridAudit.DataContext = dt;
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            dpNgayBD.IsEnabled = true;
            dpNgayKT.IsEnabled = true;
            if (tgLocNgay.IsChecked == true)
                dt = BUS.BackTrackingBUS.GetAudit(cbLoc.SelectedValue.ToString() + " and NgayGhiLai >= '" + Convert.ToDateTime(dpNgayBD.Text).ToString("yyyy-MM-dd") + "' and NgayGhiLai <='" + Convert.ToDateTime(dpNgayKT.Text).ToString("yyyy-MM-dd") + "'");
            else dt = BUS.BackTrackingBUS.GetAudit(cbLoc.SelectedValue.ToString());
            dataGridAudit.DataContext = dt;
        }

        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            dpNgayBD.IsEnabled = false;
            dpNgayKT.IsEnabled = false;
            if (tgLocNgay.IsChecked == true)
                dt = BUS.BackTrackingBUS.GetAudit(cbLoc.SelectedValue.ToString() + " and NgayGhiLai >= '" + Convert.ToDateTime(dpNgayBD.Text).ToString("yyyy-MM-dd") + "' and NgayGhiLai <='" + Convert.ToDateTime(dpNgayKT.Text).ToString("yyyy-MM-dd") + "'");
            else dt = BUS.BackTrackingBUS.GetAudit(cbLoc.SelectedValue.ToString());
            dataGridAudit.DataContext = dt;
        }
    }
}
