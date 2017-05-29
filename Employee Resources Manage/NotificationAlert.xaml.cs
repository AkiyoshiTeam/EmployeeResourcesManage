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
    /// Interaction logic for NotificationAlert.xaml
    /// </summary>
    public partial class NotificationAlert : UserControl
    {
        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        int count = 0;
        LinearGradientBrush gradient1 = new LinearGradientBrush();
        LinearGradientBrush gradient2 = new LinearGradientBrush();
        public NotificationAlert()
        {
            InitializeComponent();
            DateTime nextWeek = DateTime.Today.AddDays(7);
            count = BUS.HopDongBUS.GetHopDongCountAlert(nextWeek.ToString("yyyy-MM-dd"));
            gradient1.StartPoint = new Point(0.5, 0);
            gradient1.EndPoint = new Point(0.5, 1);
            gradient1.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#FF8B36E0"), 0));
            gradient1.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#FFCF2828"), 1));
            gradient2.StartPoint = new Point(0.5, 0);
            gradient2.EndPoint = new Point(0.5, 1);
            gradient2.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#FFC0CD3D"), 0));
            gradient2.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#FF28CF92"), 1));

            if (count > 0)
            {
                btnNewContract.Background = gradient1;
                tbContent.Text = "Có tổng cộng " + count + " hợp đồng sắp hết hạn.";
            }
            else
            {
                btnNewContract.Background = gradient2;
                tbContent.Text = "Không có hợp đồng sắp hết hạn.";
            }
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 5, 0);
            dispatcherTimer.Start();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (count > 0)
            {
                AlertContract alert = new AlertContract();
                DialogHost.Show(alert, "RootDialog");
            }
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            DateTime nextWeek = DateTime.Today.AddDays(7);
            count = BUS.HopDongBUS.GetHopDongCountAlert(nextWeek.ToString("yyyy-MM-dd"));
            if (count > 0)
            {
                btnNewContract.Background = gradient1;
                tbContent.Text = "Có tổng cộng " + count + " hợp đồng sắp hết hạn.";
            }
            else
            {
                btnNewContract.Background = gradient2;
                tbContent.Text = "Không có hợp đồng sắp hết hạn.";
            }
        }
    }
}
