using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Quan_HuyenDTO
    {
        string _maQuan, _tenQuan, _maTinh;

        public string MaQuan { get => _maQuan; set => _maQuan = value; }
        public string TenQuan { get => _tenQuan; set => _tenQuan = value; }
        public string MaTinh { get => _maTinh; set => _maTinh = value; }
    }
}
