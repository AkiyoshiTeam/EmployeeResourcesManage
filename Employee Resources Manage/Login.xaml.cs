using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DTO;
using BUS;
using System.Data;

namespace Employee_Resources_Manage
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    internal enum AccentState
    {
        ACCENT_DISABLED = 0,
        ACCENT_ENABLE_GRADIENT = 1,
        ACCENT_ENABLE_TRANSPARENTGRADIENT = 2,
        ACCENT_ENABLE_BLURBEHIND = 3,
        ACCENT_INVALID_STATE = 4
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct AccentPolicy
    {
        public AccentState AccentState;
        public int AccentFlags;
        public int GradientColor;
        public int AnimationId;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct WindowCompositionAttributeData
    {
        public WindowCompositionAttribute Attribute;
        public IntPtr Data;
        public int SizeOfData;
    }

    internal enum WindowCompositionAttribute
    {
        // ...
        WCA_ACCENT_POLICY = 19
        // ...
    }

    public class TextFieldsViewModel : INotifyPropertyChanged
    {

        public TextFieldsViewModel()
        {
        }

        public string Name
        {
            get; set;
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }

    public partial class Login : Window
    {
        [DllImport("user32.dll")]
        internal static extern int SetWindowCompositionAttribute(IntPtr hwnd, ref WindowCompositionAttributeData data);

        public Login()
        {
            InitializeComponent();
            TextFieldsViewModel tfvm = new TextFieldsViewModel();
            txtTaiKhoan.DataContext = tfvm;
        }

        private void Thoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        bool ch = false;
        Ellipse ell = new Ellipse();

        private void DangNhap_Click(object sender, RoutedEventArgs e)
        {
            DangNhap();
        }

        private void txtMatKhau_PasswordChanged(object sender, RoutedEventArgs e)
        {
            lbThongbao.Content = "";
        }

        private void txtDangNhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                DangNhap();
        }


        private void DangNhap()
        {
            NguoiDungDTO nd = new NguoiDungDTO();
            string pass = "", username = "", phanquyen = "", hinhanh = "";
            username = txtTaiKhoan.Text;
            if (NguoiDungBUS.DangNhap(username).Rows.Count > 0)
            {
                foreach (DataRow row in NguoiDungBUS.DangNhap(username).Rows)
                {
                    pass = row["Password"].ToString();
                    phanquyen = row["MaPQ"].ToString();
                    hinhanh = row["HinhAnh"].ToString();
                }
                if (ch == true && txtMatKhau.Password != pass)
                {
                    ell.Stroke = Brushes.Red;
                    ell.StrokeThickness = 1;
                    lbThongbao.Content = "Sai mật khẩu.";
                }
                if (ch == false && txtTaiKhoan.Text == username)
                {
                    TransitioningContent transitioningContent = new TransitioningContent();
                    TransitionEffect effect = new TransitionEffect();
                    effect.Kind = TransitionEffectKind.ExpandIn;
                    transitioningContent.OpeningEffect = effect;
                    object avatarContent;
                    ell.Height = 150;
                    ell.Width = 150;
                    //Binding bnd = new Binding("BorderBrush") { ElementName = "txtMatKhau" };
                    //BindingOperations.SetBinding(ell, Ellipse.StrokeProperty, bnd);
                    ell.Stroke = Brushes.Transparent;
                    ell.StrokeThickness = 1;
                    ell.Fill = new ImageBrush(new BitmapImage(new Uri(@"..\..\Resources\Images\Avatar\" + hinhanh, UriKind.RelativeOrAbsolute)));
                    avatarContent = ell;
                    transitioningContent.Content = avatarContent;
                    avatarContentControl.Content = transitioningContent;
                    ch = true;
                    transitionerField.SelectedIndex = 1;
                    FocusManager.SetFocusedElement(gridSumary, txtMatKhau);
                }
                if (ch == true && txtMatKhau.Password == pass)
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
            }
            else
                lbThongbao.Content = "Sai tên đăng nhập.";
        }

        internal void EnableBlur()
        {
            var windowHelper = new WindowInteropHelper(this);

            var accent = new AccentPolicy();
            accent.AccentState = AccentState.ACCENT_ENABLE_BLURBEHIND;

            var accentStructSize = Marshal.SizeOf(accent);

            var accentPtr = Marshal.AllocHGlobal(accentStructSize);
            Marshal.StructureToPtr(accent, accentPtr, false);

            var data = new WindowCompositionAttributeData();
            data.Attribute = WindowCompositionAttribute.WCA_ACCENT_POLICY;
            data.SizeOfData = accentStructSize;
            data.Data = accentPtr;

            SetWindowCompositionAttribute(windowHelper.Handle, ref data);

            Marshal.FreeHGlobal(accentPtr);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            FocusManager.SetFocusedElement(gridSumary, txtTaiKhoan);
            if (e.Key == Key.Escape)
                this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            EnableBlur();
        }

        private void txtTaiKhoan_TextChanged(object sender, TextChangedEventArgs e)
        {
            lbThongbao.Content = "";
        }
    }
}
