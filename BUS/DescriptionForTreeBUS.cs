using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class DescriptionForTreeBUS
    {
        public static DataSet GetDescriptionForTree()
        {
            return DAO.DescriptionForTree.GetDescriptionForTree();
        }

    }
}
