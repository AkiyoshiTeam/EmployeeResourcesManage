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
        public OrganizationTree()
        {
            InitializeComponent();
            treeView.DataContext = organizationTreeViewModel;
            dt = BUS.NhanVienBUS.GetNhanVienBPPB("");
            dataGridNhanVien.DataContext = dt;
        }


        private void dialogHost_DialogClosing(object sender, DialogClosingEventArgs eventArgs)
        {
            if ((bool)eventArgs.Parameter == true)
            {
                
            }
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
            }
            else
            {
                var component = organizationTreeViewModel.SelectedItem as DTO.Component;
                if (component != null)
                {
                    where = component.Content;
                    exThem.IsEnabled = true;
                    exXoa.IsEnabled = true;
                    exThem.Header = "Thêm phòng ban";
                    exXoa.Header = "Ngừng hoạt động bộ phận";
                    dt = BUS.NhanVienBUS.GetNhanVienBPPB(where);
                    dataGridNhanVien.DataContext = dt;
                    cbTruong.ItemsSource = dt.DefaultView;
                    dtEdit = BUS.BoPhanBUS.GetBoPhanByWhere(where);
                    tbMa.Text = dtEdit.Rows[0][0].ToString();
                    tbTen.Text = dtEdit.Rows[0][1].ToString();
                    tbViTri.IsEnabled = false;
                    cbTruong.SelectedValue = dtEdit.Rows[0][2].ToString();
                }
                else
                {
                    var company = organizationTreeViewModel.SelectedItem as DTO.Company;
                    where = company.Content;
                    exThem.Header = "Thêm bộ phận";
                    exThem.IsEnabled = true;
                    exXoa.IsEnabled = false;
                    dt = BUS.NhanVienBUS.GetNhanVienBPPB(where);
                    dataGridNhanVien.DataContext = dt;
                    tbViTri.IsEnabled = false;
                }
            }
            

        }
    }
}
