using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVienDTO
    {
        string _maNV, _hoTen, _maCV, _maPB, _maHD, _luongCB, _hinhAnh;
        DateTime _ngayVaoLam;
        int _maTT;

        public string MaNV { get => _maNV; set => _maNV = value; }
        public string HoTen { get => _hoTen; set => _hoTen = value; }
        public string MaCV { get => _maCV; set => _maCV = value; }
        public string MaPB { get => _maPB; set => _maPB = value; }
        public string MaHD { get => _maHD; set => _maHD = value; }
        public string LuongCanBan { get => _luongCB; set => _luongCB = value; }
        public string HinhAnh { get => _hinhAnh; set => _hinhAnh = value; }
        public DateTime NgayVaoLam { get => _ngayVaoLam; set => _ngayVaoLam = value; }
        public int MaTT { get => _maTT; set => _maTT = value; }
        
    }
}
