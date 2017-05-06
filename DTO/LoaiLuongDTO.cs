using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LoaiLuongDTO
    {
        string _maLoaiLuong, _tenLoaiLuong;

        public string MaLoaiLuong { get => _maLoaiLuong; set => _maLoaiLuong = value; }
        public string TenLoaiLuong { get => _tenLoaiLuong; set => _tenLoaiLuong = value; }
    }
}
