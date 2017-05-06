using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LoaiCongThucDTO
    {
        int _maLoaiCT;
        string _tenLoai;

        public int MaLoaiCT { get => _maLoaiCT; set => _maLoaiCT = value; }
        public string TenLoai { get => _tenLoai; set => _tenLoai = value; }
    }
}
