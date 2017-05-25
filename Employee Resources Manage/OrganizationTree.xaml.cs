using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
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
        public OrganizationTree()
        {
            InitializeComponent();
            treeView.DataContext = new DTO.OrganizationTree(BUS.BoPhanBUS.GetBoPhanPhongBan());
        }


        private void dialogHost_DialogClosing(object sender, DialogClosingEventArgs eventArgs)
        {
            if ((bool)eventArgs.Parameter == true)
            {
                
            }
        }
    }
}
