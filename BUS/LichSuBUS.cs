using CyberNet.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberNet.BUS
{
    internal class LichSuBUS
    {
        private LichSuDAO lichSuDAO = new LichSuDAO();

        public DataTable checkLS(string username)
        {
            return lichSuDAO.checkLS(username);
        }
        public void insertRecharge(string username, int money)
        {
            lichSuDAO.insertRecharge(username, money);
        }
    }
}
