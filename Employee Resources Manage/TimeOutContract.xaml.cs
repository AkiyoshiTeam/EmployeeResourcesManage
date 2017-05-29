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
    /// Interaction logic for TimeOutContract.xaml
    /// </summary>
    public partial class TimeOutContract : UserControl
    {
        List<LoaiHopDong> listLHD;
        DataTable dt = new DataTable();
        string mahdLast = "";
        public TimeOutContract()
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

            DataTable tbTemp = BUS.LoaiHopDongBUS.GetLoaiHopDong();
            listLHD = new List<LoaiHopDong>();
            foreach (DataRow row in tbTemp.Rows)
            {
                listLHD.Add(new LoaiHopDong { ID = row[0].ToString().Trim(), Name = row[1].ToString() });
            }
            cbMaLoaiHD.ItemsSource = listLHD;
            cbMaLoaiHD.DisplayMemberPath = "Name";
            cbMaLoaiHD.SelectedValuePath = "ID";
            cbMaLoaiHD.SelectedValue = "1";

            dpNgayKyHD.SelectedDate = DateTime.Today;
            dpNgayHetHan.SelectedDate = Convert.ToDateTime("1/1/2500");
        }
        private void DatePicker_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        public void ChangeDateEnd()
        {
            switch (cbMaLoaiHD.SelectedValue.ToString())
            {
                case "1":
                    dpNgayHetHan.SelectedDate = Convert.ToDateTime("1/1/2500");
                    break;
                case "2":
                    dpNgayHetHan.SelectedDate = ((DateTime)dpNgayKyHD.SelectedDate).AddYears(5).AddDays(-1);
                    break;
                case "3":
                    dpNgayHetHan.SelectedDate = ((DateTime)dpNgayKyHD.SelectedDate).AddYears(3).AddDays(-1);
                    break;
                case "4":
                    dpNgayHetHan.SelectedDate = ((DateTime)dpNgayKyHD.SelectedDate).AddYears(2).AddDays(-1);
                    break;
                case "5":
                    dpNgayHetHan.SelectedDate = ((DateTime)dpNgayKyHD.SelectedDate).AddYears(1).AddDays(-1);
                    break;
                case "6":
                    dpNgayHetHan.SelectedDate = ((DateTime)dpNgayKyHD.SelectedDate).AddMonths(3).AddDays(-1);
                    break;
            }
        }
        private void cbMaLoaiHD_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ChangeDateEnd();
        }

        private void DpNgayKyHD_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            ChangeDateEnd();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            cbMaLoaiHD.SelectionChanged += cbMaLoaiHD_SelectionChanged;
            dpNgayKyHD.SelectedDateChanged += DpNgayKyHD_SelectedDateChanged;
        }
        private void btnNewContact_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridContract.SelectedItem != null)
            {
                dialogHostWarning.DataContext = "Bạn muốn tạo hợp đồng mới cho Mã nhân viên: " + tbMaNV.Text + "!";
                dialogHostWarning.IsOpen = true;
            }
        }

        private void dialogHost_DialogClosing(object sender, DialogClosingEventArgs eventArgs)
        {
            if ((bool)eventArgs.Parameter == true)
            {
                DTO.HopDongDTO hd = new DTO.HopDongDTO();
                hd.MaHD = tbMaHD.Text;
                hd.MaNV = tbMaNV.Text;
                hd.MaLoaiHD = Int16.Parse(cbMaLoaiHD.SelectedValue.ToString());
                hd.NgayKyHD = Convert.ToDateTime(dpNgayKyHD.Text);
                if (dpNgayHetHan.SelectedDate != null && dpNgayHetHan.Text != "")
                    hd.NgayHetHan = Convert.ToDateTime(dpNgayHetHan.Text);
                else hd.NgayHetHan = Convert.ToDateTime("1/1/2500");
                hd.MaTTHD = 1;
                BUS.HopDongBUS.NewHopDong(hd);
                BUS.HopDongBUS.UpdateTinhTrangTimeOut(tbMaHDHide.Text);
                RefreshData();
            }
        }

        private void RefreshData()
        {
            dt = BUS.HopDongBUS.GetHopDongTimeOut();
            dataGridContract.DataContext = dt;
            cbMaLoaiHD.SelectedValue = "1";
            dpNgayKyHD.SelectedDate = DateTime.Today;
            dpNgayHetHan.SelectedDate = Convert.ToDateTime("1/1/2500");
        }

        private void dataGridContract_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mahdLast = BUS.HopDongBUS.GetLastHopDong().Rows[0][0].ToString();
            tbMaHD.Text = NextID(mahdLast, "HD");
        }


        public string NextID(string lastID, string prefixID)
        {
            if (lastID == "")
            {
                return prefixID + "001";  // fixwidth default
            }
            int nextID = int.Parse(lastID.Remove(0, prefixID.Length)) + 1;
            int lengthNumerID = lastID.Trim().Length - prefixID.Length;
            string zeroNumber = "";
            for (int i = 1; i <= lengthNumerID; i++)
            {
                if (nextID < Math.Pow(10, i))
                {
                    for (int j = 1; j <= lengthNumerID - i; i++)
                    {
                        zeroNumber += "0";
                    }
                    return prefixID + zeroNumber + nextID.ToString();
                }
            }
            return prefixID + nextID;
        }
    }
}
