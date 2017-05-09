using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class HopDongDTO
    {
        private string _MaHD;
        private int _MaLoaiHD;
        private DateTime _NgayKyHD;

        public string MaHD { get => _MaHD; set => _MaHD = value; }
        public int MaLoaiHD { get => _MaLoaiHD; set => _MaLoaiHD = value; }
        public DateTime NgayKyHD { get => _NgayKyHD; set => _NgayKyHD = value; }
    }
}
