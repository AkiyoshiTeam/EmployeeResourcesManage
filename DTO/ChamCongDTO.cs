using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChamCongDTO
    {
        string _maChamCong;
        int _Nam, _Thang;
        DateTime _ngayPhatLuong;
        public string MaChamCong
        {
            get => _maChamCong;
            set => _maChamCong = value;
        }
        public int Thang
        {
            get => _Thang;
            set => _Thang = value;
        }
        public int Nam
        {
            get => _Nam;
            set => _Nam = value;
        }
        public DateTime NgayPhatLuong
        {
            get => _ngayPhatLuong;
            set => _ngayPhatLuong = value;
        }
    }
}
