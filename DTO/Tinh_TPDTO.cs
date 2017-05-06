using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Tinh_TPDTO
    {
        string _maTinh, _tenTinh, _maQG;

        public string MaTinh { get => _maTinh; set => _maTinh = value; }
        public string TenTinh { get => _tenTinh; set => _tenTinh = value; }
        public string MaQG { get => _maQG; set => _maQG = value; }
    }
}
