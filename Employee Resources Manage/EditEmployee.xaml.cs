using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Interaction logic for EditEmployee.xaml
    /// </summary>

    public partial class EditEmployee : UserControl
    {
        public DataSet DataSetEdit;
        List<PhongBan> listPB;
        List<ChucVu> listCV;
        List<LoaiLuong> listLL;
        List<TinhTrang> listTT;
        List<GioiTinh> listGT;
        public EditEmployee()
        {
            InitializeComponent();
            if (MainWindow.selectedTableStatic.Rows.Count > 0)
            {
                DataSetEdit = BUS.NhanVienBUS.GetNhanVienByElementForEdit(MainWindow.selectedTableStatic);
                DataContext = DataSetEdit;

                DataTable tbTemp = BUS.PhongBanBUS.GetPhongBan();
                listPB = new List<PhongBan>();
                foreach (DataRow row in tbTemp.Rows)
                {
                    listPB.Add(new PhongBan { ID = row[0].ToString(), Name = row[1].ToString(), MaBP = row[2].ToString() });
                }

                tbTemp = BUS.ChucVuBUS.GetChucVu();
                listCV = new List<ChucVu>();
                foreach (DataRow row in tbTemp.Rows)
                {
                    listCV.Add(new ChucVu { ID = row[0].ToString(), Name = row[1].ToString() });
                }

                tbTemp = BUS.LoaiLuongBUS.GetLoaiLuong();
                listLL = new List<LoaiLuong>();
                foreach (DataRow row in tbTemp.Rows)
                {
                    listLL.Add(new LoaiLuong { ID = row[0].ToString(), Name = row[1].ToString() });
                }

                tbTemp = BUS.TinhTrangBUS.GetTinhTrang();
                listTT = new List<TinhTrang>();
                foreach (DataRow row in tbTemp.Rows)
                {
                    listTT.Add(new TinhTrang { ID = row[0].ToString(), Name = row[1].ToString() });
                }

                listGT = new List<GioiTinh>();
                listGT.Add(new GioiTinh { ID = false, Name = "Nữ" });
                listGT.Add(new GioiTinh { ID = true, Name = "Nam" });

                for (int i = 0; i < DataSetEdit.Tables[0].Columns.Count; i++)
                {
                    MaterialDataGridTextColumn col;
                    MaterialDataGridComboBoxColumn colcb;
                    switch (DataSetEdit.Tables[0].Columns[i].ColumnName.Trim())
                    {
                        case "MaNV":
                            col = new MaterialDataGridTextColumn();
                            col.Header = DataSetEdit.Tables[0].Columns[i].ColumnName.Trim();
                            col.EditingElementStyle = (Style)FindResource("MaterialDesignDataGridTextColumnPopupEditingStyle");
                            col.Binding = new Binding(DataSetEdit.Tables[0].Columns[i].ColumnName.Trim());
                            col.IsReadOnly = true;
                            dataGridSelectedNV.Columns.Add(col);
                            break;
                        case "NgayVaoLam":
                            var c = new DataGridTemplateColumn();
                            var template = new DataTemplate();
                            var textBlockFactory = new FrameworkElementFactory(typeof(TextBlock));
                            textBlockFactory.SetBinding(TextBlock.TextProperty, new Binding(DataSetEdit.Tables[0].Columns[i].ColumnName.Trim()));
                            template.VisualTree = textBlockFactory;
                            c.Header = DataSetEdit.Tables[0].Columns[i].ColumnName.Trim();
                            c.CellTemplate = template;
                            template = new DataTemplate();
                            var datePicker = new FrameworkElementFactory(typeof(DatePicker));
                            datePicker.SetBinding(DatePicker.SelectedDateProperty, new Binding(DataSetEdit.Tables[0].Columns[i].ColumnName.Trim()));
                            var lang = System.Windows.Markup.XmlLanguage.GetLanguage("vi-VN");
                            datePicker.SetValue(DatePicker.LanguageProperty, lang);
                            template.VisualTree = datePicker;
                            c.CellEditingTemplate = template;
                            dataGridSelectedNV.Columns.Add(c);
                            break;
                        case "MaPB":
                            colcb = new MaterialDataGridComboBoxColumn();
                            colcb.Header = DataSetEdit.Tables[0].Columns[i].ColumnName.Trim();
                            colcb.ItemsSource = listPB;
                            colcb.DisplayMemberPath = "Name";
                            colcb.SelectedValuePath = "ID";
                            colcb.SelectedValueBinding = new Binding(DataSetEdit.Tables[0].Columns[i].ColumnName.Trim());
                            dataGridSelectedNV.Columns.Add(colcb);
                            break;
                        case "MaCV":
                            colcb = new MaterialDataGridComboBoxColumn();
                            colcb.Header = DataSetEdit.Tables[0].Columns[i].ColumnName.Trim();
                            colcb.ItemsSource = listCV;
                            colcb.DisplayMemberPath = "Name";
                            colcb.SelectedValuePath = "ID";
                            colcb.SelectedValueBinding = new Binding(DataSetEdit.Tables[0].Columns[i].ColumnName.Trim());
                            dataGridSelectedNV.Columns.Add(colcb);
                            break;
                        case "MaLoaiLuong":
                            colcb = new MaterialDataGridComboBoxColumn();
                            colcb.Header = DataSetEdit.Tables[0].Columns[i].ColumnName.Trim();
                            colcb.ItemsSource = listLL;
                            colcb.DisplayMemberPath = "Name";
                            colcb.SelectedValuePath = "ID";
                            colcb.SelectedValueBinding = new Binding(DataSetEdit.Tables[0].Columns[i].ColumnName.Trim());
                            dataGridSelectedNV.Columns.Add(colcb);
                            break;
                        case "MaTT":
                            colcb = new MaterialDataGridComboBoxColumn();
                            colcb.Header = DataSetEdit.Tables[0].Columns[i].ColumnName.Trim();
                            colcb.ItemsSource = listTT;
                            colcb.DisplayMemberPath = "Name";
                            colcb.SelectedValuePath = "ID";
                            colcb.SelectedValueBinding = new Binding(DataSetEdit.Tables[0].Columns[i].ColumnName.Trim());
                            dataGridSelectedNV.Columns.Add(colcb);
                            break;
                        default:
                            col = new MaterialDataGridTextColumn();
                            col.Header = DataSetEdit.Tables[0].Columns[i].ColumnName.Trim();
                            col.EditingElementStyle = (Style)FindResource("MaterialDesignDataGridTextColumnPopupEditingStyle");
                            col.Binding = new Binding(DataSetEdit.Tables[0].Columns[i].ColumnName.Trim());
                            dataGridSelectedNV.Columns.Add(col);
                            break;
                    }
                }
                for (int i = 0; i < DataSetEdit.Tables[1].Columns.Count; i++)
                {
                    MaterialDataGridTextColumn col;
                    MaterialDataGridComboBoxColumn colcb;
                    switch (DataSetEdit.Tables[1].Columns[i].ColumnName.Trim())
                    {
                        case "MaNV":
                            col = new MaterialDataGridTextColumn();
                            col.Header = DataSetEdit.Tables[1].Columns[i].ColumnName.Trim();
                            col.EditingElementStyle = (Style)FindResource("MaterialDesignDataGridTextColumnPopupEditingStyle");
                            col.Binding = new Binding(DataSetEdit.Tables[1].Columns[i].ColumnName.Trim());
                            col.IsReadOnly = true;
                            dataGridSelectedTTCT.Columns.Add(col);
                            break;
                        case "MaGT":
                            colcb = new MaterialDataGridComboBoxColumn();
                            colcb.Header = DataSetEdit.Tables[1].Columns[i].ColumnName.Trim();
                            colcb.ItemsSource = listGT;
                            colcb.DisplayMemberPath = "Name";
                            colcb.SelectedValuePath = "ID";
                            colcb.SelectedValueBinding = new Binding(DataSetEdit.Tables[1].Columns[i].ColumnName.Trim());
                            dataGridSelectedTTCT.Columns.Add(colcb);
                            break;
                        default:
                            col = new MaterialDataGridTextColumn();
                            col.Header = DataSetEdit.Tables[1].Columns[i].ColumnName.Trim();
                            col.EditingElementStyle = (Style)FindResource("MaterialDesignDataGridTextColumnPopupEditingStyle");
                            col.Binding = new Binding(DataSetEdit.Tables[1].Columns[i].ColumnName.Trim());
                            dataGridSelectedTTCT.Columns.Add(col);
                            break;
                    }
                }
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.selectedTableStatic.Rows.Count > 0)
            {
                if (BUS.NhanVienBUS.UpdateNhanVienByElementForEdit(DataSetEdit.Tables[0]))
                    MessageBox.Show("Update complete");
                else MessageBox.Show("Update fail");
            }
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }
    }
}
