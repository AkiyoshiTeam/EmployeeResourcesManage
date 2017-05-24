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
    /// Interaction logic for DefaultTime.xaml
    /// </summary>
    public partial class DefaultTime : UserControl
    {
        DataTable dtDefault = new DataTable();
        DataTable dtNotDefault = new DataTable();
        List<string> listDefault = new List<string>();
        List<string> listNotDefault = new List<string>();
        public DefaultTime()
        {
            InitializeComponent();
            dtDefault = BUS.ChamCongMacDinhBUS.GetDefault();
            dtNotDefault = BUS.ChamCongMacDinhBUS.GetNotDefault();
            dataGridDefault.DataContext = dtDefault;
            dataGridNotDefault.DataContext = dtNotDefault;
        }

        private void btnAddDefault_Click(object sender, RoutedEventArgs e)
        {
            listNotDefault = new List<string>();
            try
            {
                for (int i = 0; i < dataGridNotDefault.SelectedItems.Count; i++)
                {
                    DataRowView rowSelected = (DataRowView)dataGridNotDefault.SelectedItems[i];
                    listNotDefault.Add(rowSelected[0].ToString());
                }
                BUS.ChamCongMacDinhBUS.AddDefault(listNotDefault);
                Refresh();
            }
            catch { }
        }

        private void btnReAddDefault_Click(object sender, RoutedEventArgs e)
        {
            listDefault = new List<string>();
            try
            {
                for (int i = 0; i < dataGridDefault.SelectedItems.Count; i++)
                {
                    DataRowView rowSelected = (DataRowView)dataGridDefault.SelectedItems[i];
                    listDefault.Add(rowSelected[0].ToString());
                }
                BUS.ChamCongMacDinhBUS.RemoveDefault(listDefault);
                Refresh();
            }
            catch { }
        }

        public void Refresh()
        {
            dtDefault = BUS.ChamCongMacDinhBUS.GetDefault();
            dtNotDefault = BUS.ChamCongMacDinhBUS.GetNotDefault();
            dataGridDefault.DataContext = dtDefault;
            dataGridNotDefault.DataContext = dtNotDefault;
        }
    }
}
