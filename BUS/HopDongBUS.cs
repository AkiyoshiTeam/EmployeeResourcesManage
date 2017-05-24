﻿using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class HopDongBUS
    {
        public static DataTable GetHopDong()
        {
            return DAO.HopDongDAO.GetHopDong();
        }
        public static DataTable GetLastHopDong()
        {
            return DAO.HopDongDAO.GetLastHopDong();
        }
        public static void AddHopDong(HopDongDTO hd)
        {
            DAO.HopDongDAO.AddHopDong(hd);
        }
        public static void NewHopDong(HopDongDTO hd)
        {
            DAO.HopDongDAO.NewHopDong(hd);
        }
        public static void AddHopDongMulti(HopDongDTO hd)
        {
            DAO.HopDongDAO.AddHopDongMulti(hd);
        }
    }
}