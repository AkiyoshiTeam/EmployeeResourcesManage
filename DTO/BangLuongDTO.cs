using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class BangLuongDTO
    {
        string _maBL, _maNV, _maPB, _maChamCong;
        int _Thang, _Nam, _luongCB, _luongThuong, _phuCap, _tongLuong;

        public string MaBL
        {
            get => _maBL;
            set => _maBL = value;
        }
        public string MaNV
        {
            get => _maNV;
            set => _maNV = value;
        }
        public string MaPB
        {
            get => _maPB;
            set => _maPB = value;
        }
        public string MaChamCong
        {
            get => _maChamCong;
            set => _maChamCong = value;
        }
        public int Thang
        {
            get => _Thang;
            set => _Thang = value;
        }
        public int Nam
        {
            get => _Nam;
            set => _Nam = value;
        }
        public int LuongCoBan
        {
            get => _luongCB;
            set => _luongCB = value;
        }
        public int LuongThuong
        {
            get => _luongThuong;
            set => _luongThuong = value;
        }
        public int PhuCap
        {
            get => _phuCap;
            set => _phuCap = value;
        }
        public int TongLuong
        {
            get => _tongLuong;
            set => _tongLuong = value;
        }

    }
}
