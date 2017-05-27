using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for SalaryDeleteByTime.xaml
    /// </summary>
    public partial class SalaryDeleteByTime : UserControl
    {
        bool isNum = false;

        public SalaryDeleteByTime()
        {
            InitializeComponent();
        }

        private void txtInt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if((sender as TextBox).Text =="")
            {
                if(e.Text=="*")
                {
                    isNum = false;
                }
                else
                {
                    isNum = true;
                }
                e.Handled = !IsNumeric(e.Text);
            }
            else
            {
                if(e.Text=="*" || isNum == false)
                {
                    e.Handled = true;
                }
                else e.Handled = !IsNumeric(e.Text);
            }
        }

        private static bool IsNumeric(string text)
        {
            Regex regex = new Regex(@"[\d\*]");
            return regex.IsMatch(text);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(tbThang.Text!="" && tbNam.Text!="")
            {
                btnDelete.IsEnabled = true;
            }
            else
            {
                btnDelete.IsEnabled = false;
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            string thang = "";
            string nam = "";
            if (tbThang.Text == "*")
                thang = "1=1";
            else thang = "Thang="+tbThang.Text;
            if (tbNam.Text == "*")
                nam = "1=1";
            else nam = "Nam=" + tbNam.Text;

            BUS.BangLuongBUS.DeleteBangLuongByTime(thang, nam);
        }
    }
}
