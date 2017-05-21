using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HopDongDTO
    {
        private string _MaHD;
        private int _MaLoaiHD;
        private DateTime _NgayKyHD;
        private string _maNV;
        private DateTime _ngayHetHan;
        private int _maTTHD;

        public string MaHD { get => _MaHD; set => _MaHD = value; }
        public int MaLoaiHD { get => _MaLoaiHD; set => _MaLoaiHD = value; }
        public DateTime NgayKyHD { get => _NgayKyHD; set => _NgayKyHD = value; }
        public int MaTTHD { get => _maTTHD; set => _maTTHD = value; }
        public DateTime NgayHetHan { get => _ngayHetHan; set => _ngayHetHan = value; }
        public string MaNV { get => _maNV; set => _maNV = value; }
    }
}
