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

namespace Employee_Resources_Manage
{
    /// <summary>
    /// Interaction logic for SalaryFormula.xaml
    /// </summary>
    public partial class SalaryFormula : UserControl
    {
        DataTable dt = new DataTable();
        Stack<int> listkieukytu = new Stack<int>();
        string chuoikytu = "";
        int countngoac = 0;
        int kieukytu = 3;
        public SalaryFormula()
        {
            InitializeComponent();
            dt = BUS.CongThucTinhLuongBUS.GetCongThucTinhLuong();
            tbCongThucCu.Text = dt.Rows[0][0].ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            switch ((sender as Button).Name)
            {
                case "btn0":
                case "btn1":
                case "btn2":
                case "btn3":
                case "btn4":
                case "btn5":
                case "btn6":
                case "btn7":
                case "btn8":
                case "btn9":
                    if (kieukytu != 1)
                    {
                        listkieukytu.Push(2);
                        chuoikytu += (sender as Button).Name.Replace("btn", "");
                        tbCongThucMoi.Text = chuoikytu;
                        kieukytu = 2;
                    }
                    break;
                case "btnA":
                case "btnB":
                case "btnC":
                case "btnD":
                    if (kieukytu != 1)
                    {
                        listkieukytu.Push(1);
                        chuoikytu += (sender as Button).Name.Replace("btn", "");
                        tbCongThucMoi.Text = chuoikytu;
                        kieukytu = 1;
                    }
                    break;
                case "btnCong":
                    if (kieukytu != 3)
                    {
                        listkieukytu.Push(3);
                        chuoikytu += "+";
                        tbCongThucMoi.Text = chuoikytu;
                        kieukytu = 3;
                    }
                    break;
                case "btnTru":
                    if (kieukytu != 3)
                    {
                        listkieukytu.Push(3);
                        chuoikytu += "-";
                        tbCongThucMoi.Text = chuoikytu;
                        kieukytu = 3;
                    }
                    break;
                case "btnNhan":
                    if (kieukytu != 3)
                    {
                        listkieukytu.Push(3);
                        chuoikytu += "*";
                        tbCongThucMoi.Text = chuoikytu;
                        kieukytu = 3;
                    }
                    break;
                case "btnChia":
                    if (kieukytu != 3)
                    {
                        listkieukytu.Push(3);
                        chuoikytu += "/";
                        tbCongThucMoi.Text = chuoikytu;
                        kieukytu = 3;
                    }
                    break;
                case "btnBack":
                    if (tbCongThucMoi.Text != "...")
                    {
                        if (tbCongThucMoi.Text.Substring(tbCongThucMoi.Text.Length - 1) == "(")
                            countngoac--;
                        if (tbCongThucMoi.Text.Substring(tbCongThucMoi.Text.Length - 1) == ")")
                            countngoac++;
                        tbCongThucMoi.Text = tbCongThucMoi.Text.Substring(0, tbCongThucMoi.Text.Length - 1);
                        chuoikytu = tbCongThucMoi.Text;
                        listkieukytu.Pop();
                        if (tbCongThucMoi.Text.Length == 0)
                        {
                            tbCongThucMoi.Text = "...";
                            kieukytu = 3;
                        }
                        else
                        {
                            kieukytu = listkieukytu.Peek();
                        }
                    }
                    break;
                case "btnNgoacTruoc":
                    if (kieukytu == 3)
                    {
                        listkieukytu.Push(3);
                        chuoikytu += "(";
                        tbCongThucMoi.Text = chuoikytu;
                        countngoac++;
                    }
                    break;
                case "btnNgoacSau":
                    if(countngoac>0 && (kieukytu == 1 || kieukytu == 2))
                    {
                        listkieukytu.Push(3);
                        chuoikytu += ")";
                        tbCongThucMoi.Text = chuoikytu;
                        countngoac--;
                    }
                    break;
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if(countngoac>0)
            {
                tbThongBao.Text = "Thiếu "+countngoac.ToString()+" dấu ')', kiểm tra lại chuỗi.";
            }else if(listkieukytu.Peek()==3)
            {
                tbThongBao.Text = "Kiểm tra lại ký tự cuối.";
            }
            else
            {
                tbThongBao.Text = "";
                dialogHostWarning.DataContext = "Bạn thật sự muốn thay đổi công thức tính lương!";
                dialogHostWarning.IsOpen = true;
            }
        }

        private void dialogHost_DialogClosing(object sender, DialogClosingEventArgs eventArgs)
        {
            if ((bool)eventArgs.Parameter == true)
            {
                BUS.CongThucTinhLuongBUS.UpdateCongThuc(tbCongThucMoi.Text);
                Refresh();
            }
        }

        public void Refresh()
        {
            dt = BUS.CongThucTinhLuongBUS.GetCongThucTinhLuong();
            tbCongThucCu.Text = dt.Rows[0][0].ToString();
            tbCongThucMoi.Text = "...";
            kieukytu = 3;
            listkieukytu = new Stack<int>();
            chuoikytu = "";
            countngoac = 0;
        }
    }
}
