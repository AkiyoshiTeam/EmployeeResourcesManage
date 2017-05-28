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
    /// Interaction logic for PaletteSelector.xaml
    /// </summary>
    public partial class PaletteSelector : UserControl
    {
        ContentControl contentControl;
        public PaletteSelector(ContentControl ct)
        {
            InitializeComponent();
            PaletteSelectorViewModel palDataContext = new PaletteSelectorViewModel();
            DataContext = palDataContext;
            //togDarkMode.DataContext = palDataContext;
            togStyleMode.IsChecked = true;
            togDarkMode.IsChecked = false;
            contentControl = ct;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = null;
        }
    }
}
