using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietChamCongDTO
    {
        string _maChamCong, _maNV;
        int _ngayCong, _trangThai;
        public string MaChamCong
        {
            get => _maChamCong;
            set => _maChamCong = value;
        }
        public string MaNV
        {
            get => _maNV;
            set => _maNV = value;
        }
        public int NgayCong
        {
            get => _ngayCong;
            set => _ngayCong = value;
        }
        public int TrangThai
        {
            get => _trangThai;
            set => _trangThai = value;
        }
    }
}
