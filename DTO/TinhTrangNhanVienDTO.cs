using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TinhTrangNhanVienDTO
    {
        int _maTT;
        string _tenTT;

        public int MaTT { get => _maTT; set => _maTT = value; }
        public string TenTT { get => _tenTT; set => _tenTT = value; }
    }
}
