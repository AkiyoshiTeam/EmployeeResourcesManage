using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LoaiHopDongDTO
    {
        int _maLoaiHD;
        string _tenLoai;

        public int MaLoaiHD { get => _maLoaiHD; set => _maLoaiHD = value; }
        public string TenLoai { get => _tenLoai; set => _tenLoai = value; }
    }
}
