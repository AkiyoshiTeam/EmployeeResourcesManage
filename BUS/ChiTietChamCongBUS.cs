using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class ChiTietChamCongBUS
    {
        public static void AddCTCC(DataTable dt, string macc)
        {
            DAO.ChiTietChamCongDAO.AddCTCC(dt, macc);
        }
        public static DataTable GetCTCCByMANV(string manv)
        {
            return DAO.ChiTietChamCongDAO.GetCTCCByMANV(manv);
        }
        public static void UpdateCTCC(DTO.ChiTietChamCongDTO ctcc)
        {
            DAO.ChiTietChamCongDAO.UpdateCTCC(ctcc);
        }
    }
}
