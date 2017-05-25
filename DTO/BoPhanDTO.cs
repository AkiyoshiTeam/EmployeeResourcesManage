using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BoPhanDTO
    {
        string _maBP, _tenBP, _truongBP, _maTT;
        public string MaBP
        {
            get => _maBP;
            set => _maBP = value;
        }
        public string TenBP
        {
            get => _tenBP;
            set => _tenBP = value;
        }
        public string TruongBP
        {
            get => _truongBP;
            set => _truongBP = value;
        }
        public string MaTT { get => _maTT; set => _maTT = value; }
    }
}
