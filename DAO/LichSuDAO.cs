using Lap6.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberNet.DAO
{
    internal class LichSuDAO
    {
        DataProvider dataProvider = new DataProvider();
        public DataTable checkLS(string username)
        {
            string sql = "select * from LichSu where user_name = '" + username + "'";
            return dataProvider.executeQuery(sql);
        }

        public void insertRecharge(string username, int money)
        {
            string sql = "insert into RechargeHistory values('" + username + "'," + money + ",GETDATE())";
            dataProvider.executeNonQuery(sql);
        }
    }
}
