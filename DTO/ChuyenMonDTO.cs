using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChuyenMonDTO
    {
        private string _MaCM;
        private string _TenCM;

        public string MaCM { get => _MaCM; set => _MaCM = value; }
        public string TenCM { get => _TenCM; set => _TenCM = value; }
    }
}
