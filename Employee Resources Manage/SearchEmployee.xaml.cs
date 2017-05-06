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
using System.Collections;
using DAO;
using DTO;
using BUS;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Win32;
using System.Reflection;
using MaterialDesignThemes.Wpf;
using Dragablz;
using Dragablz.Dockablz;

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

    public class ComboData
    {
        public string Name { get; set; }
        public int Value { get; set; }
    }

    public partial class SearchEmployee : UserControl
    {
        public TreesSearchModel TreeSearchViewModel;
        public ListsAndGridsViewModel GridModel = new ListsAndGridsViewModel();
        public DataTable Table;
        public DataTable TableFilter;
        //public DataTable TableDes;
        public DataSet TableObjectSearch;
        bool searchOrImp;
        public SearchEmployee()
        {
            InitializeComponent();
            TableObjectSearch = BUS.DescriptionForTreeBUS.GetDescriptionForTree();
            TreeSearchViewModel = new TreesSearchModel(TableObjectSearch);
            treeView.DataContext = TreeSearchViewModel;
            //List<ComboData> cbData = new List<ComboData>();
            //cbData.Add(new ComboData { Name = "Nhân viên", Value = 0 });
            //cbData.Add(new ComboData { Name = "Bộ phận, phòng ban", Value = 1 });
            //cbSearch.ItemsSource = cbData;
            //cbSearch.DisplayMemberPath = "Name";
            //cbSearch.SelectedValuePath = "Value";
            //cbSearch.SelectedValue = "0";
            //cbSearch.DataContext = new ComboboxCustomItem();
            //checkboxSlAll.DataContext = GridModel;
        }


        private void txtFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                FilterDataGrid();
            }
        }

        private void txtFilterInt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsNumeric(e.Text);
        }

        private void FilterDataGrid()
        {
            try
            {
                DataView dtView = new DataView(Table);
                string strFilter = "";
                bool exists = false;
                for (int i = 0; i < Table.Columns.Count; i++)
                {
                    TextBox tbFilter = (TextBox)stFilter.FindName("txtFilter" + Table.Columns[i].ColumnName);

                    if (tbFilter.Text != "" && tbFilter.Text != null)
                    {
                        if (exists != false)
                        {
                            if (Table.Columns[i].DataType.Name.ToString() == "DateTime")
                            {
                                string str = tbFilter.Text;
                                Regex regex = new Regex(@"([\>\<\=]+)(((((0[13578])|([13578])|(1[02]))[\/](([1-9])|([0-2][0-9])|(3[01])))|(((0[469])|([469])|(11))[\/](([1-9])|([0-2][0-9])|(30)))|((2|02)[\/](([1-9])|([0-2][0-9]))))[\/]\d{4}$|^\d{4})");
                                Match result = regex.Match(str);
                                string operatorStr = result.Groups[1].Value;
                                string dateStr = result.Groups[2].Value;
                                regex = new Regex(@"((((0[13578])|([13578])|(1[02]))[\/](([1-9])|([0-2][0-9])|(3[01])))|(((0[469])|([469])|(11))[\/](([1-9])|([0-2][0-9])|(30)))|((2|02)[\/](([1-9])|([0-2][0-9]))))[\/]\d{4}$|^\d{4}");
                                result = regex.Match(str);
                                string dateStrOnly = result.Groups[0].Value;
                                regex = new Regex(@"(.+)(\&+)(.+)");
                                result = regex.Match(str);
                                regex = new Regex(@"([\>\<\=\&]+)(((((0[13578])|([13578])|(1[02]))[\/](([1-9])|([0-2][0-9])|(3[01])))|(((0[469])|([469])|(11))[\/](([1-9])|([0-2][0-9])|(30)))|((2|02)[\/](([1-9])|([0-2][0-9]))))[\/]\d{4}$|^\d{4})");
                                Match resultFrom = regex.Match(result.Groups[1].Value);
                                Match resultTo = regex.Match(result.Groups[3].Value);
                                string operatorFrom = resultFrom.Groups[1].Value;
                                string dateFrom = resultFrom.Groups[2].Value;
                                string operatorTo = resultTo.Groups[1].Value;
                                string dateTo = resultTo.Groups[2].Value;

                                if (operatorFrom != "" && operatorTo != "" && dateFrom != "" && dateTo != "")
                                {
                                    strFilter += " and " + Table.Columns[i].ColumnName + operatorFrom + " #" + dateFrom + "# and " + Table.Columns[i].ColumnName + operatorTo + " #" + dateTo + "# ";
                                }
                                else if (operatorStr != "" && operatorStr != null && dateStr != "" && dateStr != null)
                                    strFilter += " and " + Table.Columns[i].ColumnName + operatorStr + " #" + dateStr + "#";
                                else strFilter += " and " + Table.Columns[i].ColumnName + " = #" + dateStrOnly + "#";

                            }
                            else if (Table.Columns[i].DataType.Name.ToString() == "Int16" || Table.Columns[i].DataType.Name.ToString() == "Int32" || Table.Columns[i].DataType.Name.ToString() == "Int64"
                          || Table.Columns[i].DataType.Name.ToString() == "UInt16" || Table.Columns[i].DataType.Name.ToString() == "UInt32" || Table.Columns[i].DataType.Name.ToString() == "UInt64")
                            {
                                string str = tbFilter.Text;
                                Regex regex = new Regex(@"([\>\<\=]+)(\d+)");
                                Match result = regex.Match(str);
                                string operatorStr = result.Groups[1].Value;
                                string numStr = result.Groups[2].Value;
                                regex = new Regex(@"\d+");
                                result = regex.Match(str);
                                string numStrOnly = result.Groups[0].Value;
                                regex = new Regex(@"(.+)(\&+)(.+)");
                                result = regex.Match(str);
                                regex = new Regex(@"([\>\<\=]+)(\d+)");
                                Match resultFrom = regex.Match(result.Groups[1].Value);
                                Match resultTo = regex.Match(result.Groups[3].Value);
                                string operatorFrom = resultFrom.Groups[1].Value;
                                string numFrom = resultFrom.Groups[2].Value;
                                string operatorTo = resultTo.Groups[1].Value;
                                string numTo = resultTo.Groups[2].Value;
                                if (operatorFrom != "" && operatorTo != "" && numFrom != "" && numTo != "")
                                {
                                    strFilter += " and " + Table.Columns[i].ColumnName + operatorFrom + numFrom + " and " + Table.Columns[i].ColumnName + operatorTo + numTo + " ";
                                }
                                else if (operatorStr != "" && operatorStr != null && numStr != "" && numStr != null)
                                    strFilter += " and " + Table.Columns[i].ColumnName + operatorStr + numStr;
                                else strFilter += " and " + Table.Columns[i].ColumnName + " = " + numStrOnly + " ";
                            }
                            else
                            {
                                strFilter += " and " + Table.Columns[i].ColumnName + " LIKE '%" + tbFilter.Text + "%'";
                            }
                        }
                        else
                        {
                            if (Table.Columns[i].DataType.Name.ToString() == "DateTime")
                            {
                                string str = tbFilter.Text;
                                Regex regex = new Regex(@"([\>\<\=\&]+)(((((0[13578])|([13578])|(1[02]))[\/](([1-9])|([0-2][0-9])|(3[01])))|(((0[469])|([469])|(11))[\/](([1-9])|([0-2][0-9])|(30)))|((2|02)[\/](([1-9])|([0-2][0-9]))))[\/]\d{4}$|^\d{4})");
                                Match result = regex.Match(str);
                                string operatorStr = result.Groups[1].Value;
                                string dateStr = result.Groups[2].Value;
                                regex = new Regex(@"((((0[13578])|([13578])|(1[02]))[\/](([1-9])|([0-2][0-9])|(3[01])))|(((0[469])|([469])|(11))[\/](([1-9])|([0-2][0-9])|(30)))|((2|02)[\/](([1-9])|([0-2][0-9]))))[\/]\d{4}$|^\d{4}");
                                result = regex.Match(str);
                                string dateStrOnly = result.Groups[0].Value;
                                regex = new Regex(@"(.+)(\&+)(.+)");
                                result = regex.Match(str);
                                regex = new Regex(@"([\>\<\=\&]+)(((((0[13578])|([13578])|(1[02]))[\/](([1-9])|([0-2][0-9])|(3[01])))|(((0[469])|([469])|(11))[\/](([1-9])|([0-2][0-9])|(30)))|((2|02)[\/](([1-9])|([0-2][0-9]))))[\/]\d{4}$|^\d{4})");
                                Match resultFrom = regex.Match(result.Groups[1].Value);
                                Match resultTo = regex.Match(result.Groups[3].Value);
                                string operatorFrom = resultFrom.Groups[1].Value;
                                string dateFrom = resultFrom.Groups[2].Value;
                                string operatorTo = resultTo.Groups[1].Value;
                                string dateTo = resultTo.Groups[2].Value;
                                if (operatorFrom != "" && operatorTo != "" && dateFrom != "" && dateTo != "")
                                {
                                    strFilter += Table.Columns[i].ColumnName + operatorFrom + " #" + dateFrom + "# and " + Table.Columns[i].ColumnName + operatorTo + " #" + dateTo + "# ";
                                }
                                else if (operatorStr != "" && operatorStr != null && dateStr != "" && dateStr != null)
                                    strFilter += Table.Columns[i].ColumnName + operatorStr + " #" + dateStr + "#";
                                else strFilter += Table.Columns[i].ColumnName + " = #" + dateStrOnly + "#";
                                exists = true;

                            }
                            else if (Table.Columns[i].DataType.Name.ToString() == "Int16" || Table.Columns[i].DataType.Name.ToString() == "Int32" || Table.Columns[i].DataType.Name.ToString() == "Int64"
                           || Table.Columns[i].DataType.Name.ToString() == "UInt16" || Table.Columns[i].DataType.Name.ToString() == "UInt32" || Table.Columns[i].DataType.Name.ToString() == "UInt64")
                            {
                                string str = tbFilter.Text;
                                Regex regex = new Regex(@"([\>\<\=]+)(\d+)");
                                Match result = regex.Match(str);
                                string operatorStr = result.Groups[1].Value;
                                string numStr = result.Groups[2].Value;
                                regex = new Regex(@"\d+");
                                result = regex.Match(str);
                                string numStrOnly = result.Groups[0].Value;
                                regex = new Regex(@"(.+)(\&+)(.+)");
                                result = regex.Match(str);
                                regex = new Regex(@"([\>\<\=]+)(\d+)");
                                Match resultFrom = regex.Match(result.Groups[1].Value);
                                Match resultTo = regex.Match(result.Groups[3].Value);
                                string operatorFrom = resultFrom.Groups[1].Value;
                                string numFrom = resultFrom.Groups[2].Value;
                                string operatorTo = resultTo.Groups[1].Value;
                                string numTo = resultTo.Groups[2].Value;
                                if (operatorFrom != "" && operatorTo != "" && numFrom != "" && numTo != "")
                                {
                                    strFilter += Table.Columns[i].ColumnName + operatorFrom + numFrom + " and " + Table.Columns[i].ColumnName + operatorTo + numTo + " ";
                                }
                                else if (operatorStr != "" && operatorStr != null && numStr != "" && numStr != null)
                                    strFilter += Table.Columns[i].ColumnName + operatorStr + numStr;
                                else strFilter += Table.Columns[i].ColumnName + " = " + numStrOnly + " ";
                                exists = true;

                            }
                            else
                            {
                                strFilter += Table.Columns[i].ColumnName + " LIKE '%" + tbFilter.Text + "%'";
                            }
                            exists = true;
                        }
                    }
                }
                dtView.RowFilter = strFilter;
                TableFilter = dtView.ToTable();
                //MainWindow.selectedTableStatic = TableFilter;
                dataGridCustom.DataContext = TableFilter;
                //MainWindow.selectedTableDesStatic = TableDes;

                //MainWindow.selectedTableStatic.Rows.Clear();
                //foreach (DataRow row in dtView.ToTable().Rows)
                //{ MainWindow.selectedTableStatic.ImportRow(row); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                MessageBox.Show(ex.Message);
            }
        }

        private static bool IsNumeric(string text)
        {
            Regex regex = new Regex(@"[\d\<\>\=\&]");
            return regex.IsMatch(text);
        }

        private void btnExportExcel_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog fsave = new SaveFileDialog();
            fsave.Filter = "Tất cả các tệp|*.*|Excel|*.xlsx";
            fsave.ShowDialog();
            if (fsave.FileName != "" && Table != null)
            {
                Excel.Application app = new Excel.Application();
                Excel.Workbook wb = app.Workbooks.Add(Type.Missing);
                Excel.Worksheet sheet = null;

                try
                {
                    sheet = wb.ActiveSheet;
                    sheet.Name = "Danh sách nhân viên";
                    sheet.Range[sheet.Cells[1, 1], sheet.Cells[1, TableFilter.Columns.Count]].Merge();
                    sheet.Cells[1, 1].Value = "Danh sách Nhân viên đã tìm kiếm";
                    sheet.Cells[1, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    sheet.Cells[1, 1].Font.Size = 14;
                    sheet.Cells[1, 1].Borders.Weight = Excel.XlBorderWeight.xlThin;


                    for (int i = 1; i <= TableFilter.Columns.Count; i++)
                    {
                        sheet.Cells[2, i] = Table.Columns[i - 1].ColumnName;
                        sheet.Cells[2, i].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        sheet.Cells[2, i].Font.Bold = true;
                        sheet.Cells[2, i].Borders.Weight = Excel.XlBorderWeight.xlThin;
                    }

                    for (int i = 0; i < TableFilter.Columns.Count; i++)
                    {
                        for (int j = 0; j < TableFilter.Rows.Count; j++)
                        {
                            try { sheet.Cells[j + 3, i + 1] = TableFilter.Rows[j].ItemArray[i]; }
                            catch (Exception ex) { MessageBox.Show(ex.Message); }
                        }
                    }
                    wb.SaveAs(fsave.FileName);
                    MessageBox.Show("Lưu file Excel thành công");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo", MessageBoxButton.OK);
                }
                finally
                {
                    wb = null;
                    app.Quit();

                }
            }
        }

        private void btnImportExcel_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fopen = new OpenFileDialog();
            fopen.Filter = "Tất cả các tệp|*.*|Excel|*.xlsx";
            fopen.ShowDialog();
            if (fopen.FileName != "")
            {

                Excel.Application app = new Excel.Application();
                Excel.Workbook wb = app.Workbooks.Open(fopen.FileName);
                Excel.Worksheet sheet = null;

                try
                {
                    sheet = wb.Sheets[1];
                    Excel.Range range = sheet.UsedRange;
                    int rows = range.Rows.Count;
                    int cols = range.Columns.Count;
                    DataTable dtTableTemp = new DataTable();
                    for (int i = 1; i <= cols; i++)
                    {
                        string colName = range.Cells[2, i].Value.ToString();
                        dtTableTemp.Columns.Add(colName);
                    }
                    for (int i = 3; i <= rows; i++)
                    {
                        DataRow dtRow = dtTableTemp.NewRow();
                        bool rowExists = true;
                        for (int j = 1; j <= cols; j++)
                        {
                            if (string.IsNullOrEmpty(range.Cells[i, 1].Text.ToString()))
                            {
                                rowExists = false;
                                break;
                            }
                            else
                            {
                                //if (range.Cells[i, j].Value != null)
                                dtRow[j - 1] = range.Cells[i, j].Value;
                                //else
                                //    dtRow[j - 1] = "";

                            }
                        }
                        if (rowExists == true)
                            dtTableTemp.Rows.Add(dtRow);
                    }
                    TableFilter = dtTableTemp;
                    Table = TableFilter;
                    dataGridCustom.Columns.Clear();
                    dataGridCustom.AutoGenerateColumns = true;
                    dataGridCustom.DataContext = TableFilter.DefaultView;
                    searchOrImp = false;
                    CreateTextBoxFilter();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    wb = null;
                    app.Quit();
                }
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            //TableDes = NhanVienBUS.GetDescriptionSelected(TreeSearchViewModel);
            Table = NhanVienBUS.GetNhanVien(TreeSearchViewModel);
            TableFilter = Table;
            if (Table != null)
            {
                dataGridCustom.AutoGenerateColumns = false;
                searchOrImp = true;
                //MainWindow.selectedTableStatic = Table;
                dataGridCustom.DataContext = TableFilter;
                CreateTextBoxFilter();
                CreateColumnDG();
                //MainWindow.selectedTableStatic = Table;
                //MainWindow.selectedTableDesStatic = TableDes;
            }
            else
            {
                DialogHost da = (DialogHost)((DockPanel)((ColorZone)((Grid)((Layout)((TabablzControl)((TabItem)this.Parent).Parent).Parent).Parent).Parent).Parent).Parent;
                da.DataContext = "Chưa chọn trường dữ liệu cần tìm!";
                da.IsOpen = true;
            }

        }

        private void CreateTextBoxFilter()
        {
            for (int i = 0; i < stFilter.Children.Count; i++)
            {
                FrameworkElement children = (FrameworkElement)stFilter.Children[i];
                stFilter.UnregisterName(children.Name);
            }
            stFilter.Children.Clear();
            int x = 0;

            if (searchOrImp == false)
            {
                for (int i = 0; i < Table.Columns.Count; i++)
                {
                    TextBox tbFilter = new TextBox();
                    tbFilter.Name = "txtFilter" + Table.Columns[i].ColumnName;
                    tbFilter.Style = (Style)FindResource("MaterialDesignFloatingHintTextBox");
                    tbFilter.SetResourceReference(ForegroundProperty, "MaterialDesignBody");
                    if (i < Table.Columns.Count - 1)
                        tbFilter.BorderThickness = new Thickness(1, 0, 0, 1);
                    else tbFilter.BorderThickness = new Thickness(1, 0, 1, 1);
                    HintAssist.SetHint(tbFilter, Table.Columns[i].ColumnName);
                    Binding bnd = new Binding("Columns[" + i.ToString() + "].ActualWidth") { ElementName = "dataGridCustom" };
                    BindingOperations.SetBinding(tbFilter, TextBox.WidthProperty, bnd);
                    tbFilter.Padding = new Thickness(3, 0, 0, 0);
                    TextBlock tooltipText = new TextBlock();
                    tbFilter.KeyDown += txtFilter_KeyDown;

                    if (Table.Columns[i].DataType.Name.ToString() == "Int16" || Table.Columns[i].DataType.Name.ToString() == "Int32" || Table.Columns[i].DataType.Name.ToString() == "Int64"
                        || Table.Columns[i].DataType.Name.ToString() == "UInt16" || Table.Columns[i].DataType.Name.ToString() == "UInt32" || Table.Columns[i].DataType.Name.ToString() == "UInt64")
                    {
                        tooltipText.Text = String.Format("So sánh hỗ trợ: = (mặc định), <, >, <=, >=, <>(khác), &.\nVí dụ: >5, <>7(khác 7), >5&<9 (lớn hơn 5 nhỏ hơn 9)...");
                        tbFilter.ToolTip = tooltipText;
                        tbFilter.PreviewTextInput += txtFilterInt_PreviewTextInput;
                    }
                    else if (Table.Columns[i].DataType.Name.ToString() == "DateTime")
                    {
                        tooltipText.Text = String.Format("Định dạng: tháng/ngày/năm\nSo sánh hỗ trợ: = (mặc định), <, >, <=, >=, <>(khác), &.\nVí dụ: >4/23/2016, <>5/17/2016(khác 5/17/2016), \n>=4/23/2016&<=5/17/2016 (từ 4/23/2016 đến 5/17/2016)...");
                        tbFilter.ToolTip = tooltipText;
                        foreach (DataRow row in Table.Columns[i].Table.Rows)
                        {
                            row[Table.Columns[i]] = DateTime.Parse(row[Table.Columns[i]].ToString()).ToString("dd/MM/yyyy");
                        }
                        TableFilter = Table;
                        dataGridCustom.DataContext = TableFilter;
                    }
                    else
                    {
                        tooltipText.Text = String.Format("Ví dụ: NV001, NV, 002");
                        tbFilter.ToolTip = tooltipText;
                    }
                    stFilter.Children.Add(tbFilter);
                    stFilter.RegisterName(tbFilter.Name, tbFilter);
                }
            }
            else
            {
                //int i = Int32.Parse(cbSearch.SelectedValue.ToString());
                int i = 0;
                for (int j = 0; j < TreeSearchViewModel.SearchObjects[i].SearchElements.Count; j++)
                {
                    for (int n = 0; n < TreeSearchViewModel.SearchObjects[i].SearchElements[j].SearchElementDetails.Count; n++)
                    {
                        if (TreeSearchViewModel.SearchObjects[i].SearchElements[j].SearchElementDetails[n].IsCheckedDetail == true || (j == 0 && n == 0) || (j == 0 && n == 1))
                        {
                            if (TreeSearchViewModel.SearchObjects[i].SearchElements[j].SearchElementDetails[n].StrSearch.Trim() != "tt.MaNV")
                            {
                                TextBox tbFilter = new TextBox();
                                tbFilter.Name = "txtFilter" + Table.Columns[x].ColumnName;
                                tbFilter.Style = (Style)FindResource("MaterialDesignFloatingHintTextBox");
                                tbFilter.SetResourceReference(ForegroundProperty, "MaterialDesignBody");
                                if (x < Table.Columns.Count - 1)
                                    tbFilter.BorderThickness = new Thickness(1, 0, 0, 1);
                                else tbFilter.BorderThickness = new Thickness(1, 0, 1, 1);
                                if (searchOrImp == true)
                                    HintAssist.SetHint(tbFilter, TreeSearchViewModel.SearchObjects[i].SearchElements[j].SearchElementDetails[n].Content);
                                Binding bnd = new Binding("Columns[" + x.ToString() + "].ActualWidth") { ElementName = "dataGridCustom" };
                                BindingOperations.SetBinding(tbFilter, TextBox.WidthProperty, bnd);
                                tbFilter.Padding = new Thickness(3, 0, 0, 0);
                                TextBlock tooltipText = new TextBlock();
                                tbFilter.KeyDown += txtFilter_KeyDown;

                                if (Table.Columns[x].DataType.Name.ToString() == "Int16" || Table.Columns[x].DataType.Name.ToString() == "Int32" || Table.Columns[x].DataType.Name.ToString() == "Int64"
                                    || Table.Columns[x].DataType.Name.ToString() == "UInt16" || Table.Columns[x].DataType.Name.ToString() == "UInt32" || Table.Columns[x].DataType.Name.ToString() == "UInt64")
                                {
                                    tooltipText.Text = String.Format("So sánh hỗ trợ: = (mặc định), <, >, <=, >=, <>(khác), &.\nVí dụ: >5, <>7(khác 7), >5&<9 (lớn hơn 5 nhỏ hơn 9)...");
                                    tbFilter.ToolTip = tooltipText;
                                    tbFilter.PreviewTextInput += txtFilterInt_PreviewTextInput;
                                }
                                else if (Table.Columns[x].DataType.Name.ToString() == "DateTime")
                                {
                                    tooltipText.Text = String.Format("Định dạng: tháng/ngày/năm\nSo sánh hỗ trợ: = (mặc định), <, >, <=, >=, <>(khác), &.\nVí dụ: >4/23/2016, <>5/17/2016(khác 5/17/2016), \n>=4/23/2016&<=5/17/2016 (từ 4/23/2016 đến 5/17/2016)...");
                                    tbFilter.ToolTip = tooltipText;
                                    foreach (DataRow row in Table.Columns[x].Table.Rows)
                                    {
                                        row[Table.Columns[x]] = DateTime.Parse(row[Table.Columns[x]].ToString()).ToString("dd/MM/yyyy");
                                    }
                                    TableFilter = Table;
                                    dataGridCustom.DataContext = TableFilter;
                                }
                                else
                                {
                                    tooltipText.Text = String.Format("Ví dụ: NV001, NV, 002");
                                    tbFilter.ToolTip = tooltipText;
                                }
                                stFilter.Children.Add(tbFilter);
                                stFilter.RegisterName(tbFilter.Name, tbFilter);
                            }
                            else x--;
                            x++;

                        }
                    }
                }
            }
            //for (int i = 0; i < Table.Columns.Count; i++)
            //{
            //    TextBox tbFilter = new TextBox();
            //    tbFilter.Name = "txtFilter" + Table.Columns[i].ColumnName;
            //    tbFilter.Style = (Style)FindResource("MaterialDesignFloatingHintTextBox");
            //    tbFilter.SetResourceReference(ForegroundProperty, "MaterialDesignBody");
            //    if (i < Table.Columns.Count - 1)
            //        tbFilter.BorderThickness = new Thickness(1, 0, 0, 1);
            //    else tbFilter.BorderThickness = new Thickness(1, 0, 1, 1);
            //    if (searchOrImp == true)
            //    {

            //        TreeSearchViewModel.SearchObjects[0]
            //        HintAssist.SetHint(tbFilter, TableDes.Rows[i][2].ToString());
            //    }
            //    else HintAssist.SetHint(tbFilter, Table.Columns[i].ColumnName); ;
            //    Binding bnd = new Binding("Columns[" + i.ToString() + "].ActualWidth") { ElementName = "dataGridCustom" };
            //    BindingOperations.SetBinding(tbFilter, TextBox.WidthProperty, bnd);
            //    tbFilter.Padding = new Thickness(3, 0, 0, 0);
            //    TextBlock tooltipText = new TextBlock();
            //    tbFilter.KeyDown += txtFilter_KeyDown;

            //    if (Table.Columns[i].DataType.Name.ToString() == "Int16" || Table.Columns[i].DataType.Name.ToString() == "Int32" || Table.Columns[i].DataType.Name.ToString() == "Int64"
            //        || Table.Columns[i].DataType.Name.ToString() == "UInt16" || Table.Columns[i].DataType.Name.ToString() == "UInt32" || Table.Columns[i].DataType.Name.ToString() == "UInt64")
            //    {
            //        tooltipText.Text = String.Format("So sánh hỗ trợ: = (mặc định), <, >, <=, >=, <>(khác), &.\nVí dụ: >5, <>7(khác 7), >5&<9 (lớn hơn 5 nhỏ hơn 9)...");
            //        tbFilter.ToolTip = tooltipText;
            //        tbFilter.PreviewTextInput += txtFilterInt_PreviewTextInput;
            //    }
            //    else if (Table.Columns[i].DataType.Name.ToString() == "DateTime")
            //    {
            //        tooltipText.Text = String.Format("Định dạng: tháng/ngày/năm\nSo sánh hỗ trợ: = (mặc định), <, >, <=, >=, <>(khác), &.\nVí dụ: >4/23/2016, <>5/17/2016(khác 5/17/2016), \n>=4/23/2016&<=5/17/2016 (từ 4/23/2016 đến 5/17/2016)...");
            //        tbFilter.ToolTip = tooltipText;
            //        foreach (DataRow row in Table.Columns[i].Table.Rows)
            //        {
            //            row[Table.Columns[i]] = DateTime.Parse(row[Table.Columns[i]].ToString()).ToString("dd/MM/yyyy");
            //        }
            //        TableFilter = Table;
            //        dataGridCustom.DataContext = TableFilter;
            //    }
            //    else
            //    {
            //        tooltipText.Text = String.Format("Ví dụ: NV001, NV, 002");
            //        tbFilter.ToolTip = tooltipText;
            //    }
            //    stFilter.Children.Add(tbFilter);
            //    stFilter.RegisterName(tbFilter.Name, tbFilter);
            //}
        }

        private void CreateColumnDG()
        {
            dataGridCustom.Columns.Clear();
            int x = 0;
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < TreeSearchViewModel.SearchObjects[i].SearchElements.Count; j++)
                {
                    for (int n = 0; n < TreeSearchViewModel.SearchObjects[i].SearchElements[j].SearchElementDetails.Count; n++)
                    {
                        if (TreeSearchViewModel.SearchObjects[i].SearchElements[j].SearchElementDetails[n].IsCheckedDetail == true || (j == 0 && n == 0) || (j == 0 && n == 1))
                        {
                            if (TreeSearchViewModel.SearchObjects[i].SearchElements[j].SearchElementDetails[n].StrSearch.Trim() != "tt.MaNV")
                            {
                                MaterialDataGridTextColumn col = new MaterialDataGridTextColumn();
                                col.Header = TreeSearchViewModel.SearchObjects[i].SearchElements[j].SearchElementDetails[n].Content;
                                col.EditingElementStyle = (Style)FindResource("MaterialDesignDataGridTextColumnPopupEditingStyle");
                                col.Binding = new Binding(Table.Columns[x].ColumnName);
                                dataGridCustom.Columns.Add(col);
                            }
                            else x--;
                            x++;
                        }
                    }
                }
            }

            //for (int i = 0; i < Table.Columns.Count; i++)
            //{
            //    MaterialDataGridTextColumn col = new MaterialDataGridTextColumn();
            //    col.Header = TableDes.Rows[i][2].ToString();
            //    col.EditingElementStyle = (Style)FindResource("MaterialDesignDataGridTextColumnPopupEditingStyle");
            //    col.Binding = new Binding(Table.Columns[i].ColumnName);
            //    dataGridCustom.Columns.Add(col);
            //}

        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            if (TableFilter != null)
            {
                if (MainWindow.selectedTableStatic == null)
                {
                    MainWindow.selectedTableStatic = new DataTable();
                    MainWindow.selectedTableStatic.Columns.Add("MaNV");
                    MainWindow.selectedTableStatic.Columns.Add("HoTen");
                }
                if ((sender as Button).Content.ToString() == "Select New")
                {
                    if (MainWindow.selectedTableStatic.Rows.Count==0)
                    {
                        foreach (DataRow row in TableFilter.Rows)
                        {
                            DataRow destRow = MainWindow.selectedTableStatic.NewRow();
                            destRow["MaNV"] = row["MaNV"];
                            destRow["HoTen"] = row["HoTen"];
                            MainWindow.selectedTableStatic.Rows.Add(destRow);
                        }
                    }
                    else
                    {
                        dialogHost.DataContext = "Bạn có chắc muốn tạo mới bảng chọn nhân viên?";
                        dialogHost.IsOpen = true;
                    }
                }
                if ((sender as Button).Content.ToString() == "Select Import")
                {
                    foreach (DataRow row in TableFilter.Rows)
                    {
                        bool contains = MainWindow.selectedTableStatic.AsEnumerable().Any(rowcon => row["MaNV"].ToString() == rowcon.Field<String>("MaNV"));
                        if (contains == false)
                        {
                            MainWindow.selectedTableStatic.ImportRow(row);
                        }
                    }
                }
            }
        }

        private void dialogHost_DialogClosing(object sender, DialogClosingEventArgs eventArgs)
        {
            if ((bool)eventArgs.Parameter == true)
            {
                MainWindow.selectedTableStatic.Rows.Clear();
                foreach (DataRow row in TableFilter.Rows)
                {
                    DataRow destRow = MainWindow.selectedTableStatic.NewRow();
                    destRow["MaNV"] = row["MaNV"];
                    destRow["HoTen"] = row["HoTen"];
                    MainWindow.selectedTableStatic.Rows.Add(destRow);
                }
            }
        }
    }

}
