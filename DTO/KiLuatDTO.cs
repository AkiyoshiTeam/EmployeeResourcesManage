using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KiLuatDTO
    {
        string _maKL, _tenKL;

        public string MaKL { get => _maKL; set => _maKL = value; }
        public string TenKL { get => _tenKL; set => _tenKL = value; }
    }
}
