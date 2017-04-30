using Employee_Resources_Manage.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
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
using DAO;
using DTO;
using BUS;
using System.Collections;

namespace Employee_Resources_Manage
{
    /// <summary>
    /// Interaction logic for SearchEmployee.xaml
    /// </summary>
    /// 
    public static class Extension
    {
        public static Boolean Operator(this string logic, int x, int y)
        {
            switch (logic)
            {
                case ">": return x > y;
                case ">=": return x >= y;
                case "<=": return x <= y;
                case "<": return x < y;
                case "=": return x == y;
                default: throw new Exception("So sánh không hợp lệ");
            }
        }
    }
    public partial class SearchEmployee : UserControl
    {
        public TreesViewModel ViewModel = new TreesViewModel();
        public ListsAndGridsViewModel GridModel = new ListsAndGridsViewModel();
        public IEnumerable Model;
        public SearchEmployee()
        {
            InitializeComponent();
            Model = NhanVienBUS.GetNhanVien();
            treeView.DataContext = ViewModel;
            dataGridCustom.ItemsSource = Model;
            //checkboxSlAll.DataContext = GridModel;
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (ViewModel == null) return;

            ViewModel.SelectedItem = e.NewValue;

        }

        private void txtFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                FilterDataGrid();
            }
        }

        private void txtFilterNum_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsNumeric(e.Text);
        }

        private void FilterDataGrid()
        {
            try
            {
                var _itemSourceList = new CollectionViewSource() { Source = GridModel.Items1 };
                ICollectionView Itemlist = _itemSourceList.View;
                var yourCostumFilter = new Predicate<object>(ComplexFilter);
                Itemlist.Filter = yourCostumFilter;
                dataGridCustom.ItemsSource = Itemlist;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private bool ComplexFilter(object obj)
        {
            //String str = txtFilterNum.Text;
            //Regex regex = new Regex(@"([\>\<\=]+)(\d+)");
            //Match result = regex.Match(str);
            //String operatorStr = result.Groups[1].Value;
            //String numericStr = result.Groups[2].Value;
            //if (((SelectableViewModel)obj).Name.ToUpper().Contains(txtFilterName.Text.ToUpper()) && operatorStr.Operator((int)((SelectableViewModel)obj).Numeric, (int)Int32.Parse(numericStr)))
            //    return true;
            return false;
        }

        private static bool IsNumeric(string text)
        {
            Regex regex = new Regex(@"[\d\<\>\=]");
            return regex.IsMatch(text);
        }

        
    }

}
