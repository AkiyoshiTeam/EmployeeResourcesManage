using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class ChuyenCongTacDTO
    {
        private string _MaChuyen;
        private string _MaNV;
        private DateTime _NgayChuyen;
        private string _MaCVCu;
        private string _MaPBCu;
        private string _MaCVMoi;
        private string _MaPBMoi;

        public string MaChuyen { get => _MaChuyen; set => _MaChuyen = value; }
        public string MaNV { get => _MaNV; set => _MaNV = value; }
        public DateTime NgayChuyen { get => _NgayChuyen; set => _NgayChuyen = value; }
        public string MaCVCu { get => _MaCVCu; set => _MaCVCu = value; }
        public string MaPBCu { get => _MaPBCu; set => _MaPBCu = value; }
        public string MaCVMoi { get => _MaCVMoi; set => _MaCVMoi = value; }
        public string MaPBMoi { get => _MaPBMoi; set => _MaPBMoi = value; }
    }
}
