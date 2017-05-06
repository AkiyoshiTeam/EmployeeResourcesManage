using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TonGiaoDTO
    {
        string _maTG, _tenTG;

        public string MaTG
        {
            get => _maTG;
            set => _maTG = value;
        }
        public string TenTG
        {
            get => _tenTG;
            set => _tenTG = value;
        }
    }
}
