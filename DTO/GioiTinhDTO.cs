using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class GioiTinhDTO
    {
        private bool _MaGT;
        private string _TenGT;

        public bool MaGT { get => _MaGT; set => _MaGT = value; }
        public string TenGT { get => _TenGT; set => _TenGT = value; }
    }
}
