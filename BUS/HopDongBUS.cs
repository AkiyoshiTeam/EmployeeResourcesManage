using DTO;
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
        public static DataTable GetHopDongAlert(string date)
        {
            return DAO.HopDongDAO.GetHopDongAlert(date);
        }
        public static int GetHopDongCountAlert(string date)
        {
            return DAO.HopDongDAO.GetHopDongCountAlert(date);
        }
        public static void UpdateHopDongTimeOut()
        {
            DAO.HopDongDAO.UpdateHopDongTimeOut();
        }
        public static int GetHopDongCountTimeOut()
        {
            return DAO.HopDongDAO.GetHopDongCountTimeOut();
        }
        public static DataTable GetHopDongTimeOut()
        {
            return DAO.HopDongDAO.GetHopDongTimeOut();
        }
        public static void UpdateTinhTrangHopDongTimeOut(List<string> listMaHD)
        {
            DAO.HopDongDAO.UpdateTinhTrangHopDongTimeOut(listMaHD);
        }
        public static void UpdateTinhTrangTimeOut(string mahd)
        {
            DAO.HopDongDAO.UpdateTinhTrangTimeOut(mahd);
        }
    }
}
