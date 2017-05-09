using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class QuocGiaBUS
    {
        public static DataTable GetQuocGia()
        {
            return DAO.QuocGiaDAO.GetQuocGia();
        }
    }
}
