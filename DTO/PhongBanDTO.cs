using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhongBanDTO
    {
        string _maPB, _tenPB, _viTri, _truongPB, _maBP, _maTT;
        long _luongCB;

        public string MaPB { get => _maPB; set => _maPB = value; }
        public string TenPB { get => _tenPB; set => _tenPB = value; }
        public string ViTri { get => _viTri; set => _viTri = value; }
        public string TruongPB { get => _truongPB; set => _truongPB = value; }
        public string MaBP { get => _maBP; set => _maBP = value; }
        public long LuongCB { get => _luongCB; set => _luongCB = value; }
        public string MaTT { get => _maTT; set => _maTT = value; }
    }
}
