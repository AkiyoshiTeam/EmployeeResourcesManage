using System;
using System.Collections;
using System.Collections.Generic;
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

namespace Employee_Resources_Manage
{
    /// <summary>
    /// Interaction logic for SalaryCalculating.xaml
    /// </summary>
    public partial class SalaryCalculating : UserControl
    {
        public SalaryCalculating()
        {
            InitializeComponent();
            dataGridNhanVien.DataContext = MainWindow.selectedTableStatic;
        }

        private void btnTinhLuong_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MainWindow.selectedTableStatic.Rows.Count > 0)
                {
                    string congThuc = Infix2Postfix(BUS.CongThucTinhLuongBUS.GetCongThucTinhLuong().Rows[0][0].ToString());

                    DataTable dtLCB = BUS.NhanVienBUS.GetNhanVienLuongCB(MainWindow.selectedTableStatic);
                    foreach (DataRow row in dtLCB.Rows)
                    {
                        string manv = row[0].ToString();
                        DataTable cc = BUS.ChiTietChamCongBUS.GetCTCCByMANV(manv);
                        foreach (DataRow rowCC in cc.Rows)
                        {
                            DTO.ChiTietChamCongDTO ctcc = new DTO.ChiTietChamCongDTO();
                            ctcc.MaChamCong = rowCC[0].ToString();
                            ctcc.MaNV = rowCC[1].ToString();
                            ctcc.NgayCong = Int32.Parse(rowCC[2].ToString());
                            ctcc.TrangThai = Int32.Parse(rowCC[3].ToString());
                            long luongCB = Convert.ToInt64(row[1].ToString());
                            long phucCap = 0;
                            DataTable tbtemp = BUS.NhanVienBUS.GetNhanVienPhuCap(manv);
                            if (tbtemp.Rows.Count > 0)
                                phucCap = Convert.ToInt64(tbtemp.Rows[0][1].ToString());
                            long tongHoaDon = 0;
                            tbtemp = BUS.ChamCongBUS.GetChamCongByMaCC(ctcc.MaChamCong);
                            string thang = tbtemp.Rows[0][1].ToString();
                            string nam = tbtemp.Rows[0][2].ToString();
                            tbtemp = BUS.NhanVienBUS.GetNhanVienTongHoaDon(manv, thang, nam);
                            if (tbtemp.Rows[0][0].ToString() != "")
                                tongHoaDon = Convert.ToInt64(tbtemp.Rows[0][0].ToString());
                            Stack<long> stk = new Stack<long>();
                            IEnumerable<string> enumer = congThuc.Split(' ');
                            bool isPhuCap = false;
                            bool isHoaDon = false;
                            foreach (string s in enumer)
                            {
                                if (s == "")
                                    break;
                                if (IsOperand(s))
                                {
                                    switch (s)
                                    {
                                        case "A":
                                            stk.Push(luongCB);
                                            break;
                                        case "B":
                                            stk.Push(ctcc.NgayCong);
                                            break;
                                        case "C":
                                            stk.Push(phucCap);
                                            isPhuCap = true;
                                            break;
                                        case "D":
                                            stk.Push(tongHoaDon);
                                            isHoaDon = true;
                                            break;
                                        default:
                                            stk.Push(long.Parse(s));
                                            break;
                                    }
                                }
                                else
                                {
                                    long x = stk.Pop();
                                    long y = stk.Pop();

                                    switch (s)
                                    {
                                        case "+": y += x; break;
                                        case "-": y -= x; break;
                                        case "*": y *= x; break;
                                        case "/": y /= x; break;
                                        case "%": y %= x; break;
                                    }
                                    stk.Push(y);
                                }
                            }
                            
                            long tongLuongChuaThue = stk.Pop();
                            if (isPhuCap == true)
                                tongLuongChuaThue -= phucCap;
                            if (isHoaDon == true)
                                tongLuongChuaThue -= tongHoaDon;
                            long tongLuongDaThue = 0;
                            long thue = 0;
                            if (tongLuongChuaThue <= 5000000)
                            {
                                thue = tongLuongChuaThue * 5 / 100;
                            }
                            else if (tongLuongChuaThue > 5000000 && tongLuongChuaThue <= 10000000)
                            {
                                thue = 250000 + (tongLuongChuaThue - 5000000) * 10 / 100;
                            }
                            else if (tongLuongChuaThue > 10000000 && tongLuongChuaThue <= 18000000)
                            {
                                thue = 750000 + (tongLuongChuaThue - 10000000) * 15 / 100;
                            }
                            else if (tongLuongChuaThue > 18000000 && tongLuongChuaThue <= 32000000)
                            {
                                thue = 1950000 + (tongLuongChuaThue - 18000000) * 20 / 100;
                            }
                            else if (tongLuongChuaThue > 32000000 && tongLuongChuaThue <= 52000000)
                            {
                                thue = 4750000 + (tongLuongChuaThue - 32000000) * 25 / 100;
                            }
                            else if (tongLuongChuaThue > 52000000 && tongLuongChuaThue <= 80000000)
                            {
                                thue = 9750000 + (tongLuongChuaThue - 52000000) * 30 / 100;
                            }
                            else
                            {
                                thue = 18150000 + (tongLuongChuaThue - 80000000) * 35 / 100;
                            }
                            tongLuongDaThue = tongLuongChuaThue - thue;
                            if (isPhuCap == true)
                                tongLuongDaThue += phucCap;
                            if (isHoaDon == true)
                                tongLuongDaThue += tongHoaDon;
                            BUS.BangLuongBUS.AddBangLuong(manv, ctcc.MaChamCong, luongCB.ToString(), phucCap.ToString(), tongHoaDon.ToString(), tongLuongDaThue.ToString());
                            DAO.ChiTietChamCongDAO.UpdateCTCC(ctcc);
                        }
                    }

                    dialogHostWarning.DataContext = "Đã tính lương xong!";
                    dialogHostWarning.IsOpen = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static int GetPriority(string op)
        {
            if (op == "*" || op == "/" || op == "%")
                return 2;
            if (op == "+" || op == "-")
                return 1;
            return 0;
        }
        public static void FormatExpression(ref string expression)
        {
            expression = expression.Replace(" ", "");
            expression = Regex.Replace(expression, @"\+|\-|\*|\/|\%|\^|\)|\(", delegate (Match match)
            {
                return " " + match.Value + " ";
            });
            expression = expression.Replace("  ", " ");
            expression = expression.Trim();
        }

        private static bool IsOperator(string str)
        {
            return Regex.Match(str, @"\+|\-|\*|\/|\%").Success;
        }
        public static bool IsOperand(string str)
        {
            return Regex.Match(str, @"^\d+$|^([a-z]|[A-Z])$").Success;
        }

        public static string Infix2Postfix(string infix)
        {
            FormatExpression(ref infix);

            IEnumerable<string> str = infix.Split(' ');
            Stack<string> stack = new Stack<string>();
            StringBuilder postfix = new StringBuilder();

            foreach (string s in str)
            {
                if (IsOperand(s))
                    postfix.Append(s).Append(" ");
                else if (s == "(")
                    stack.Push(s);
                else if (s == ")")
                {
                    string x = stack.Pop();
                    while (x != "(")
                    {
                        postfix.Append(x).Append(" ");
                        x = stack.Pop();
                    }
                }
                else
                {
                    while (stack.Count > 0 && GetPriority(s) <= GetPriority(stack.Peek()))
                        postfix.Append(stack.Pop()).Append(" ");
                    stack.Push(s);
                }
            }

            while (stack.Count > 0)
                postfix.Append(stack.Pop()).Append(" ");

            return postfix.ToString();
        }

        private void dataGridNhanVien_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(dataGridNhanVien.SelectedItem !=null)
            {
                DataRowView rv = (dataGridNhanVien.SelectedItems[0] as DataRowView);
                string manv = rv[0].ToString();
                dataGridSalary.DataContext = BUS.BangLuongBUS.GetBangLuong(manv);
            }
        }
    }
}
