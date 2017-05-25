using Microsoft.Win32;
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
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using Novacode;
using System.Data;
using MaterialDesignThemes.Wpf;
using System.Globalization;

namespace Employee_Resources_Manage
{
    /// <summary>
    /// Interaction logic for BaoCao.xaml
    /// </summary>
    public partial class BaoCao : UserControl
    {
        public BaoCao()
        {
            InitializeComponent();

            // vẽ giao diện báo cáo
            DataTable tbPB = BUS.PhongBanBUS.GetPhongBan();
            foreach (DataRow row in tbPB.Rows)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Content = row[1].ToString();
                checkBox.Name = row[0].ToString();
                checkBox.SetResourceReference(ForegroundProperty, "MaterialDesignBody");
                checkBox.Margin = new Thickness(5);
                stkNVbyPB.Children.Add(checkBox);
            }
            DataTable tbBP = BUS.BoPhanBUS.GetBoPhan();
            foreach (DataRow row in tbBP.Rows)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Content = row[1].ToString();
                checkBox.Name = row[0].ToString();
                checkBox.SetResourceReference(ForegroundProperty, "MaterialDesignBody");
                checkBox.Margin = new Thickness(5);
                stkNVByBP.Children.Add(checkBox);
            }
            DataTable tbGT = BUS.GioiTinhBUS.GetGioiTinh();
            foreach (DataRow row in tbGT.Rows)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Content = row[1].ToString();
                checkBox.Name = row[0].ToString();
                checkBox.SetResourceReference(ForegroundProperty, "MaterialDesignBody");
                checkBox.Margin = new Thickness(5);
                stkNVByGT.Children.Add(checkBox);
            }
        }

        /// <summary>
        /// Xuất báo cáo(Excel)
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dtName"></param>
        public void BaoCaoex(DataTable dt, string dtName)
        {
            //SaveFileDialog fsave = new SaveFileDialog();
            //fsave.Filter = "Tất cả các tệp|*.*|Excel|*.xlsx";
            //fsave.ShowDialog();
            //fsave.FileName = "ReportNVPB";

            Excel.Application app = new Excel.Application();
            Excel.Workbook wb = app.Workbooks.Add(Type.Missing);
            Excel.Worksheet sheet = null;
            app.Visible = true;

            try
            {
                sheet = wb.ActiveSheet;
                sheet.Name = "Sheet 1";
                sheet.Range[sheet.Cells[1, 1], sheet.Cells[1, dt.Columns.Count]].Merge();
                sheet.Cells[1, 1].Value = dtName;
                sheet.Cells[1, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                sheet.Cells[1, 1].Font.Size = 14;
                sheet.Cells[1, 1].Borders.Weight = Excel.XlBorderWeight.xlThin;


                for (int i = 1; i <= dt.Columns.Count; i++)
                {
                    sheet.Columns[i].ColumnWidth = 20;
                    sheet.Cells[2, i] = dt.Columns[i - 1].ColumnName;
                    sheet.Cells[2, i].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    sheet.Cells[2, i].Font.Bold = true;
                    sheet.Cells[2, i].Borders.Weight = Excel.XlBorderWeight.xlThin;
                }

                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        try { sheet.Cells[j + 3, i + 1] = dt.Rows[j].ItemArray[i]; }
                        catch (Exception ex) { MessageBox.Show(ex.Message); }
                    }
                }
                //wb.SaveAs(fsave.FileName);
                //MessageBox.Show("Lưu file Excel thành công");
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
        /// <summary>
        /// Danh sách nhân viên công ty
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNVCTY_Click(object sender, RoutedEventArgs e)
        {
            string strWhere = "";
            DataTable tb = BUS.NhanVienBUS.GetNhanVienByWhere(strWhere);
            BaoCaoex(tb, "DANH SÁCH NHÂN VIÊN CÔNG TY");
        }
        /// <summary>
        /// Danh sách nhân viên theo bộ phận
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNVByBP_Click(object sender, RoutedEventArgs e)
        {
            bool isExists = false;
            string strWhere = "";
            foreach (var control in stkNVByBP.Children)
            {
                if (control is CheckBox)
                {
                    if (isExists == false)
                    {
                        if ((control as CheckBox).IsChecked == true)
                        {
                            strWhere += "where bp.MaBP = '" + (control as CheckBox).Name + "'";
                            isExists = true;
                        }
                    }
                    else
                    {
                        if ((control as CheckBox).IsChecked == true)
                        {
                            strWhere += " or bp.MaBP = '" + (control as CheckBox).Name + "'";
                        }
                    }
                }               
            }
            if (isExists)
            {
                DataTable tb = BUS.NhanVienBUS.GetNhanVienByWhere(strWhere);
                BaoCaoex(tb, "DANH SÁCH NHÂN VIÊN THEO BỘ PHẬN");
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn bộ phận !");
            }

        }
        /// <summary>
        /// Danh sách nhân viên theo phòng ban
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void btnDSNVPB_Click(object sender, RoutedEventArgs e)
        {
            bool isExists = false;
            string strWhere = "";
            foreach (var control in stkNVbyPB.Children)
            {
                if (control is CheckBox)
                {
                    if (isExists == false)
                    {
                        if ((control as CheckBox).IsChecked == true)
                        {
                            strWhere += "where pb.MaPB = '" + (control as CheckBox).Name + "'";
                            isExists = true;
                        }
                    }
                    else
                    {
                        if ((control as CheckBox).IsChecked == true)
                        {
                            strWhere += " or pb.MaPB = '" + (control as CheckBox).Name + "'";
                        }
                    }
                }             
            }
            if (isExists)
            {
                DataTable tb = BUS.NhanVienBUS.GetNhanVienByWhere(strWhere);
                BaoCaoex(tb, "DANH SÁCH NHÂN VIÊN THEO PHÒNG BAN");
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn phòng ban !");
            }

        }
        /// <summary>
        /// Danh sách nhân viên theo giới tính
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGioiTinh_Click(object sender, RoutedEventArgs e)
        {
            bool isExists = false;
            string strWhere = "";
            foreach (var control in stkNVByGT.Children)
            {
                if (control is CheckBox)
                {
                    if (isExists == false)
                    {
                        if ((control as CheckBox).IsChecked == true)
                        {
                            strWhere += "where gt.MaGT = '" + (control as CheckBox).Name + "'";
                            isExists = true;
                        }
                    }
                    else
                    {
                        if ((control as CheckBox).IsChecked == true)
                        {
                            strWhere += " or gt.MaGT = '" + (control as CheckBox).Name + "'";
                        }
                    }

                }
            }
            if (isExists)
            {
                DataTable tb = BUS.NhanVienBUS.GetNhanVienByWhere(strWhere);
                BaoCaoex(tb, "DANH SÁCH NHÂN VIÊN THEO GIỚI TÍNH");
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn giới tính(Nam/Nữ) !");
            }
        }
        /// <summary>
        /// Danh sách nhân viên bị kỷ luật
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnKyLuat_Click(object sender, RoutedEventArgs e)
        {
            DataTable tb = BUS.NhanVienBUS.GetNhanVienBiKyLuat();
            BaoCaoex(tb, "DANH SÁCH NHÂN VIÊN BỊ KỶ LUẬT");
        }
        /// <summary>
        /// Danh sách nhân viên được khen thưởng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnKhenThuong_Click(object sender, RoutedEventArgs e)
        {
            DataTable tb = BUS.NhanVienBUS.GetNhanVienDuocKhenThuong();
            BaoCaoex(tb, "DANH SÁCH NHÂN VIÊN ĐƯỢC KHEN THƯỞNG");
        }
        /// <summary>
        /// Danh sách mừng sinh nhật nhân viên
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSinhNhat_Click(object sender, RoutedEventArgs e)
        {
            string strWhere = string.Format("Where MONTH(ctnv.NgaySinh) = '{0}'", DateTime.Now.Month.ToString());
            DataTable tb = BUS.NhanVienBUS.GetNhanVienByWhere(strWhere);
            BaoCaoex(tb, "DANH SÁCH NHÂN VIÊN CÓ SINH NHẬT TRONG THÁNG");
        }

        // sơ yếu lý lịch
        private void btnSoYeuLyLich_Click(object sender, RoutedEventArgs e)
        {
            //SoYeuLyLich syll = new SoYeuLyLich();
            //MainWindow main = new MainWindow();
            //main.Content = syll;
            //main.Show();
        }
        //hợp đồng lao động

        string name = "NCT";
        string address = "GL";
        string sdt = "010101";
        private void btnHopDong_Click(object sender, RoutedEventArgs e)
        {
            DocX gDoc;

            try
            {
                if (File.Exists(@"Test.docx"))
                {
                    gDoc = CreateInvoiceFromTemplate(DocX.Load(@"Test.docx"));
                    gDoc.SaveAs(@"newFile.docx");
                }
                else
                {
                    MessageBox.Show("Không có file Test.docx");
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        private DocX CreateInvoiceFromTemplate(DocX template)
        {
            template.AddCustomProperty(new CustomProperty("HoTen",this.name));
            template.AddCustomProperty(new CustomProperty("DiaChi",this.address));
            template.AddCustomProperty(new CustomProperty("Sdt", this.sdt));

            //table
            //var t = template.Tables[0];
            //CreateAndInsertInvoiceTableAfter(t, ref template);
            //t.Remove();
            return template;
        }
    }
}
