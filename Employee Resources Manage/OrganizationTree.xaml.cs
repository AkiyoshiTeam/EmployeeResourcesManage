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
            }
            else
            {
                var component = organizationTreeViewModel.SelectedItem as DTO.Component;
                if (component != null)
                {
                    where = component.Content;
                }
                else
                {
                    var company = organizationTreeViewModel.SelectedItem as DTO.Company;
                    where = company.Content;
                }
            }
            dt = BUS.NhanVienBUS.GetNhanVienBPPB(where);
            dataGridNhanVien.DataContext = dt;

        }
    }
}
