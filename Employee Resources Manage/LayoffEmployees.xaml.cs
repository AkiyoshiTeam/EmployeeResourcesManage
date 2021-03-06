﻿using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
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
using System.Globalization;
using System.IO;

namespace Employee_Resources_Manage
{
    /// <summary>
    /// Interaction logic for LayoffEmployees.xaml
    /// </summary>

    public partial class LayoffEmployees : UserControl
    {
        DataTable dt;
        //public static List<ChucVu> listCV = new List<ChucVu>();
        //public static List<PhongBan> listPB = new List<PhongBan>();
        //public static List<TinhTrang> listTT = new List<TinhTrang>();
        //public static List<GioiTinh> listGT = new List<GioiTinh>();
        //public static List<QuanHuyen> listQH = new List<QuanHuyen>();
        //public static List<TinhTP> listTTP = new List<TinhTP>();
        //public static List<QuocGia> listQG = new List<QuocGia>();
        //public static List<DanToc> listDT = new List<DanToc>();
        //public static List<TonGiao> listTG = new List<TonGiao>();
        //public static List<LoaiHopDong> listLHD = new List<LoaiHopDong>();
        //public static List<TinhTrangHopDong> listTTHD = new List<TinhTrangHopDong>();

        public LayoffEmployees()
        {
            InitializeComponent();
            CreateColumns();
        }

        private void CreateColumns()
        {
            if (MainWindow.selectedTableStatic != null)
            {
                if (MainWindow.selectedTableStatic.Rows.Count > 0)
                {
                    dt = BUS.NhanVienBUS.GetNhanVienByElementForLayoff(MainWindow.selectedTableStatic);
                    dataGridSelectedNV.DataContext = dt;

                    DataTable tbTemp;
                    tbTemp = BUS.PhongBanBUS.GetPhongBan();
                    foreach (DataRow row in tbTemp.Rows)
                    {
                        MainWindow.listPB.Add(new PhongBan { ID = row[0].ToString(), Name = row[1].ToString() });
                    }
                    
                    tbTemp = BUS.TinhTrangBUS.GetTinhTrang();
                    foreach (DataRow row in tbTemp.Rows)
                    {
                        MainWindow.listTT.Add(new TinhTrang { ID = row[0].ToString(), Name = row[1].ToString() });
                    }

                    MainWindow.listGT.Add(new GioiTinh { ID = true, Name = "Nam" });
                    MainWindow.listGT.Add(new GioiTinh { ID = false, Name = "Nữ" });

                    tbTemp = BUS.QuanHuyenBUS.GetQuanHuyen();
                    foreach (DataRow row in tbTemp.Rows)
                    {
                        MainWindow.listQH.Add(new QuanHuyen { ID = row[0].ToString(), Name = row[1].ToString() });
                    }

                    tbTemp = BUS.TinhTPBUS.GetTinhTP();
                    foreach (DataRow row in tbTemp.Rows)
                    {
                        MainWindow.listTTP.Add(new TinhTP { ID = row[0].ToString(), Name = row[1].ToString() });
                    }

                    tbTemp = BUS.QuocGiaBUS.GetQuocGia();
                    foreach (DataRow row in tbTemp.Rows)
                    {
                        MainWindow.listQG.Add(new QuocGia { ID = row[0].ToString(), Name = row[1].ToString() });
                    }

                    tbTemp = BUS.DanTocBUS.GetDanToc();
                    foreach (DataRow row in tbTemp.Rows)
                    {
                        MainWindow.listDT.Add(new DanToc { ID = row[0].ToString(), Name = row[1].ToString() });
                    }

                    tbTemp = BUS.TonGiaoBUS.GetTonGiao();
                    foreach (DataRow row in tbTemp.Rows)
                    {
                        MainWindow.listTG.Add(new TonGiao { ID = row[0].ToString(), Name = row[1].ToString() });
                    }

                    tbTemp = BUS.TinhTrangHopDongBUS.GetTinhTrangHopDong();
                    foreach (DataRow row in tbTemp.Rows)
                    {
                        MainWindow.listTTHD.Add(new TinhTrangHopDong { ID = row[0].ToString(), Name = row[1].ToString() });
                    }

                    tbTemp = BUS.LoaiHopDongBUS.GetLoaiHopDong();
                    foreach (DataRow row in tbTemp.Rows)
                    {
                        MainWindow.listLHD.Add(new LoaiHopDong { ID = row[0].ToString(), Name = row[1].ToString() });
                    }

                    MaterialDataGridTextColumn col;
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        switch (dt.Columns[i].ColumnName.Trim())
                        {
                            case "MaNV1":
                            case "MaNV2":
                            case "HinhAnh":
                                break;
                            case "NgayVaoLam":
                            case "NgayKyHD":
                            case "NgayHetHan":
                            case "NgaySinh":
                                var c = new DataGridTemplateColumn();
                                var template = new DataTemplate();
                                var textBlockFactory = new FrameworkElementFactory(typeof(TextBlock));
                                Binding bd = new Binding();
                                bd.StringFormat = "{0:dd/MM/yyyy}";
                                bd.Path = new PropertyPath(dt.Columns[i].ColumnName.Trim());
                                textBlockFactory.SetBinding(TextBlock.TextProperty, bd);
                                template.VisualTree = textBlockFactory;
                                c.CellTemplate = template;
                                c.Header = dt.Columns[i].ColumnName.Trim();
                                dataGridSelectedNV.Columns.Add(c);
                                break;
                            case "MaPB":
                                col = new MaterialDataGridTextColumn();
                                col.Header = "PhongBan";
                                col.Binding = new Binding(dt.Columns[i].ColumnName.Trim())
                                {
                                    Converter = new MaPBConverter()
                                };
                                dataGridSelectedNV.Columns.Add(col);
                                break;
                            case "MaTT":
                                col = new MaterialDataGridTextColumn();
                                col.Header = "TinhTrang";
                                col.Binding = new Binding(dt.Columns[i].ColumnName.Trim())
                                {
                                    Converter = new MaTTConverter()
                                };
                                dataGridSelectedNV.Columns.Add(col);
                                break;
                            case "MaGT":
                                col = new MaterialDataGridTextColumn();
                                col.Header = "GioiTinh";
                                col.Binding = new Binding(dt.Columns[i].ColumnName.Trim())
                                {
                                    Converter = new MaGTConverter()
                                };
                                dataGridSelectedNV.Columns.Add(col);
                                break;
                            case "QuanHuyen":
                                col = new MaterialDataGridTextColumn();
                                col.Header = "QuanHuyen";
                                col.Binding = new Binding(dt.Columns[i].ColumnName.Trim())
                                {
                                    Converter = new MaQHConverter()
                                };
                                dataGridSelectedNV.Columns.Add(col);
                                break;
                            case "TinhTP":
                                col = new MaterialDataGridTextColumn();
                                col.Header = "TinhThanhPho";
                                col.Binding = new Binding(dt.Columns[i].ColumnName.Trim())
                                {
                                    Converter = new MaTTPConverter()
                                };
                                dataGridSelectedNV.Columns.Add(col);
                                break;
                            case "QuocGia":
                                col = new MaterialDataGridTextColumn();
                                col.Header = "QuocGia";
                                col.Binding = new Binding(dt.Columns[i].ColumnName.Trim())
                                {
                                    Converter = new MaQGConverter()
                                };
                                dataGridSelectedNV.Columns.Add(col);
                                break;
                            case "MaDT":
                                col = new MaterialDataGridTextColumn();
                                col.Header = "DanToc";
                                col.Binding = new Binding(dt.Columns[i].ColumnName.Trim())
                                {
                                    Converter = new MaDTConverter()
                                };
                                dataGridSelectedNV.Columns.Add(col);
                                break;
                            case "MaTG":
                                col = new MaterialDataGridTextColumn();
                                col.Header = "TonGiao";
                                col.Binding = new Binding(dt.Columns[i].ColumnName.Trim())
                                {
                                    Converter = new MaTGConverter()
                                };
                                dataGridSelectedNV.Columns.Add(col);
                                break;
                            case "MaLoaiHD":
                                col = new MaterialDataGridTextColumn();
                                col.Header = "LoaiHopDong";
                                col.Binding = new Binding(dt.Columns[i].ColumnName.Trim())
                                {
                                    Converter = new MaLHDConverter()
                                };
                                dataGridSelectedNV.Columns.Add(col);
                                break;
                            case "MaTTHD":
                                col = new MaterialDataGridTextColumn();
                                col.Header = "TinhTrangHopDong";
                                col.Binding = new Binding(dt.Columns[i].ColumnName.Trim())
                                {
                                    Converter = new MaTTHDConverter()
                                };
                                dataGridSelectedNV.Columns.Add(col);
                                break;
                            default:
                                col = new MaterialDataGridTextColumn();
                                col.Header = dt.Columns[i].ColumnName.Trim();
                                col.Binding = new Binding(dt.Columns[i].ColumnName.Trim());
                                dataGridSelectedNV.Columns.Add(col);
                                break;
                        }
                    }
                }
            }
        }

        bool layOff = true;

        private void btnLayoff_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.selectedTableStatic != null)
            {
                if (MainWindow.selectedTableStatic.Rows.Count != 0)
                {
                    layOff = true;
                    DialogWarning dlgWarning = new DialogWarning();
                    dlgWarning.Acc = "true";
                    dlgWarning.Content = "Bạn có chắc muốn sa thải " + dt.Rows.Count.ToString() + " nhân viên?";
                    dialogHostWarning.DataContext = dlgWarning;
                    dialogHostWarning.IsOpen = true;
                }
            }
            else
            {
                DialogWarning dlgWarning = new DialogWarning();
                dlgWarning.Acc = "false";
                dlgWarning.Content = "Không có nhân viên nào được chọn!!!";
                dialogHostWarning.DataContext = dlgWarning;
                dialogHostWarning.IsOpen = true;
            }
        }


        private void btnUnLayoff_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.selectedTableStatic != null)
            {
                if (MainWindow.selectedTableStatic.Rows.Count != 0)
                {
                    layOff = false;
                    DialogWarning dlgWarning = new DialogWarning();
                    dlgWarning.Acc = "Visible";
                    dlgWarning.Content = "Bạn muốn hồi phục " + dt.Rows.Count.ToString() + " nhân viên?";
                    dialogHostWarning.DataContext = dlgWarning;
                    dialogHostWarning.IsOpen = true;
                }
            }
            else
            {
                DialogWarning dlgWarning = new DialogWarning();
                dlgWarning.Acc = "Hidden";
                dlgWarning.Content = "Không có nhân viên nào được chọn!!!";
                dialogHostWarning.DataContext = dlgWarning;
                dialogHostWarning.IsOpen = true;
            }
        }

        private void btnRefreshData_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridSelectedNV.Columns.Count == 0)
                CreateColumns();
            else RefreshData();
        }

        private void dialogHost_DialogClosing(object sender, DialogClosingEventArgs eventArgs)
        {
            if ((bool)eventArgs.Parameter == true)
            {
                if (layOff == true)
                {
                    BUS.NguoiDungBUS.SetIsUpdated(Login.Account);
                    BUS.NhanVienBUS.LayoffNhanVien(dt);
                    RefreshData();
                }
                else
                {
                    BUS.NguoiDungBUS.SetIsUpdated(Login.Account);
                    BUS.NhanVienBUS.UnLayoffNhanVien(dt);
                    RefreshData();
                }
            }
        }

        private void RefreshData()
        {
            if (MainWindow.selectedTableStatic != null)
            {
                if (MainWindow.selectedTableStatic.Rows.Count > 0)
                {
                    dt = BUS.NhanVienBUS.GetNhanVienByElementForLayoff(MainWindow.selectedTableStatic);
                    dataGridSelectedNV.DataContext = dt;
                }
            }
        }

    }
}
