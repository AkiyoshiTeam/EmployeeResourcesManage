using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhanQuyenDTO
    {
        string _maPQ, _tenPQ;

        public string MaPQ { get => _maPQ; set => _maPQ = value; }
        public string TenPQ { get => _tenPQ; set => _tenPQ = value; }
    }
}
