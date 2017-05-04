using Dragablz;
using Dragablz.Dockablz;
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
    /// Interaction logic for SelectorEmployee.xaml
    /// </summary>
    public partial class SelectorEmployee : UserControl
    {
        DataTable Table;
        DataTable TableDes;
        public SelectorEmployee()
        {
            InitializeComponent();

        }

        private void CreateColumnDG()
        {
            dataGridCustom.Columns.Clear();
            for (int i = 0; i < Table.Columns.Count; i++)
            {
                MaterialDataGridTextColumn col = new MaterialDataGridTextColumn();
                col.Header = TableDes.Rows[i][2].ToString();
                col.EditingElementStyle = (Style)FindResource("MaterialDesignDataGridTextColumnPopupEditingStyle");
                col.Binding = new Binding(Table.Columns[i].ColumnName);
                dataGridCustom.Columns.Add(col);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (MainWindow.selectedTableStatic != null)
            {
                Table = MainWindow.selectedTableStatic;
                dataGridCustom.DataContext = MainWindow.selectedTableStatic;
                TableDes = MainWindow.selectedTableDesStatic;
                CreateColumnDG();
            }
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.selectedTableStatic != null)
            {
                Table = MainWindow.selectedTableStatic;
                dataGridCustom.DataContext = MainWindow.selectedTableStatic;
                TableDes = MainWindow.selectedTableDesStatic;
                CreateColumnDG();
            }
        }
    }
}
