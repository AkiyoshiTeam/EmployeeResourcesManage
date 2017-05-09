using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class DanTocDTO
    {
        private string _MaDT;
        private string _TenDT;

        public string MaDT { get => _MaDT; set => _MaDT = value; }
        public string TenDT { get => _TenDT; set => _TenDT = value; }
    }
}
