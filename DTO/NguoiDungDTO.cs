using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NguoiDungDTO
    {
        string _maUser, _maNV, _maPQ, _username, _password;

        public string MaUser { get => _maUser; set => _maUser = value; }
        public string MaNV { get => _maNV; set => _maNV = value; }
        public string MaPQ { get => _maPQ; set => _maPQ = value; }
        public string Username { get => _username; set => _username = value; }
        public string Password { get => _password; set => _password = value; }
    }
}
