using CyberNet.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CyberNet.BUS
{
    internal class ThanhVienBUS
    {
        public ThanhVienDTO info { get; set; }
        private ThanhVienDAO thanhVienDAO = new ThanhVienDAO();

        public DataTable LoadThanhVien()
        {
            return thanhVienDAO.LoadThanhVien();
        }

        public DataTable SreachThanhVien(string User_Name)
        {
            return thanhVienDAO.LoadThanhVien(User_Name);
        }

        public DataTable RechargeHistory(string User_Name)
        {
            return thanhVienDAO.RechargeHistory(User_Name);


        }
        
        public void insert()
        {
            DateTime date = DateTime.Now;
              thanhVienDAO.InsertThanhVien(info.user_name, info.password, info.email, info.phone,date);
        }

        public void update()
        {
            thanhVienDAO.UpdateThanhVien(info.user_name, info.password, info.email, info.phone);
        }

        public void delete(string username)
        {
            thanhVienDAO.DeleteThanhVien(username);
        }
    }
}
