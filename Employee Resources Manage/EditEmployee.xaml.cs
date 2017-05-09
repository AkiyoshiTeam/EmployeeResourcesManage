﻿using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Transitions;
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
        List<QuanHuyen> listQH;
        List<TinhTP> listTTP;
        List<QuocGia> listQG;
        List<TonGiao> listTG;
        List<DanToc> listDT;

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

                tbTemp = BUS.QuanHuyenBUS.GetQuanHuyen();
                listQH = new List<QuanHuyen>();
                foreach (DataRow row in tbTemp.Rows)
                {
                    listQH.Add(new QuanHuyen { ID = row[0].ToString(), Name = row[1].ToString(), MaTinh = row[2].ToString() });
                }

                tbTemp = BUS.TinhTPBUS.GetTinhTP();
                listTTP = new List<TinhTP>();
                foreach (DataRow row in tbTemp.Rows)
                {
                    listTTP.Add(new TinhTP { ID = row[0].ToString(), Name = row[1].ToString(), MaQG = row[2].ToString() });
                }

                tbTemp = BUS.QuocGiaBUS.GetQuocGia();
                listQG = new List<QuocGia>();
                foreach (DataRow row in tbTemp.Rows)
                {
                    listQG.Add(new QuocGia { ID = row[0].ToString(), Name = row[1].ToString() });
                }

                tbTemp = BUS.TonGiaoBUS.GetTonGiao();
                listTG = new List<TonGiao>();
                foreach (DataRow row in tbTemp.Rows)
                {
                    listTG.Add(new TonGiao { ID = row[0].ToString(), Name = row[1].ToString() });
                }

                tbTemp = BUS.DanTocBUS.GetDanToc();
                listDT = new List<DanToc>();
                foreach (DataRow row in tbTemp.Rows)
                {
                    listDT.Add(new DanToc { ID = row[0].ToString(), Name = row[1].ToString() });
                }

                Style style = new Style();
                style.TargetType = typeof(TextBlock);
                Setter setter = new Setter();
                setter.Property = TextBlock.HorizontalAlignmentProperty;
                setter.Value = "Center";
                style.Setters.Add(setter);

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
                            //var textBlockFactory = new FrameworkElementFactory(typeof(TextBlock));
                            //textBlockFactory.SetBinding(TextBlock.TextProperty, new Binding(DataSetEdit.Tables[0].Columns[i].ColumnName.Trim()));
                            //template.VisualTree = textBlockFactory;
                            //c.CellTemplate = template;
                            template = new DataTemplate();
                            var datePicker = new FrameworkElementFactory(typeof(DatePicker));
                            datePicker.SetBinding(DatePicker.SelectedDateProperty, new Binding(DataSetEdit.Tables[0].Columns[i].ColumnName.Trim()));
                            var lang = System.Windows.Markup.XmlLanguage.GetLanguage("vi-VN");
                            datePicker.SetValue(DatePicker.LanguageProperty, lang);
                            datePicker.AddHandler(DatePicker.PreviewKeyDownEvent, new KeyEventHandler(DatePicker_PreviewKeyDown));
                            template.VisualTree = datePicker;
                            c.Header = DataSetEdit.Tables[0].Columns[i].ColumnName.Trim();
                            c.CellTemplate = template;
                            //c.CellEditingTemplate = template;
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
                        case "NgaySinh":
                            var c = new DataGridTemplateColumn();
                            var template = new DataTemplate();
                            //var textBlockFactory = new FrameworkElementFactory(typeof(TextBlock));
                            //textBlockFactory.SetBinding(TextBlock.TextProperty, new Binding(DataSetEdit.Tables[1].Columns[i].ColumnName.Trim()));
                            //template.VisualTree = textBlockFactory;
                            //c.CellTemplate = template;
                            template = new DataTemplate();
                            var datePicker = new FrameworkElementFactory(typeof(DatePicker));
                            datePicker.SetBinding(DatePicker.SelectedDateProperty, new Binding(DataSetEdit.Tables[1].Columns[i].ColumnName.Trim()));
                            var lang = System.Windows.Markup.XmlLanguage.GetLanguage("vi-VN");
                            datePicker.SetValue(DatePicker.LanguageProperty, lang);
                            datePicker.AddHandler(DatePicker.PreviewKeyDownEvent, new KeyEventHandler(DatePicker_PreviewKeyDown));
                            template.VisualTree = datePicker;
                            c.CellTemplate = template;
                            //c.CellEditingTemplate = template;
                            c.Header = DataSetEdit.Tables[1].Columns[i].ColumnName.Trim();
                            dataGridSelectedTTCT.Columns.Add(c);
                            break;
                        case "TinhTP":
                            colcb = new MaterialDataGridComboBoxColumn();
                            colcb.Header = DataSetEdit.Tables[1].Columns[i].ColumnName.Trim();
                            colcb.ItemsSource = listTTP;
                            colcb.DisplayMemberPath = "Name";
                            colcb.SelectedValuePath = "ID";
                            colcb.SelectedValueBinding = new Binding(DataSetEdit.Tables[1].Columns[i].ColumnName.Trim());
                            dataGridSelectedTTCT.Columns.Add(colcb);
                            break;
                        case "QuanHuyen":
                            colcb = new MaterialDataGridComboBoxColumn();
                            colcb.Header = DataSetEdit.Tables[1].Columns[i].ColumnName.Trim();
                            colcb.ItemsSource = listQH;
                            colcb.DisplayMemberPath = "Name";
                            colcb.SelectedValuePath = "ID";
                            colcb.SelectedValueBinding = new Binding(DataSetEdit.Tables[1].Columns[i].ColumnName.Trim());
                            dataGridSelectedTTCT.Columns.Add(colcb);
                            break;
                        case "QuocGia":
                            colcb = new MaterialDataGridComboBoxColumn();
                            colcb.Header = DataSetEdit.Tables[1].Columns[i].ColumnName.Trim();
                            colcb.ItemsSource = listQG;
                            colcb.DisplayMemberPath = "Name";
                            colcb.SelectedValuePath = "ID";
                            colcb.SelectedValueBinding = new Binding(DataSetEdit.Tables[1].Columns[i].ColumnName.Trim());
                            dataGridSelectedTTCT.Columns.Add(colcb);
                            break;
                        case "MaTG":
                            colcb = new MaterialDataGridComboBoxColumn();
                            colcb.Header = DataSetEdit.Tables[1].Columns[i].ColumnName.Trim();
                            colcb.ItemsSource = listTG;
                            colcb.DisplayMemberPath = "Name";
                            colcb.SelectedValuePath = "ID";
                            colcb.SelectedValueBinding = new Binding(DataSetEdit.Tables[1].Columns[i].ColumnName.Trim());
                            dataGridSelectedTTCT.Columns.Add(colcb);
                            break;
                        case "MaDT":
                            colcb = new MaterialDataGridComboBoxColumn();
                            colcb.Header = DataSetEdit.Tables[1].Columns[i].ColumnName.Trim();
                            colcb.ItemsSource = listDT;
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
                if (BUS.NhanVienBUS.UpdateNhanVienByElementForEdit(DataSetEdit.Tables[0], DataSetEdit.Tables[1]))
                    MessageBox.Show("Update complete");
                else MessageBox.Show("Update fail");
            }
        }

        //private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        //{
        //    //ScrollViewer scv = (ScrollViewer)sender;
        //    //scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
        //    //e.Handled = true;
        //    //scrView.ScrollToVerticalOffset(scrView.VerticalOffset - e.Delta);
        //    //e.Handled = true;
        //}

        private void DatePicker_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        string manvSelection = "";

        private void dataGridSelectedNV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridSelectedNV.SelectedItem != null)
            {
                if (manvSelection != (dataGridSelectedNV.SelectedItem as DataRowView).Row[0].ToString())
                {
                    TransitioningContent transitioningContent = new TransitioningContent();
                    TransitionEffect effect = new TransitionEffect();
                    effect.Kind = TransitionEffectKind.ExpandIn;
                    transitioningContent.OpeningEffect = effect;
                    object avatarContent;
                    Image img = new Image();
                    img.Stretch = Stretch.None;
                    img.VerticalAlignment = VerticalAlignment.Center;
                    img.HorizontalAlignment = HorizontalAlignment.Center;
                    BitmapImage bitm = new BitmapImage();
                    bitm.BeginInit();
                    bitm.UriSource = new Uri(@"..\..\Resources\Images\56535968_p0.jpg", UriKind.RelativeOrAbsolute);
                    bitm.EndInit();
                    img.Source = bitm;
                    avatarContent = img;
                    transitioningContent.Content = avatarContent;
                    avatarContentControl.Content = transitioningContent;
                    manvSelection = (dataGridSelectedNV.SelectedItem as DataRowView).Row[0].ToString();
                }
            }
        }
    }
}