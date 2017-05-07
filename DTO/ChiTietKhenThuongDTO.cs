using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class ChiTietKhenThuongDTO
    {
        string _soQD, _maNV, _noiDung, _hinhThuc, _maKT;
        DateTime _ngayQD;
        public string SoQD
        {
            get => _soQD;
            set => _soQD = value;
        }
        public string MaNV
        {
            get => _maNV;
            set => _maNV = value;
        }
        public string NoiDung
        {
            get => _noiDung;
            set => _noiDung = value;
        }
        public string HinhThuc
        {
            get => _hinhThuc;
            set => _hinhThuc = value;
        }
        public string MaKT
        {
            get => _maKT;
            set => _maKT = value;
        }
        public DateTime NgayQD
        {
            get => _ngayQD;
            set => _ngayQD = value;
        }
    }
}
