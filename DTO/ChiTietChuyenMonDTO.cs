using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietChuyenMonDTO
    {
        string _maCTCM, _maNV, _maCM, _Truong;
        DateTime _ngayCap;
        public string MaCTCM
        {
            get => _maCTCM;
            set => _maCTCM = value;
        }
        public string MaNV
        {
            get => _maNV;
            set => _maNV = value;
        }
        public string MaCM
        {
            get => _maCM;
            set => _maCM = value;
        }
        public string Truong
        {
            get => _Truong;
            set => _Truong = value;
        }
        public DateTime NgayCap
        {
            get => _ngayCap;
            set => _ngayCap = value;
        }

    }
}
