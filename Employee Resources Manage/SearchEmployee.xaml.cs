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
        public DataTable Table;
        public DataTable TableFilter;
        public SearchEmployee()
        {
            InitializeComponent();
            Model = NhanVienBUS.GetNhanVien();
            treeView.DataContext = ViewModel;
            Table = NhanVienBUS.GetTableNhanVien();
            TableFilter = Table;
            dataGridCustom.DataContext = TableFilter.DefaultView;
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
                DataView dtView = new DataView(Table);
                dtView.RowFilter = "MaNV LIKE '%"+txtFilterID.Text +"%'";
                TableFilter = dtView.ToTable();
                dataGridCustom.DataContext = TableFilter.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                MessageBox.Show(ex.Message);
            }
        }

        //private bool ComplexFilter(object obj)
        //{
        //    String str = txtFilterNum.Text;
        //    Regex regex = new Regex(@"([\>\<\=]+)(\d+)");
        //    Match result = regex.Match(str);
        //    String operatorStr = result.Groups[1].Value;
        //    String numericStr = result.Groups[2].Value;
        //    if (((SelectableViewModel)obj).Name.ToUpper().Contains(txtFilterName.Text.ToUpper()) && operatorStr.Operator((int)((SelectableViewModel)obj).Numeric, (int)Int32.Parse(numericStr)))
        //        return true;
        //    return ((DAO.NhanVien)obj).MaNV.ToUpper().Contains(txtFilterID.Text.ToUpper());
        //}

        private static bool IsNumeric(string text)
        {
            Regex regex = new Regex(@"[\d\<\>\=]");
            return regex.IsMatch(text);
        }



        private void btnExportExcel_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog fsave = new SaveFileDialog();
            fsave.Filter = "Tất cả các tệp|*.*|Excel|*.xlsx";
            fsave.ShowDialog();
            if (fsave.FileName != "")
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
                            try{ sheet.Cells[j + 3, i + 1] = TableFilter.Rows[j].ItemArray[i]; }
                            catch (Exception ex){ MessageBox.Show(ex.Message); }
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
                    app.Quit();
                    wb = null;
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
                    for(int i=3;i<=rows; i++)
                    {
                        DataRow dtRow = dtTableTemp.NewRow();
                        for (int j=1; j<=cols;j++)
                        {
                            dtRow[j - 1] = range.Cells[i, j].Value.ToString();
                        }
                        dtTableTemp.Rows.Add(dtRow);
                    }
                    TableFilter = dtTableTemp;
                    Table = TableFilter;
                    dataGridCustom.DataContext = TableFilter.DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    app.Quit();
                    wb = null;
                }
            }
        }
    }

}
