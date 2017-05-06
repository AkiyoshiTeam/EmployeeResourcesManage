using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ThongTinChiTietNhanVienDTO
    {
        string _maNV,_cMND,_noiSinh,_dienThoai,_soNha,_duong,_phuongXa,_quanHuyen,_tinhTP,_quocGia,_maDT,_maTG,_soTheATM;
        bool _maGT;
        DateTime _ngaySinh;

        public string MaNV { get => _maNV; set => _maNV = value; }
        public string CMND { get => _cMND; set => _cMND = value; }
        public string NoiSinh { get => _noiSinh; set => _noiSinh = value; }
        public string DienThoai { get => _dienThoai; set => _dienThoai = value; }
        public string SoNha { get => _soNha; set => _soNha = value; }
        public string Duong { get => _duong; set => _duong = value; }
        public string PhuongXa { get => _phuongXa; set => _phuongXa = value; }
        public string QuanHuyen { get => _quanHuyen; set => _quanHuyen = value; }
        public string TinhTP { get => _tinhTP; set => _tinhTP = value; }
        public string QuocGia { get => _quocGia; set => _quocGia = value; }
        public string MaDT { get => _maDT; set => _maDT = value; }
        public string MaTG { get => _maTG; set => _maTG = value; }
        public string SoTheATM { get => _soTheATM; set => _soTheATM = value; }
        public bool MaGT { get => _maGT; set => _maGT = value; }
        public DateTime NgaySinh { get => _ngaySinh; set => _ngaySinh = value; }
    }
}
