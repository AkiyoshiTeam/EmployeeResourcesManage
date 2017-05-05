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
using DAO;
using BUS;
using System.ComponentModel;
using System.Windows.Controls.Primitives;

namespace Employee_Resources_Manage
{
    /// <summary>
    /// Interaction logic for SelectorEmployee.xaml
    /// </summary>
    public partial class SelectorEmployee : UserControl
    {
        DataTable Table;
        public SelectorEmployee()
        {
            InitializeComponent();
            DataTable tbTemp = BUS.NhanVienBUS.GetNhanVienForChoose();
            dataGridChoose.DataContext = tbTemp;
            for (int i = 0; i < 2; i++)
            {
                MaterialDataGridTextColumn col = new MaterialDataGridTextColumn();
                col.Header = tbTemp.Columns[i].ColumnName;
                col.EditingElementStyle = (Style)FindResource("MaterialDesignDataGridTextColumnPopupEditingStyle");
                col.Binding = new Binding(tbTemp.Columns[i].ColumnName);
                dataGridChoose.Columns.Add(col);
            }
        }

        private void CreateColumnDG()
        {
            dataGridSelected.Columns.Clear();
            for (int i = 0; i < 2; i++)
            {
                MaterialDataGridTextColumn col = new MaterialDataGridTextColumn();
                Style stl = new Style();
                stl.BasedOn = (Style)FindResource("MaterialDesignDataGridColumnHeader");
                stl.TargetType = typeof(DataGridColumnHeader);
                stl.Setters.Add(new Setter(ToolTipService.ToolTipProperty, "Click để sắp xếp!"));
                col.HeaderStyle = stl;
                col.Header = Table.Columns[i].ColumnName;
                col.EditingElementStyle = (Style)FindResource("MaterialDesignDataGridTextColumnPopupEditingStyle");
                col.Binding = new Binding(Table.Columns[i].ColumnName);
                dataGridSelected.Columns.Add(col);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (MainWindow.selectedTableStatic != null)
            {
                Table = MainWindow.selectedTableStatic;
                dataGridSelected.DataContext = MainWindow.selectedTableStatic;
                CreateColumnDG();
            }
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            DataRowView rowSelected = (DataRowView)dataGridChoose.SelectedItems[0];
            bool contains = MainWindow.selectedTableStatic.AsEnumerable().Any(row => rowSelected[0].ToString() == row.Field<String>("MaNV"));
            if(contains==true)
            {
                MessageBox.Show("Đã chứa");
            }
            else
            {
                MainWindow.selectedTableStatic.ImportRow(rowSelected.Row);
                if (dataGridSelected.Items.Count > 0)
                {
                    var border = VisualTreeHelper.GetChild(dataGridSelected, 0) as Decorator;
                    if (border != null)
                    {
                        var scroll = border.Child as ScrollViewer;
                        if (scroll != null) scroll.ScrollToEnd();
                    }
                }
            }

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            while(dataGridSelected.SelectedItem != null)
            {
                MainWindow.selectedTableStatic.Rows.Remove((dataGridSelected.SelectedItem as DataRowView).Row);
            }
        }
    }
}
