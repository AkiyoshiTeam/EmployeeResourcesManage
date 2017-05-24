using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
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
using Excel = Microsoft.Office.Interop.Excel;

namespace Employee_Resources_Manage
{
    /// <summary>
    /// Interaction logic for DownloadSheet.xaml
    /// </summary>
    public partial class DownloadSheet : UserControl
    {
        public DownloadSheet()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fopen = new OpenFileDialog();
            fopen.Filter = "Tất cả các tệp|*.*|Excel|*.xlsx";
            fopen.ShowDialog();
            if (fopen.FileName != "")
            {
                tbAlert.Text = "Đang tải dữ liệu chấm công...";
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
                    dtTableTemp.Columns.Add("MaNV");
                    dtTableTemp.Columns.Add("NgayCong");
                    for (int i = 10; i <= rows; i++)
                    {
                        DataRow dtRow = dtTableTemp.NewRow();
                        if (string.IsNullOrEmpty(range.Cells[i, 117].Text.ToString()))
                        {
                            break;
                        }
                        else
                        {
                            dtRow[0] = range.Cells[i, 117].Value;
                            dtRow[1] = range.Cells[i, 131].Value;
                        }
                        dtTableTemp.Rows.Add(dtRow);
                    }
                    DTO.ChamCongDTO chamCong = new DTO.ChamCongDTO();

                    string maccLast = BUS.ChamCongBUS.GetLastChamCong().Rows[0][0].ToString();
                    chamCong.MaChamCong = NextID(maccLast, "CC");
                    chamCong.Thang = Convert.ToInt16(range.Cells[2, 3].Text.ToString());
                    chamCong.Nam = Convert.ToInt16(range.Cells[2, 4].Text.ToString());
                    chamCong.NgayPhatLuong = Convert.ToDateTime("5/"+chamCong.Thang.ToString()+"/"+chamCong.Nam.ToString());
                    BUS.ChamCongBUS.AddChamCong(chamCong);
                    BUS.ChiTietChamCongBUS.AddCTCC(dtTableTemp, chamCong.MaChamCong);
                    tbAlert.Text = "Tải dữ liệu chấm công hoàn thành!";
                    //Task.Factory.StartNew(() =>
                    //{
                    //    Thread.Sleep(1500);
                    //}).ContinueWith(t =>
                    //{

                    //}, TaskScheduler.FromCurrentSynchronizationContext());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    wb = null; app.Quit();
                }
            }
        }

        public string NextID(string lastID, string prefixID)
        {
            if (lastID == "")
            {
                return prefixID + "001";  // fixwidth default
            }
            int nextID = int.Parse(lastID.Remove(0, prefixID.Length)) + 1;
            int lengthNumerID = lastID.Trim().Length - prefixID.Length;
            string zeroNumber = "";
            for (int i = 1; i <= lengthNumerID; i++)
            {
                if (nextID < Math.Pow(10, i))
                {
                    for (int j = 1; j <= lengthNumerID - i; i++)
                    {
                        zeroNumber += "0";
                    }
                    return prefixID + zeroNumber + nextID.ToString();
                }
            }
            return prefixID + nextID;
        }

    }
}
