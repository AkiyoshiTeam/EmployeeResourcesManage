using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace Employee_Resources_Manage
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>

    public class TextFieldsViewModel : INotifyPropertyChanged
    {
        private string _name;

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

        }

        private void txtDangNhap_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
                DangNhap();
        }


        private void DangNhap()
        {
            if (ch == true && txtMatKhau.Password != "123456")
            {
                ell.Stroke = Brushes.Red;
                ell.StrokeThickness = 1;
            }
            if (ch == false && txtTaiKhoan.Text == "admin")
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
                ell.Fill = new ImageBrush(new BitmapImage(new Uri(@"..\..\Resources\Images\56535968_p0.jpg", UriKind.RelativeOrAbsolute)));
                avatarContent = ell;
                transitioningContent.Content = avatarContent;
                avatarContentControl.Content = transitioningContent;
                ch = true;
                transitionerField.SelectedIndex = 1;
                FocusManager.SetFocusedElement(gridSumary, txtMatKhau);
            }
            if (ch == true && txtMatKhau.Password == "123456")
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
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
    }
}
