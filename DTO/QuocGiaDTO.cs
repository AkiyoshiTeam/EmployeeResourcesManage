using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class QuocGiaDTO
    {
        string _maQG, _tenQG;

        public string MaQG { get => _maQG; set => _maQG = value; }
        public string TenQG { get => _tenQG; set => _tenQG = value; }
    }
}
