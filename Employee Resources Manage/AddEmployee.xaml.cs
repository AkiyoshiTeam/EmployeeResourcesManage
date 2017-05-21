using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mail;
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

namespace Employee_Resources_Manage
{
    /// <summary>
    /// Interaction logic for AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : UserControl
    {
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
        List<LoaiHopDong> listLHD;
        List<TinhTrangHopDong> listTTHD;
        string manvLast = "";
        string mahdLast = "";
        public AddEmployee()
        {
            InitializeComponent();
            dpNVL.Language = System.Windows.Markup.XmlLanguage.GetLanguage("vi-VN");
            dpNgaySinh.Language = System.Windows.Markup.XmlLanguage.GetLanguage("vi-VN");
            manvLast = BUS.NhanVienBUS.GetLastNhanVien().Rows[0][0].ToString();
            tbMaNV.Text = NextID(manvLast, "NV");
            mahdLast = BUS.HopDongBUS.GetLastHopDong().Rows[0][0].ToString();
            tbMaHD.Text = NextID(mahdLast, "HD");
            TextFieldsViewModel tfvm = new TextFieldsViewModel();
            tbHoTen.DataContext = tfvm;
            tbCMND.DataContext = tfvm;
            dpNVL.SelectedDate = DateTime.Today;
            dpNgayKyHD.SelectedDate = DateTime.Today;

            DirectoryInfo d = new DirectoryInfo(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString() + @"\Resources\Images\Avatar");//Assuming Test is your Folder
            FileInfo[] Files = d.GetFiles("*.*"); //Getting Text files
            List<string> listAvatarName = new List<string>();
            foreach (FileInfo file in Files)
            {
                listAvatarName.Add(file.Name);
            }
            cbHinhAnh.ItemsSource = listAvatarName;

            DataTable tbTemp = BUS.PhongBanBUS.GetPhongBan();
            listPB = new List<PhongBan>();
            foreach (DataRow row in tbTemp.Rows)
            {
                listPB.Add(new PhongBan { ID = row[0].ToString().Trim(), Name = row[1].ToString(), MaBP = row[2].ToString() });
            }
            cbPhongBan.ItemsSource = listPB;
            cbPhongBan.DisplayMemberPath = "Name";
            cbPhongBan.SelectedValuePath = "ID";
            cbPhongBan.SelectedValue = "PB002";

            tbTemp = BUS.ChucVuBUS.GetChucVu();
            listCV = new List<ChucVu>();
            foreach (DataRow row in tbTemp.Rows)
            {
                listCV.Add(new ChucVu { ID = row[0].ToString().Trim(), Name = row[1].ToString() });
            }
            cbChucVu.ItemsSource = listCV;
            cbChucVu.DisplayMemberPath = "Name";
            cbChucVu.SelectedValuePath = "ID";
            cbChucVu.SelectedValue = "CV004";

            tbTemp = BUS.LoaiLuongBUS.GetLoaiLuong();
            listLL = new List<LoaiLuong>();
            foreach (DataRow row in tbTemp.Rows)
            {
                listLL.Add(new LoaiLuong { ID = row[0].ToString().Trim(), Name = row[1].ToString() });
            }
            cbLoaiLuong.ItemsSource = listLL;
            cbLoaiLuong.DisplayMemberPath = "Name";
            cbLoaiLuong.SelectedValuePath = "ID";
            cbLoaiLuong.SelectedValue = "1";

            tbTemp = BUS.TinhTrangBUS.GetTinhTrang();
            listTT = new List<TinhTrang>();
            foreach (DataRow row in tbTemp.Rows)
            {
                listTT.Add(new TinhTrang { ID = row[0].ToString().Trim(), Name = row[1].ToString() });
            }
            cbTinhTrang.ItemsSource = listTT;
            cbTinhTrang.DisplayMemberPath = "Name";
            cbTinhTrang.SelectedValuePath = "ID";
            cbTinhTrang.SelectedValue = "1";


            listGT = new List<GioiTinh>();
            listGT.Add(new GioiTinh { ID = false, Name = "Nữ" });
            listGT.Add(new GioiTinh { ID = true, Name = "Nam" });
            cbGioiTinh.ItemsSource = listGT;
            cbGioiTinh.DisplayMemberPath = "Name";
            cbGioiTinh.SelectedValuePath = "ID";
            cbGioiTinh.SelectedValue = true;

            tbTemp = BUS.QuanHuyenBUS.GetQuanHuyen();
            listQH = new List<QuanHuyen>();
            foreach (DataRow row in tbTemp.Rows)
            {
                listQH.Add(new QuanHuyen { ID = row[0].ToString().Trim(), Name = row[1].ToString(), MaTinh = row[2].ToString() });
            }
            cbQuanHuyen.ItemsSource = listQH;
            cbQuanHuyen.DisplayMemberPath = "Name";
            cbQuanHuyen.SelectedValuePath = "ID";
            cbQuanHuyen.SelectedValue = "01";

            tbTemp = BUS.TinhTPBUS.GetTinhTP();
            listTTP = new List<TinhTP>();
            foreach (DataRow row in tbTemp.Rows)
            {
                listTTP.Add(new TinhTP { ID = row[0].ToString().Trim(), Name = row[1].ToString(), MaQG = row[2].ToString() });
            }
            cbTinhTP.ItemsSource = listTTP;
            cbTinhTP.DisplayMemberPath = "Name";
            cbTinhTP.SelectedValuePath = "ID";
            cbTinhTP.SelectedValue = "46";


            tbTemp = BUS.QuocGiaBUS.GetQuocGia();
            listQG = new List<QuocGia>();
            foreach (DataRow row in tbTemp.Rows)
            {
                listQG.Add(new QuocGia { ID = row[0].ToString().Trim(), Name = row[1].ToString() });
            }
            cbQuocGia.ItemsSource = listQG;
            cbQuocGia.DisplayMemberPath = "Name";
            cbQuocGia.SelectedValuePath = "ID";
            cbQuocGia.SelectedValue = "84";

            tbTemp = BUS.TonGiaoBUS.GetTonGiao();
            listTG = new List<TonGiao>();
            foreach (DataRow row in tbTemp.Rows)
            {
                listTG.Add(new TonGiao { ID = row[0].ToString().Trim(), Name = row[1].ToString() });
            }
            cbTonGiao.ItemsSource = listTG;
            cbTonGiao.DisplayMemberPath = "Name";
            cbTonGiao.SelectedValuePath = "ID";
            cbTonGiao.SelectedValue = "1";

            tbTemp = BUS.DanTocBUS.GetDanToc();
            listDT = new List<DanToc>();
            foreach (DataRow row in tbTemp.Rows)
            {
                listDT.Add(new DanToc { ID = row[0].ToString().Trim(), Name = row[1].ToString() });
            }
            cbDanToc.ItemsSource = listDT;
            cbDanToc.DisplayMemberPath = "Name";
            cbDanToc.SelectedValuePath = "ID";
            cbDanToc.SelectedValue = "01";

            tbTemp = BUS.LoaiHopDongBUS.GetLoaiHopDong();
            listLHD = new List<LoaiHopDong>();
            foreach (DataRow row in tbTemp.Rows)
            {
                listLHD.Add(new LoaiHopDong { ID = row[0].ToString().Trim(), Name = row[1].ToString() });
            }
            cbMaLoaiHD.ItemsSource = listLHD;
            cbMaLoaiHD.DisplayMemberPath = "Name";
            cbMaLoaiHD.SelectedValuePath = "ID";
            cbMaLoaiHD.SelectedValue = "1";

            tbTemp = BUS.TinhTrangHopDongBUS.GetTinhTrangHopDong();
            listTTHD = new List<TinhTrangHopDong>();
            foreach (DataRow row in tbTemp.Rows)
            {
                listTTHD.Add(new TinhTrangHopDong { ID = row[0].ToString().Trim(), Name = row[1].ToString() });
            }
            cbMaTTHD.ItemsSource = listTTHD;
            cbMaTTHD.DisplayMemberPath = "Name";
            cbMaTTHD.SelectedValuePath = "ID";
            cbMaTTHD.SelectedValue = "1";

        }

        private void Numeric_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsNumeric(e.Text);
        }


        private static bool IsNumeric(string text)
        {
            Regex regex = new Regex(@"[\d]");
            return regex.IsMatch(text);
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

        private void getImages_Click(object sender, RoutedEventArgs e)
        {
            CopyImage();
        }

        void CopyImage()
        {

            System.Windows.Forms.OpenFileDialog od = new System.Windows.Forms.OpenFileDialog();
            od.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            od.Multiselect = true;

            if (od.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    string tempFolder = Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString();

                    foreach (string fileName in od.FileNames)
                    {
                        File.Copy(fileName, tempFolder + @"\Resources\Images\Avatar\" + System.IO.Path.GetFileName(fileName));
                    }
                    DirectoryInfo d = new DirectoryInfo(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString() + @"\Resources\Images\Avatar");//Assuming Test is your Folder
                    FileInfo[] Files = d.GetFiles("*.*"); //Getting Text files
                    List<string> listAvatarName = new List<string>();
                    foreach (FileInfo file in Files)
                    {
                        listAvatarName.Add(file.Name);
                    }
                    cbHinhAnh.ItemsSource = listAvatarName;
                }
                catch (Exception ex)
                { }
            }
        }

        private void DatePicker_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void cbHinhAnh_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TransitioningContent transitioningContent = new TransitioningContent();
            TransitionEffect effect = new TransitionEffect();
            effect.Kind = TransitionEffectKind.ExpandIn;
            transitioningContent.OpeningEffect = effect;
            object avatarContent;
            Image img = new Image();
            //img.Stretch = Stretch.None;
            img.VerticalAlignment = VerticalAlignment.Center;
            img.HorizontalAlignment = HorizontalAlignment.Center;
            try
            {
                if (IsRefresh==false)
                {
                    BitmapImage bitm = new BitmapImage();
                    bitm.BeginInit();
                    bitm.UriSource = new Uri(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString() + @"\Resources\Images\Avatar\" + cbHinhAnh.SelectedValue.ToString(), UriKind.RelativeOrAbsolute);
                    bitm.EndInit();
                    img.Source = bitm;
                    img.Stretch = Stretch.UniformToFill;
                }
                else
                {
                    BitmapImage bitm = new BitmapImage();
                    bitm.BeginInit();
                    bitm.UriSource = new Uri(@"../../Resources/Images/account-card-details-black.png", UriKind.RelativeOrAbsolute);
                    bitm.EndInit();
                    img.Source = bitm;
                    img.Opacity = 0.4;
                    img.Stretch = Stretch.None;
                    IsRefresh = false;
                }
            }
            catch (Exception ex)
            {
                BitmapImage bitm = new BitmapImage();
                bitm.BeginInit();
                bitm.UriSource = new Uri(@"../../Resources/Images/account-card-details-black.png", UriKind.RelativeOrAbsolute);
                bitm.EndInit();
                img.Source = bitm;
                img.Opacity = 0.4;
                img.Stretch = Stretch.None;
            }
            finally
            {
                avatarContent = img;
                transitioningContent.Content = avatarContent;
                avatarContentControl.Content = transitioningContent;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (tbHoTen.Text != "")
            {
                if (tbCMND.Text.Length >= 9)
                {
                    if (tbATM.Text.Length > 0)
                    {
                        if (IsMail(tbEmail.Text) == true)
                        {
                            if (dpNgaySinh.SelectedDate != null)
                            {
                                DTO.NhanVienDTO nv = new DTO.NhanVienDTO();
                                manvLast = BUS.NhanVienBUS.GetLastNhanVien().Rows[0][0].ToString();
                                nv.MaNV = NextID(manvLast, "NV");
                                nv.HoTen = tbHoTen.Text;
                                nv.NgayVaoLam = Convert.ToDateTime(dpNVL.Text);
                                nv.MaCV = cbChucVu.SelectedValue.ToString();
                                nv.MaPB = cbPhongBan.SelectedValue.ToString();
                                nv.MaLoaiLuong = cbLoaiLuong.SelectedValue.ToString();
                                if (cbHinhAnh.SelectedValue != null)
                                    nv.HinhAnh = cbHinhAnh.SelectedValue.ToString();
                                else nv.HinhAnh = "";
                                nv.MaTT = Int16.Parse(cbTinhTrang.SelectedValue.ToString());
                                DTO.ThongTinChiTietNhanVienDTO ttct = new DTO.ThongTinChiTietNhanVienDTO();
                                ttct.MaNV = nv.MaNV;
                                ttct.MaGT = Convert.ToBoolean(cbGioiTinh.SelectedIndex);
                                ttct.CMND = tbCMND.Text;
                                ttct.NgaySinh = Convert.ToDateTime(dpNgaySinh.Text);
                                ttct.NoiSinh = tbNoiSinh.Text;
                                ttct.DienThoai = tbDienThoai.Text;
                                ttct.SoNha = tbSoNha.Text;
                                ttct.Duong = tbDuong.Text;
                                ttct.PhuongXa = tbPhuongXa.Text;
                                ttct.QuanHuyen = cbQuanHuyen.SelectedValue.ToString();
                                ttct.TinhTP = cbTinhTP.SelectedValue.ToString();
                                ttct.QuocGia = cbQuocGia.SelectedValue.ToString();
                                ttct.MaDT = cbDanToc.SelectedValue.ToString();
                                ttct.MaTG = cbTonGiao.SelectedValue.ToString();
                                ttct.SoTheATM = tbATM.Text;
                                ttct.Email = tbEmail.Text;
                                BUS.NhanVienBUS.AddNhanVien(nv, ttct);
                                DTO.HopDongDTO hd = new DTO.HopDongDTO();
                                mahdLast = BUS.HopDongBUS.GetLastHopDong().Rows[0][0].ToString();
                                hd.MaHD = NextID(mahdLast, "HD");
                                hd.MaNV = nv.MaNV;
                                hd.MaLoaiHD = Int16.Parse(cbMaLoaiHD.SelectedValue.ToString());
                                hd.NgayKyHD = Convert.ToDateTime(dpNgayKyHD.Text);
                                if (dpNgayHetHan.SelectedDate != null && dpNgayHetHan.Text !="")
                                    hd.NgayHetHan = Convert.ToDateTime(dpNgayHetHan.Text);
                                else hd.NgayHetHan = Convert.ToDateTime("1/1/2500");
                                hd.MaTTHD = Int16.Parse(cbMaTTHD.SelectedValue.ToString());
                                BUS.HopDongBUS.AddHopDong(hd);
                                RefreshField();
                            }
                        }
                        else
                        {
                            dialogHostWarning.DataContext = "Chuỗi không đúng định dạng Email!";
                            dialogHostWarning.IsOpen = true;
                        }
                    }
                }
                else
                {
                    dialogHostWarning.DataContext = "CMND phải có 9 hoặc 12 số!";
                    dialogHostWarning.IsOpen = true;
                }
            }
            else {
                dialogHostWarning.DataContext = "Họ tên không được bỏ trống!";
                dialogHostWarning.IsOpen = true;
            }
        }

        bool IsRefresh = false;

        public void RefreshField()
        {
            manvLast = BUS.NhanVienBUS.GetLastNhanVien().Rows[0][0].ToString();
            tbMaNV.Text = NextID(manvLast, "NV");
            dpNVL.SelectedDate = DateTime.Today;
            tbHoTen.Text = "";
            IsRefresh = true;
            cbHinhAnh.SelectedValue = null;
            tbCMND.Text = "";
            dpNgaySinh.SelectedDate = null;
            tbNoiSinh.Text = "";
            tbDienThoai.Text = "";
            tbSoNha.Text = "";
            tbDuong.Text = "";
            tbPhuongXa.Text = "";
            tbATM.Text = "";
            tbEmail.Text = "";
            mahdLast = BUS.HopDongBUS.GetLastHopDong().Rows[0][0].ToString();
            tbMaHD.Text = NextID(mahdLast, "HD");
        }

        public bool IsMail(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshField();
        }

        public void ChangeDateEnd()
        {
            switch (cbMaLoaiHD.SelectedValue.ToString())
            {
                case "1":
                    break;
                case "2":
                    dpNgayHetHan.SelectedDate = ((DateTime)dpNgayKyHD.SelectedDate).AddYears(5).AddDays(-1);
                    break;
                case "3":
                    dpNgayHetHan.SelectedDate = ((DateTime)dpNgayKyHD.SelectedDate).AddYears(3).AddDays(-1);
                    break;
                case "4":
                    dpNgayHetHan.SelectedDate = ((DateTime)dpNgayKyHD.SelectedDate).AddYears(2).AddDays(-1);
                    break;
                case "5":
                    dpNgayHetHan.SelectedDate = ((DateTime)dpNgayKyHD.SelectedDate).AddYears(1).AddDays(-1);
                    break;
                case "6":
                    dpNgayHetHan.SelectedDate = ((DateTime)dpNgayKyHD.SelectedDate).AddMonths(3).AddDays(-1);
                    break;
            }
        }

        private void cbMaLoaiHD_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ChangeDateEnd();
        }

        private void DpNgayKyHD_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            ChangeDateEnd();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            cbMaLoaiHD.SelectionChanged += cbMaLoaiHD_SelectionChanged;
            dpNgayKyHD.SelectedDateChanged += DpNgayKyHD_SelectedDateChanged;
        }

        
    }
}
