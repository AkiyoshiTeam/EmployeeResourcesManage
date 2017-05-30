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
    /// Interaction logic for OrganizationTree.xaml
    /// </summary>
    public partial class OrganizationTree : UserControl
    {
        DataTable dt = new DataTable();
        DTO.OrganizationTree organizationTreeViewModel = new DTO.OrganizationTree(BUS.BoPhanBUS.GetBoPhanPhongBan());
        DataTable dtEdit = new DataTable();
        int elementType = 0;
        string maBP = "";
        string maLast = "";
        string status = "";

        public OrganizationTree()
        {
            InitializeComponent();
            treeView.DataContext = organizationTreeViewModel;
            dt = BUS.NhanVienBUS.GetNhanVienBPPB("");
            dataGridNhanVien.DataContext = dt;
        }

        private void treeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (organizationTreeViewModel == null) return;
            organizationTreeViewModel.SelectedItem = e.NewValue;
            var part = organizationTreeViewModel.SelectedItem as DTO.Part;
            string where = "";
            if (part != null)
            {
                where = part.Content;
                exThem.IsEnabled = false;
                exXoa.IsEnabled = true;
                if (part.Status == "1")
                {
                    tbHoatDong.Text = "Đang hoạt động";
                    btnXoa.Content = "Shutdown";
                }
                else
                {
                    tbHoatDong.Text = "Ngừng hoạt động";
                    btnXoa.Content = "Star";
                }
                status = part.Status;
                exSua.IsEnabled = true;
                exXoa.Header = "Ngừng hoạt động phòng ban";
                dt = BUS.NhanVienBUS.GetNhanVienBPPB(where);
                dataGridNhanVien.DataContext = dt;
                cbTruong.ItemsSource = dt.DefaultView;
                dtEdit = BUS.PhongBanBUS.GetPhongBanByWhere(where);
                tbMa.Text = dtEdit.Rows[0][0].ToString();
                tbTen.Text = dtEdit.Rows[0][1].ToString();
                tbViTri.Text = dtEdit.Rows[0][2].ToString();
                tbViTri.IsEnabled = true;
                cbTruong.SelectedValue = dtEdit.Rows[0][3].ToString();
                elementType = 2;
            }
            else
            {
                var component = organizationTreeViewModel.SelectedItem as DTO.Component;
                if (component != null)
                {
                    where = component.Content;
                    maBP = component.About;
                    exThem.IsEnabled = true;
                    exXoa.IsEnabled = true;
                    if (component.Status == "1")
                    {
                        tbHoatDong.Text = "Đang hoạt động";
                        btnXoa.Content = "Shutdown";
                    }
                    else
                    {
                        tbHoatDong.Text = "Ngừng hoạt động";
                        btnXoa.Content = "Star";
                    }
                    status = component.Status;
                    exSua.IsEnabled = true;
                    exThem.Header = "Thêm phòng ban";
                    exXoa.Header = "Ngừng hoạt động bộ phận";
                    dt = BUS.NhanVienBUS.GetNhanVienBPPB(where);
                    dataGridNhanVien.DataContext = dt;
                    cbTruong.ItemsSource = dt.DefaultView;
                    dtEdit = BUS.BoPhanBUS.GetBoPhanByWhere(where);
                    tbMa.Text = dtEdit.Rows[0][0].ToString();
                    tbTen.Text = dtEdit.Rows[0][1].ToString();
                    tbViTri.IsEnabled = false;
                    tbViTriNew.IsEnabled = true;
                    cbTruong.SelectedValue = dtEdit.Rows[0][2].ToString();
                    maLast = BUS.PhongBanBUS.GetLastPhongBan().Rows[0][0].ToString();
                    tbMaNew.Text = NextID(maLast, "PB");
                    elementType = 1;
                }
                else
                {
                    var company = organizationTreeViewModel.SelectedItem as DTO.Company;
                    where = company.Content;
                    exThem.Header = "Thêm bộ phận";
                    exThem.IsEnabled = true;
                    exXoa.IsEnabled = false;
                    exSua.IsEnabled = false;
                    tbViTriNew.IsEnabled = false;
                    dt = BUS.NhanVienBUS.GetNhanVienBPPB(where);
                    dataGridNhanVien.DataContext = dt;
                    maLast = BUS.BoPhanBUS.GetLastBoPhan().Rows[0][0].ToString();
                    tbMaNew.Text = NextID(maLast, "BP");
                    elementType = 0;
                }
            }
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            if (tbTen.Text != "")
            {
                if (elementType == 1)
                {
                    DTO.BoPhanDTO bp = new DTO.BoPhanDTO();
                    bp.MaBP = tbMa.Text;
                    bp.TenBP = tbTen.Text;
                    bp.TruongBP = cbTruong.SelectedValue.ToString();
                    BUS.NguoiDungBUS.SetIsUpdated(Login.Account);
                    BUS.BoPhanBUS.UpdateBoPhan(bp);
                }
                if (elementType == 2)
                {
                    DTO.PhongBanDTO pb = new DTO.PhongBanDTO();
                    pb.MaPB = tbMa.Text;
                    pb.ViTri = tbViTri.Text;
                    pb.TenPB = tbTen.Text;
                    pb.TruongPB = cbTruong.SelectedValue.ToString();
                    BUS.NguoiDungBUS.SetIsUpdated(Login.Account);
                    BUS.PhongBanBUS.UpdatePhongBan(pb);
                }
                Refresh();
            }
            else
            {
                DialogWarning dgWar = new DialogWarning();
                dgWar.Content = "Không được bỏ trống tên!";
                dgWar.Acc = "false";
                dialogHostWarning.DataContext = dgWar;
                dialogHostWarning.IsOpen = true;
            }
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            if (tbTenNew.Text != "")
            {
                if (elementType == 0)
                {
                    DTO.BoPhanDTO bp = new DTO.BoPhanDTO();
                    maLast = BUS.BoPhanBUS.GetLastBoPhan().Rows[0][0].ToString();
                    tbMaNew.Text = NextID(maLast, "BP");
                    bp.MaBP = tbMaNew.Text;
                    bp.TenBP = tbTenNew.Text;
                    BUS.NguoiDungBUS.SetIsUpdated(Login.Account);
                    BUS.BoPhanBUS.AddBoPhan(bp);
                }
                if (elementType == 1)
                {
                    DTO.PhongBanDTO pb = new DTO.PhongBanDTO();
                    maLast = BUS.PhongBanBUS.GetLastPhongBan().Rows[0][0].ToString();
                    tbMaNew.Text = NextID(maLast, "PB");
                    pb.MaPB = tbMaNew.Text;
                    pb.TenPB = tbTenNew.Text;
                    pb.ViTri = tbViTriNew.Text;
                    pb.MaBP = maBP;
                    BUS.NguoiDungBUS.SetIsUpdated(Login.Account);
                    BUS.PhongBanBUS.AddPhongBan(pb);
                }
                Refresh();
            }
            else
            {
                DialogWarning dgWar = new DialogWarning();
                dgWar.Content = "Không được bỏ trống tên!";
                dgWar.Acc = "false";
                dialogHostWarning.DataContext = dgWar;
                dialogHostWarning.IsOpen = true;
            }
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            if (status == "1")
            {
                if (elementType == 1)
                {
                    if (dt.Rows.Count > 0)
                    {
                        DialogWarning dgWar = new DialogWarning();
                        dgWar.Content = "Bạn muốn sa thải tất cả " + dt.Rows.Count.ToString() + " nhân viên và ngừng hoạt động bộ phận???";
                        dgWar.Acc = "true";
                        dialogHostWarning.DataContext = dgWar;
                        dialogHostWarning.IsOpen = true;
                    }
                    else
                    {
                        DialogWarning dgWar = new DialogWarning();
                        dgWar.Content = "Bạn muốn ngừng hoạt động bộ phận???";
                        dgWar.Acc = "true";
                        dialogHostWarning.DataContext = dgWar;
                        dialogHostWarning.IsOpen = true;
                    }
                }
                if (elementType == 2)
                {
                    if (dt.Rows.Count > 0)
                    {
                        DialogWarning dgWar = new DialogWarning();
                        dgWar.Content = "Bạn muốn sa thải tất cả " + dt.Rows.Count.ToString() + " nhân viên và ngừng hoạt động phòng ban???";
                        dgWar.Acc = "true";
                        dialogHostWarning.DataContext = dgWar;
                        dialogHostWarning.IsOpen = true;
                    }
                    else
                    {
                        DialogWarning dgWar = new DialogWarning();
                        dgWar.Content = "Bạn muốn ngừng hoạt động phòng ban???";
                        dgWar.Acc = "true";
                        dialogHostWarning.DataContext = dgWar;
                        dialogHostWarning.IsOpen = true;
                    }
                }
            }
            if (status == "2")
            {
                if (elementType == 1)
                {
                    DialogWarning dgWar = new DialogWarning();
                    dgWar.Content = "Tái hoạt động bộ phận?";
                    dgWar.Acc = "true";
                    dialogHostWarning.DataContext = dgWar;
                    dialogHostWarning.IsOpen = true;
                }
                if (elementType == 2)
                {
                    DialogWarning dgWar = new DialogWarning();
                    dgWar.Content = "Tái hoạt động phòng ban?";
                    dgWar.Acc = "true";
                    dialogHostWarning.DataContext = dgWar;
                    dialogHostWarning.IsOpen = true;
                }
            }
        }

        public string NextID(string lastID, string prefixID)
        {
            if (lastID == "")
            {
                return prefixID + "001";
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

        private void dialogHost_DialogClosing(object sender, DialogClosingEventArgs eventArgs)
        {
            if ((bool)eventArgs.Parameter == true)
            {
                if (status == "1")
                {
                    if (dt.Rows.Count > 0)
                    {
                        BUS.NguoiDungBUS.SetIsUpdated(Login.Account);
                        BUS.NhanVienBUS.LayoffNhanVien(dt);
                    }
                    if (elementType == 1)
                    {
                        DTO.BoPhanDTO bp = new DTO.BoPhanDTO();
                        bp.MaBP = tbMa.Text;
                        bp.TenBP = tbTen.Text;
                        bp.TruongBP = cbTruong.SelectedValue.ToString();
                        BUS.NguoiDungBUS.SetIsUpdated(Login.Account);
                        BUS.BoPhanBUS.ShutdownBoPhan(bp);
                    }
                    if (elementType == 2)
                    {
                        DTO.PhongBanDTO pb = new DTO.PhongBanDTO();
                        pb.MaPB = tbMa.Text;
                        pb.ViTri = tbViTri.Text;
                        pb.TenPB = tbTen.Text;
                        pb.TruongPB = cbTruong.SelectedValue.ToString();
                        BUS.NguoiDungBUS.SetIsUpdated(Login.Account);
                        BUS.PhongBanBUS.ShutdownPhongBan(pb);
                    }
                }
                if (status == "2")
                {
                    if (elementType == 1)
                    {
                        DTO.BoPhanDTO bp = new DTO.BoPhanDTO();
                        bp.MaBP = tbMa.Text;
                        bp.TenBP = tbTen.Text;
                        bp.TruongBP = cbTruong.SelectedValue.ToString();
                        BUS.NguoiDungBUS.SetIsUpdated(Login.Account);
                        BUS.BoPhanBUS.StartBoPhan(bp);
                    }
                    if (elementType == 2)
                    {
                        DTO.PhongBanDTO pb = new DTO.PhongBanDTO();
                        pb.MaPB = tbMa.Text;
                        pb.ViTri = tbViTri.Text;
                        pb.TenPB = tbTen.Text;
                        pb.TruongPB = cbTruong.SelectedValue.ToString();
                        BUS.NguoiDungBUS.SetIsUpdated(Login.Account);
                        BUS.PhongBanBUS.StartPhongBan(pb);
                    }
                }
                Refresh();
            }
        }
        
        public void Refresh()
        {
            organizationTreeViewModel = new DTO.OrganizationTree(BUS.BoPhanBUS.GetBoPhanPhongBan());
            treeView.DataContext = organizationTreeViewModel;
            dt = BUS.NhanVienBUS.GetNhanVienBPPB("");
            dataGridNhanVien.DataContext = dt;
            exThem.Header = "Thêm bộ phận";
            exThem.IsEnabled = true;
            exXoa.IsEnabled = false;
            exSua.IsEnabled = false;
            tbViTriNew.IsEnabled = false;
            maLast = BUS.BoPhanBUS.GetLastBoPhan().Rows[0][0].ToString();
            tbMaNew.Text = NextID(maLast, "BP");
            elementType = 0;
        }

    }
}
