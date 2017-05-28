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
using MahApps.Metro.Controls;
using Employee_Resources_Manage.Domain;
using System.Windows.Controls.Primitives;
using System.Threading;
using MaterialDesignThemes.Wpf.Transitions;
using MahApps.Metro;
using MaterialDesignThemes.Wpf;
using Dragablz;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;

namespace Employee_Resources_Manage
{

    public class BoPhan
    {
        public string Name { get; set; }
        public string ID { get; set; }
    }
    public class PhongBan
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public string MaBP { get; set; }
    }
    public class LoaiHopDong
    {
        public string Name { get; set; }
        public string ID { get; set; }
    }
    public class TinhTrangHopDong
    {
        public string Name { get; set; }
        public string ID { get; set; }
    }
    public class LoaiLuong
    {
        public string Name { get; set; }
        public string ID { get; set; }
    }
    public class TinhTrang
    {
        public string Name { get; set; }
        public string ID { get; set; }
    }
    public class ChucVu
    {
        public string Name { get; set; }
        public string ID { get; set; }
    }
    public class GioiTinh
    {
        public string Name { get; set; }
        public bool ID { get; set; }
    }
    public class QuanHuyen
    {
        public string MaTinh { get; set; }
        public string Name { get; set; }
        public string ID { get; set; }
    }
    public class TinhTP
    {
        public string MaQG { get; set; }
        public string Name { get; set; }
        public string ID { get; set; }
    }
    public class QuocGia
    {
        public string Name { get; set; }
        public string ID { get; set; }
    }
    public class TonGiao
    {
        public string Name { get; set; }
        public string ID { get; set; }
    }
    public class DanToc
    {
        public string Name { get; set; }
        public string ID { get; set; }
    }
    public class DialogWarning
    {
        string acc;
        string content;
        public string Acc { get => acc; set => acc = value; }
        public string Content { get => content; set => content = value; }
    }
    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return new BitmapImage(new Uri(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString() + @"\Resources\Images\Avatar\" + ((string)value), UriKind.RelativeOrAbsolute));
            }
            catch
            {
                return new BitmapImage(new Uri(@"../../Resources/Images/account-card-details-black-2.png", UriKind.RelativeOrAbsolute));
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class MaPBConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return MainWindow.listPB.Find(x => x.ID.Contains((string)value)).Name;
            }
            catch
            {
                return "";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class MaTTConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return MainWindow.listTT.Find(x => x.ID.Contains(((int)value).ToString())).Name;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class MaGTConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return MainWindow.listGT.Find(x => x.ID == (bool)value).Name;
            }
            catch
            {
                return "";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class MaQHConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return MainWindow.listQH.Find(x => x.ID.Contains((string)value)).Name;
            }
            catch
            {
                return "";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class MaTTPConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return MainWindow.listTTP.Find(x => x.ID.Contains((string)value)).Name;
            }
            catch
            {
                return "";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class MaQGConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return MainWindow.listQG.Find(x => x.ID.Contains((string)value)).Name;
            }
            catch
            {
                return "";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class MaDTConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return MainWindow.listDT.Find(x => x.ID.Contains((string)value)).Name;
            }
            catch
            {
                return "";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class MaTGConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return MainWindow.listTG.Find(x => x.ID.Contains((string)value)).Name;
            }
            catch
            {
                return "";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class MaLHDConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return MainWindow.listLHD.Find(x => x.ID.Contains(((int)value).ToString())).Name;
            }
            catch
            {
                return "";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class MaTTHDConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return MainWindow.listTTHD.Find(x => x.ID.Contains(((int)value).ToString())).Name;
            }
            catch
            {
                return "";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        ListsAndGridsViewModel manageItems = new ListsAndGridsViewModel();
        public static DataTable selectedTableStatic;
        public static DataTable selectedTableDesStatic;
        public static List<PhongBan> listPB = new List<PhongBan>();
        public static List<TinhTrang> listTT = new List<TinhTrang>();
        public static List<GioiTinh> listGT = new List<GioiTinh>();
        public static List<QuanHuyen> listQH = new List<QuanHuyen>();
        public static List<TinhTP> listTTP = new List<TinhTP>();
        public static List<QuocGia> listQG = new List<QuocGia>();
        public static List<DanToc> listDT = new List<DanToc>();
        public static List<TonGiao> listTG = new List<TonGiao>();
        public static List<LoaiHopDong> listLHD = new List<LoaiHopDong>();
        public static List<TinhTrangHopDong> listTTHD = new List<TinhTrangHopDong>();
        //public static SqlCommandBuilder cbEditEmployee;

        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        bool tabHomeExist = true;
        bool IsChangedTheme = false;
        object palContent;
        bool isOkay = false;

        public MainWindow()
        {
            InitializeComponent();

            manageItemsControl.DataContext = manageItems;
            manageItemsControl2.DataContext = manageItems;
            tbAccount.Text = Login.Account;
            ellAvatar.Height = 22;
            ellAvatar.Width = 22;
            ellAvatar.Fill = new ImageBrush(new BitmapImage(new Uri(@"..\..\Resources\Images\Avatar\" + Login.Avatar, UriKind.RelativeOrAbsolute)));
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(1500);
            }).ContinueWith(t =>
            {
                MainSnackbar.MessageQueue.Enqueue("Phần mềm quản lý nhân sự Công Ty Akiyoshi");
            }, TaskScheduler.FromCurrentSynchronizationContext());
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            dispatcherTimer.Start();

            tbDate.Text = DateTime.Today.ToString("yyyy/MM/dd");
        }

        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MetroWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.E && Keyboard.IsKeyDown(Key.LeftCtrl))
            {
                Close();
            }
        }

        private void UIElement_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //until we had a StaysOpen glag to Drawer, this will help with scroll bars
            var dependencyObject = Mouse.Captured as DependencyObject;
            while (dependencyObject != null)
            {
                if (dependencyObject is ScrollBar) return;
                dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
            }
            if (Transitioner.SelectedIndex == 0)
            {
                borderManageControl2.SetResourceReference(Border.BackgroundProperty, "PrimaryHueMidBrush");
                borderManageControl1.SetResourceReference(Border.BackgroundProperty, "PrimaryHueLightBrush");
                tbManage2.Text = ((SelectableViewModel)manageItemsControl.SelectedItem).Name;
                packIconListViewSelected2.Kind = (PackIconKind)((SelectableViewModel)manageItemsControl.SelectedItem).IconNum;
                Transitioner.SelectedIndex = 1;
            }
            else
            {
                borderManageControl1.SetResourceReference(Border.BackgroundProperty, "PrimaryHueMidBrush");
                borderManageControl2.SetResourceReference(Border.BackgroundProperty, "PrimaryHueLightBrush");
                packIconListViewSelected1.Kind = (PackIconKind)((SelectableViewModel)manageItemsControl.SelectedItem).IconNum;
                tbManage1.Text = ((SelectableViewModel)manageItemsControl.SelectedItem).Name;
                Transitioner.SelectedIndex = 0;
            }
            switch (((SelectableViewModel)manageItemsControl.SelectedItem).Name)
            {
                case "Employees Resources":
                    manageItemsControl2.ItemsSource = manageItems.Items2;
                    break;
                case "Company":
                    manageItemsControl2.ItemsSource = manageItems.Items3;
                    break;
                case "Payroll":
                    manageItemsControl2.ItemsSource = manageItems.Items5;
                    break;
                case "Time Attendance":
                    manageItemsControl2.ItemsSource = manageItems.Items6;
                    break;
            }
            MenuToggleButton.IsChecked = false;
        }

        private void UIElementChild_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (isOkay == false)
            {
                var view = CollectionViewSource.GetDefaultView(tabMain.Items);
                view.CollectionChanged += (o, ev) =>
                {
                    if (tabMain.Items.Count == 0)
                    {
                        TabItem tabItem = new TabItem();
                        tabItem.Header = "Home";
                        tabItem.Name = "tabHome";
                        tabHomeExist = true;
                        tabItem.IsSelected = true;
                        tabMain.Items.Add(tabItem);

                    }
                    else if (tabMain.Items.Count == 1)
                    {
                        if (tabHomeExist)
                            tabMain.FixedHeaderCount = 1;
                        else
                            tabMain.FixedHeaderCount = 0;
                        tabMain.InterTabController = null;
                    }
                    else
                    {
                        tabMain.InterTabController = new InterTabController();
                    }
                };
                isOkay = true;
            }


            var dependencyObject = Mouse.Captured as DependencyObject;
            while (dependencyObject != null)
            {
                if (dependencyObject is ListView)
                {
                    TabItem tab = new TabItem();
                    tab.Header = ((SelectableViewModel)manageItemsControl2.SelectedItem).Name;
                    switch (((SelectableViewModel)manageItemsControl2.SelectedItem).Name)
                    {
                        case "Employees Search":
                            var searchControl = new SearchEmployee();
                            tab.Content = searchControl;
                            break;
                        case "Employees Selector":
                            var selectorControl = new SelectorEmployee();
                            tab.Content = selectorControl;
                            break;
                        case "Add Employee":
                            var addEmployeeControl = new AddEmployee();
                            tab.Content = addEmployeeControl;
                            break;
                        case "Add Multiple Employees":
                            var addMultipleEmployeeControl = new AddMultipleEmployees();
                            tab.Content = addMultipleEmployeeControl;
                            break;
                        case "Edit Employees":
                            if (selectedTableStatic != null)
                            {
                                if (selectedTableStatic.Rows.Count > 0)
                                {
                                    var editEmployeeControl = new EditEmployee();
                                    tab.Content = editEmployeeControl;
                                }
                                else
                                {
                                    tab.Header = "Employees Selector";
                                    var selectorControlTemp1 = new SelectorEmployee();
                                    tab.Content = selectorControlTemp1;
                                }
                            }
                            else
                            {
                                tab.Header = "Employees Selector";
                                var selectorControlTemp1 = new SelectorEmployee();
                                tab.Content = selectorControlTemp1;
                            }
                            break;
                        case "Layoff Employees":
                            if (selectedTableStatic != null)
                            {
                                if (selectedTableStatic.Rows.Count > 0)
                                {
                                    var layoffEmployeeControl = new LayoffEmployees();
                                    tab.Content = layoffEmployeeControl;
                                }
                                else
                                {
                                    tab.Header = "Employees Selector";
                                    var selectorControlTemp1 = new SelectorEmployee();
                                    tab.Content = selectorControlTemp1;
                                }
                            }
                            else
                            {
                                tab.Header = "Employees Selector";
                                var selectorControlTemp2 = new SelectorEmployee();
                                tab.Content = selectorControlTemp2;
                            }
                            break;
                        case "Delete Employees":
                            if (selectedTableStatic != null)
                            {
                                if (selectedTableStatic.Rows.Count > 0)
                                {
                                    var deleteEmployeeControl = new DeleteEmployee();
                                    tab.Content = deleteEmployeeControl;
                                }
                                else
                                {
                                    tab.Header = "Employees Selector";
                                    var selectorControlTemp1 = new SelectorEmployee();
                                    tab.Content = selectorControlTemp1;
                                }
                            }
                            else
                            {
                                tab.Header = "Employees Selector";
                                var selectorControlTemp2 = new SelectorEmployee();
                                tab.Content = selectorControlTemp2;
                            }
                            break;
                        case "Contract":
                            var contractControl = new Contract();
                            tab.Content = contractControl;
                            break;
                        case "Organization Tree":
                            var organizationTreeControl = new OrganizationTree();
                            tab.Content = organizationTreeControl;
                            break;
                        case "Report":
                            var reportControl = new BaoCao();
                            tab.Content = reportControl;
                            break;
                        case "Default":
                            var defaultControl = new DefaultTime();
                            tab.Content = defaultControl;
                            break;
                        case "Download":
                            DialogHost.Show(new DownloadSheet(), "RootDialog");
                            return;
                        //case "Assign Shift":
                        //    var assignControl = new SearchEmployee();
                        //    tab.Content = assignControl;
                        //    break;
                        case "Salary Calculating":
                            if (selectedTableStatic != null)
                            {
                                if (selectedTableStatic.Rows.Count > 0)
                                {
                                    var salaryCalControl = new SalaryCalculating();
                                    tab.Content = salaryCalControl;
                                }
                                else
                                {
                                    tab.Header = "Employees Selector";
                                    var selectorControlTemp1 = new SelectorEmployee();
                                    tab.Content = selectorControlTemp1;
                                }
                            }
                            else
                            {
                                tab.Header = "Employees Selector";
                                var selectorControlTemp1 = new SelectorEmployee();
                                tab.Content = selectorControlTemp1;
                            }
                            break;
                        case "Salary Formula":
                            DialogHost.Show(new SalaryFormula(), "RootDialog");
                            return;
                    }
                    tab.IsSelected = true;
                    tabMain.Items.Add(tab);
                    if (tabHomeExist == true)
                    {
                        int i = 0;
                        bool tabHome = false;
                        foreach (TabItem ti in tabMain.Items)
                        {
                            if (ti.Name == "tabHome")
                            {
                                tabHome = true;
                                break;
                            }
                            i++;
                        }
                        if (tabHome == true)
                            tabMain.Items.RemoveAt(i);
                        tabHomeExist = false;
                        tabMain.FixedHeaderCount = 0;
                    }
                    return;
                }
                dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
            }
        }


        private void MenuItemTheme_Click(object sender, RoutedEventArgs e)
        {
            TransitioningContent transitioningContent = new TransitioningContent();
            TransitionEffect effect = new TransitionEffect();
            effect.Kind = TransitionEffectKind.FadeIn;
            transitioningContent.OpeningEffect = effect;

            if (IsChangedTheme == false)
            {
                palContent = new PaletteSelector(contentControl);
                transitioningContent.Content = palContent;
                contentControl.Content = transitioningContent;
                IsChangedTheme = true;
            }
            else
            {
                transitioningContent.Content = palContent;
                contentControl.Content = transitioningContent;
            }
        }

        private void MenuItemChangePassword_Click(object sender, RoutedEventArgs e)
        {
            ChangePassword changePw = new ChangePassword();
            DialogHost.Show(changePw, "RootDialog");
        }


        private void UIManageControl_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MenuToggleButton.IsChecked = (MenuToggleButton.IsChecked == false) ? true : false;
        }

        bool collapseIsCheck = true;

        private void btnCollapse_Click(object sender, RoutedEventArgs e)
        {
            if (collapseIsCheck == false)
            {
                colChucNang.MinWidth = 47;
                colChucNang.MaxWidth = 47;
                packIconCollapse.Kind = PackIconKind.ChevronRight;
                collapseIsCheck = true;
            }
            else
            {
                colChucNang.MinWidth = 200;
                colChucNang.MaxWidth = 400;
                packIconCollapse.Kind = PackIconKind.ChevronLeft;
                collapseIsCheck = false;
            }
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            if (tabHomeExist == false)
            {
                TabItem tabItem = new TabItem();
                tabItem.Header = "Home";
                tabItem.Name = "tabHome";
                tabItem.IsSelected = true;
                tabMain.Items.Add(tabItem);
                tabHomeExist = true;
            }
            else
            {
                foreach (TabItem ti in tabMain.Items)
                {
                    if (ti.Name == "tabHome")
                    { ti.IsSelected = true; break; }

                }
            }
        }
        private void btnSelector_Click(object sender, RoutedEventArgs e)
        {
            TabItem tab = new TabItem();
            tab.Header = "Selector";
            SelectorEmployee selectorControl = new SelectorEmployee();
            tab.Content = selectorControl;
            tab.IsSelected = true;
            tabMain.Items.Add(tab);
            if (isOkay == false)
            {
                var view = CollectionViewSource.GetDefaultView(tabMain.Items);
                view.CollectionChanged += (o, ev) =>
                {
                    if (tabMain.Items.Count == 0)
                    {
                        TabItem tabItem = new TabItem();
                        tabItem.Header = "Home";
                        tabItem.Name = "tabHome";
                        tabItem.IsSelected = true;
                        tabMain.Items.Add(tabItem);
                        tabHomeExist = true;
                    }
                    else if (tabMain.Items.Count == 1)
                    {
                        if (tabHomeExist)
                            tabMain.FixedHeaderCount = 1;
                        else
                            tabMain.FixedHeaderCount = 0;
                        tabMain.InterTabController = null;
                    }
                    else
                    {
                        tabMain.InterTabController = new InterTabController();
                    }
                };
                isOkay = true;
            }
            if (tabHomeExist == true)
            {
                int i = 0;
                bool tabHome = false;
                foreach (TabItem ti in tabMain.Items)
                {
                    if (ti.Name == "tabHome")
                    {
                        tabHome = true;
                        break;
                    }
                    i++;
                }
                if (tabHome == true)
                    tabMain.Items.RemoveAt(i);
                tabHomeExist = false;
                tabMain.FixedHeaderCount = 0;
            }
        }

        private void btnEditEmployee_Click(object sender, RoutedEventArgs e)
        {
            TabItem tab = new TabItem();
            tab.Header = "Edit Employee";
            EditEmployee selectorControl = new EditEmployee();
            tab.Content = selectorControl;
            tab.IsSelected = true;
            tabMain.Items.Add(tab);
            if (isOkay == false)
            {
                var view = CollectionViewSource.GetDefaultView(tabMain.Items);
                view.CollectionChanged += (o, ev) =>
                {
                    if (tabMain.Items.Count == 0)
                    {
                        TabItem tabItem = new TabItem();
                        tabItem.Header = "Home";
                        tabItem.Name = "tabHome";
                        tabItem.IsSelected = true;
                        tabMain.Items.Add(tabItem);
                        tabHomeExist = true;
                    }
                    else if (tabMain.Items.Count == 1)
                    {
                        if (tabHomeExist)
                            tabMain.FixedHeaderCount = 1;
                        else
                            tabMain.FixedHeaderCount = 0;
                        tabMain.InterTabController = null;
                    }
                    else
                    {
                        tabMain.InterTabController = new InterTabController();
                    }
                };
                isOkay = true;
            }
            if (tabHomeExist == true)
            {
                int i = 0;
                bool tabHome = false;
                foreach (TabItem ti in tabMain.Items)
                {
                    if (ti.Name == "tabHome")
                    {
                        tabHome = true;
                        break;
                    }
                    i++;
                }
                if (tabHome == true)
                    tabMain.Items.RemoveAt(i);
                tabHomeExist = false;
                tabMain.FixedHeaderCount = 0;
            }
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (tabMain != null)
            {
                if (tabMain.Items.Count > 0)
                    if ((tabMain.Items[0] as TabItem).Header.ToString() == "Home")
                        tabMain.FixedHeaderCount = 1;
            }
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            tbTime.Text = DateTime.Now.ToString("hh:mm:ss tt");
            if (tbTime.Text == "00:00:00 CH" || tbTime.Text == "00:00:01 CH")
            {
                tbDate.Text = DateTime.Today.ToString("yyyy/MM/dd");
            }
        }
    }
}
