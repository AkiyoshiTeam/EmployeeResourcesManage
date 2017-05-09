using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class KhenThuongDTO
    {
        private string _MaKT;
        private string _TenKT;

        public string MaKT { get => _MaKT; set => _MaKT = value; }
        public string TenKT { get => _TenKT; set => _TenKT = value; }
    }
}
