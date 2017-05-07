using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class ChucVuDTO
    {
        string _maCV, _tenCV;
        int _luongCB;
        public string MaCV
        {
            get => _maCV;
            set => _maCV = value;
        }
        public string TenCV
        {
            get => _tenCV;
            set => _tenCV = value;
        }
        public int LuongCoBan
        {
            get => _luongCB;
            set => _luongCB = value;
        }
    }
}
