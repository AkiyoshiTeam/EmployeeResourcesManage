﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class ChamCongBUS
    {
        public static DataTable GetLastChamCong()
        {
            return DAO.ChamCongDAO.GetLastChamCong();
        }
        public static void AddChamCong(DTO.ChamCongDTO cc)
        {
            DAO.ChamCongDAO.AddChamCong(cc);
        }
        public static bool CheckExistsChamCong(DTO.ChamCongDTO cc)
        {
            return DAO.ChamCongDAO.CheckExistsChamCong(cc);
        }
        public static DataTable GetChamCongByMaCC(string macc)
        {
            return DAO.ChamCongDAO.GetChamCongByMaCC(macc);
        }
    }
}
