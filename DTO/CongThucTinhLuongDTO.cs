using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class CongThucTinhLuongDTO
    {
        private int _ID;
        private string _CongThuc;
        private int _MaLoaiCT;
        private int _LuongCB;
        private int _LuongThuong;
        private int _PhuCap;
        private int _TongLuong;

        public int ID { get => _ID; set => _ID = value; }
        public string CongThuc { get => _CongThuc; set => _CongThuc = value; }
        public int MaLoaiCT { get => _MaLoaiCT; set => _MaLoaiCT = value; }
        public int LuongCB { get => _LuongCB; set => _LuongCB = value; }
        public int LuongThuong { get => _LuongThuong; set => _LuongThuong = value; }
        public int PhuCap { get => _PhuCap; set => _PhuCap = value; }
        public int TongLuong { get => _TongLuong; set => _TongLuong = value; }
    }
}
