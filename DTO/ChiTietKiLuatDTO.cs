using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class ChiTietKiLuatDTO
    {
        string _maCTKL, _maNV, _hinhThuc, _maKL, _nguyenNhan;
        DateTime _ngayKL;
        public string MaCTKL
        {
            get => _maCTKL;
            set => _maCTKL = value;
        }
        public string MaNV
        {
            get => _maNV;
            set => _maNV = value;
        }
        public string HinhThuc
        {
            get => _hinhThuc;
            set => _hinhThuc = value;
        }
        public string MaKL
        {
            get => _maKL;
            set => _maKL = value;
        }
        public string NguyenNhan
        {
            get => _nguyenNhan;
            set => _nguyenNhan = value;
        }
        public DateTime NgayKL
        {
            get => _ngayKL;
            set => _ngayKL = value;
        }
    }
}
