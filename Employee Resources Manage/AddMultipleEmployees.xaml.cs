﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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

namespace Employee_Resources_Manage
{
    /// <summary>
    /// Interaction logic for AddMultipleEmployees.xaml
    /// </summary>
    public partial class AddMultipleEmployees : UserControl
    {
        string manvLast = "";
        string mahdLast = "";
        OpenFileDialog fopen = new OpenFileDialog();
        List<string> listError = new List<string>();
        public AddMultipleEmployees()
        {
            InitializeComponent();
        }

        private void btnFile_Click(object sender, RoutedEventArgs e)
        {
            fopen = new OpenFileDialog();
            fopen.Filter = "Excel|*.xlsx";
            fopen.ShowDialog();
            if (fopen.FileName != "")
                tbFile.Text = fopen.FileName;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
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
                    int col = 43;
                    for (int i = 3; i <= rows; i++)
                    {
                        if (string.IsNullOrEmpty(range.Cells[i, col].Text.ToString()) != true)
                        {
                            if (string.IsNullOrEmpty(range.Cells[i, col + 1].Text.ToString()) != true)
                            {
                                if (string.IsNullOrEmpty(range.Cells[i, col + 6].Text.ToString()) != true)
                                {
                                    if (string.IsNullOrEmpty(range.Cells[i, col + 7].Text.ToString()) != true)
                                    {
                                        if (string.IsNullOrEmpty(range.Cells[i, col + 20].Text.ToString()) != true && range.Cells[i, col + 20].Text.ToString() != "#NAME?" && range.Cells[i, col + 20].Text.ToString() != "#N/A")
                                        {
                                            if (string.IsNullOrEmpty(range.Cells[i, col + 21].Text.ToString()) != true)
                                            {
                                                if (string.IsNullOrEmpty(range.Cells[i, col + 23].Text.ToString()) != true && range.Cells[i, col + 23].Text.ToString() != "#NAME?" && range.Cells[i, col + 23].Text.ToString() != "#N/A")
                                                {
                                                    DTO.NhanVienDTO nv = new DTO.NhanVienDTO();
                                                    manvLast = BUS.NhanVienBUS.GetLastNhanVien().Rows[0][0].ToString();
                                                    nv.MaNV = NextID(manvLast, "NV");
                                                    nv.HoTen = range.Cells[i, col].Text.ToString();
                                                    nv.NgayVaoLam = Convert.ToDateTime(range.Cells[i, col + 1].Text.ToString());
                                                    if (string.IsNullOrEmpty(range.Cells[i, col + 2].Text.ToString()) != true && range.Cells[i, col + 2].Text.ToString() != "#NAME?" && range.Cells[i, col + 2].Text.ToString() != "#N/A")
                                                        nv.MaPB = "'" + range.Cells[i, col + 2].Text.ToString() + "'";
                                                    else nv.MaPB = "NULL";
                                                    nv.LuongCanBan = range.Cells[i, col + 24].Text.ToString();
                                                    if (string.IsNullOrEmpty(range.Cells[i, col + 3].Text.ToString()) != true)
                                                        nv.HinhAnh = range.Cells[i, col + 3].Text.ToString();
                                                    else nv.HinhAnh = "";
                                                    if (string.IsNullOrEmpty(range.Cells[i, col + 4].Text.ToString()) != true && range.Cells[i, col + 4].Text.ToString() != "#NAME?" && range.Cells[i, col + 4].Text.ToString() != "#N/A")
                                                        nv.MaTT = Int16.Parse(range.Cells[i, col + 4].Text.ToString());
                                                    else nv.MaTT = 1;
                                                    DTO.ThongTinChiTietNhanVienDTO ttct = new DTO.ThongTinChiTietNhanVienDTO();
                                                    ttct.MaNV = nv.MaNV;

                                                    if (string.IsNullOrEmpty(range.Cells[i, col + 5].Text.ToString()) != true && range.Cells[i, col + 5].Text.ToString() != "#NAME?" && range.Cells[i, col + 5].Text.ToString() != "#N/A")
                                                        ttct.MaGT = Convert.ToBoolean(Convert.ToInt16(range.Cells[i, col + 5].Text.ToString()));
                                                    else ttct.MaGT = true;

                                                    ttct.CMND = range.Cells[i, col + 6].Text.ToString();

                                                    ttct.NgaySinh = Convert.ToDateTime(range.Cells[i, col + 7].Text.ToString());

                                                    if (string.IsNullOrEmpty(range.Cells[i, col + 8].Text.ToString()) != true)
                                                        ttct.NoiSinh = range.Cells[i, col + 8].Text.ToString();
                                                    else ttct.NoiSinh = "";

                                                    if (string.IsNullOrEmpty(range.Cells[i, col + 9].Text.ToString()) != true)
                                                        ttct.DienThoai = range.Cells[i, col + 9].Text.ToString();
                                                    else ttct.DienThoai = "";

                                                    if (string.IsNullOrEmpty(range.Cells[i, col + 10].Text.ToString()) != true)
                                                        ttct.SoNha = range.Cells[i, col + 10].Text.ToString();
                                                    else ttct.SoNha = "";

                                                    if (string.IsNullOrEmpty(range.Cells[i, col + 11].Text.ToString()) != true)
                                                        ttct.Duong = range.Cells[i, col + 11].Text.ToString();
                                                    else ttct.Duong = "";

                                                    if (string.IsNullOrEmpty(range.Cells[i, col + 12].Text.ToString()) != true)
                                                        ttct.PhuongXa = range.Cells[i, col + 12].Text.ToString();
                                                    else ttct.PhuongXa = "";

                                                    if (string.IsNullOrEmpty(range.Cells[i, col + 13].Text.ToString()) != true && range.Cells[i, col + 13].Text.ToString() != "#NAME?" && range.Cells[i, col + 13].Text.ToString() != "#N/A")
                                                        ttct.QuanHuyen = "'" + range.Cells[i, col + 13].Text.ToString() + "'";
                                                    else ttct.QuanHuyen = "NULL";

                                                    if (string.IsNullOrEmpty(range.Cells[i, col + 14].Text.ToString()) != true && range.Cells[i, col + 14].Text.ToString() != "#NAME?" && range.Cells[i, col + 14].Text.ToString() != "#N/A")
                                                        ttct.TinhTP = "'" + range.Cells[i, col + 14].Text.ToString() + "'";
                                                    else ttct.TinhTP = "NULL";

                                                    if (string.IsNullOrEmpty(range.Cells[i, col + 15].Text.ToString()) != true && range.Cells[i, col + 15].Text.ToString() != "#NAME?" && range.Cells[i, col + 15].Text.ToString() != "#N/A")
                                                        ttct.QuocGia = "'" + range.Cells[i, col + 15].Text.ToString() + "'";
                                                    else ttct.QuocGia = "NULL";

                                                    if (string.IsNullOrEmpty(range.Cells[i, col + 16].Text.ToString()) != true && range.Cells[i, col + 16].Text.ToString() != "#NAME?" && range.Cells[i, col + 16].Text.ToString() != "#N/A")
                                                        ttct.MaDT = "'" + range.Cells[i, col + 16].Text.ToString() + "'";
                                                    else ttct.MaDT = "NULL";

                                                    if (string.IsNullOrEmpty(range.Cells[i, col + 17].Text.ToString()) != true && range.Cells[i, col + 17].Text.ToString() != "#NAME?" && range.Cells[i, col + 17].Text.ToString() != "#N/A")
                                                        ttct.MaTG = "'" + range.Cells[i, col + 17].Text.ToString() + "'";
                                                    else ttct.MaTG = "NULL";

                                                    if (string.IsNullOrEmpty(range.Cells[i, col + 18].Text.ToString()) != true)
                                                        ttct.SoTheATM = range.Cells[i, col + 18].Text.ToString();
                                                    else ttct.SoTheATM = "";

                                                    if (string.IsNullOrEmpty(range.Cells[i, col + 19].Text.ToString()) != true)
                                                        ttct.Email = range.Cells[i, col + 19].Text.ToString();
                                                    else ttct.Email = "";

                                                    BUS.NguoiDungBUS.SetIsUpdated(Login.Account);
                                                    BUS.NhanVienBUS.AddNhanVienMulti(nv, ttct);
                                                    DTO.HopDongDTO hd = new DTO.HopDongDTO();
                                                    mahdLast = BUS.HopDongBUS.GetLastHopDong().Rows[0][0].ToString();
                                                    hd.MaHD = NextID(mahdLast, "HD");
                                                    hd.MaNV = nv.MaNV;
                                                    hd.MaLoaiHD = Int16.Parse(range.Cells[i, col + 20].Text.ToString());
                                                    hd.NgayKyHD = Convert.ToDateTime(range.Cells[i, col + 21].Text.ToString());
                                                    if (string.IsNullOrEmpty(range.Cells[i, col + 22].Text.ToString()) != true)
                                                        hd.NgayHetHan = Convert.ToDateTime(range.Cells[i, col + 22].Text.ToString());
                                                    else
                                                    {
                                                        switch (hd.MaLoaiHD.ToString())
                                                        {
                                                            case "1":
                                                                hd.NgayHetHan = Convert.ToDateTime("1/1/2500");
                                                                break;
                                                            case "2":
                                                                hd.NgayHetHan = Convert.ToDateTime(range.Cells[i, col + 21].Text.ToString()).AddYears(5).AddDays(-1);
                                                                break;
                                                            case "3":
                                                                hd.NgayHetHan = Convert.ToDateTime(range.Cells[i, col + 21].Text.ToString()).AddYears(3).AddDays(-1);
                                                                break;
                                                            case "4":
                                                                hd.NgayHetHan = Convert.ToDateTime(range.Cells[i, col + 21].Text.ToString()).AddYears(2).AddDays(-1);
                                                                break;
                                                            case "5":
                                                                hd.NgayHetHan = Convert.ToDateTime(range.Cells[i, col + 21].Text.ToString()).AddYears(1).AddDays(-1);
                                                                break;
                                                            case "6":
                                                                hd.NgayHetHan = Convert.ToDateTime(range.Cells[i, col + 21].Text.ToString()).AddMonths(3).AddDays(-1);
                                                                break;
                                                        }
                                                    }
                                                    hd.MaTTHD = Int16.Parse(range.Cells[i, col + 23].Text.ToString());
                                                    BUS.NguoiDungBUS.SetIsUpdated(Login.Account);
                                                    BUS.HopDongBUS.AddHopDongMulti(hd);
                                                }
                                                else
                                                {
                                                    string error = "Lỗi ở dòng " + i.ToString() + " cột Tình trạng hợp đồng.";
                                                    listError.Add(error);
                                                }
                                            }
                                            else
                                            {
                                                string error = "Lỗi ở dòng " + i.ToString() + " cột Ngày ký hợp đồng.";
                                                listError.Add(error);
                                            }
                                        }
                                        else
                                        {
                                            string error = "Lỗi ở dòng " + i.ToString() + " cột Loại hợp đồng.";
                                            listError.Add(error);
                                        }
                                    }
                                    else
                                    {
                                        string error = "Lỗi ở dòng " + i.ToString() + " cột Ngày sinh.";
                                        listError.Add(error);
                                    }
                                }
                                else
                                {
                                    string error = "Lỗi ở dòng " + i.ToString() + " cột CMND.";
                                    listError.Add(error);
                                }
                            }
                            else
                            {
                                string error = "Lỗi ở dòng " + i.ToString() + " cột Ngày vào làm.";
                                listError.Add(error);
                            }
                        }
                        else break;
                    }
                    MessageBox.Show("Thêm nhân viên thành công!");
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

        public string NextID(string lastID, string prefixID)
        {
            if (lastID == "")
            {
                return prefixID + "001";
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

        private void btnTemplate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string sourceFile = Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString() + @"\Resources\ImportEmployeeTemplate.xlsx";
                string destinationFile = path + "\\ImportEmployeeTemplate.xlsx";
                try { 
                File.Copy(sourceFile, destinationFile);
                }
                catch { }
                System.Diagnostics.Process.Start(destinationFile);
            }
            catch (Exception ex)
            { }
        }

        private void btnError_Click(object sender, RoutedEventArgs e)
        {
            if(listError.Count>0)
            {
                string errors = "";
                int counterror = 0;
                foreach(string error in listError)
                {
                    counterror++;
                    errors += error + "\n";
                }
                errors += "Tổng cộng: " + counterror.ToString()+" lỗi!";
                dialogError.DataContext = errors;
                dialogError.IsOpen = true;
            }
            else
            {
                dialogError.DataContext = "Không có lỗi xảy ra!";
                dialogError.IsOpen = true;
            }
        }
    }
}

