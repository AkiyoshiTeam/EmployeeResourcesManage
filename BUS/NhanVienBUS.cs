﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Collections;

namespace BUS
{
    public class NhanVienBUS
    {
        public static IEnumerable GetNhanVien()
        {
            return DAO.NhanVienDAO.GetNhanVien();
        }
    }
}