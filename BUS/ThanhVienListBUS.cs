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
    internal class ThanhVienListBUS
    {
        public ThanhVienDTO info { get; set; }
        private ThanhVienListDAO thanhVienListDAO = new ThanhVienListDAO();

        public DataTable LoadThanhVien()
        {
            return thanhVienListDAO.LoadThanhVien();
        }

        public DataTable SreachThanhVien(string User_Name)
        {
            return thanhVienListDAO.LoadThanhVien(User_Name);
        }

        public DataTable SreachStatusThanhVien(string status)
        {
            return thanhVienListDAO.LoadStatusThanhVien(status);
        }

        public DataTable RechargeHistory(string User_Name)
        {
            return thanhVienListDAO.RechargeHistory(User_Name);


        }

        public DataTable SreachMoney(string User_name)
        {
            return thanhVienListDAO.SreachMoney(User_name);
        }

        public void UpRechargeRequest(string User_Name, int money)
        {
            thanhVienListDAO.UpRechargeRequest(User_Name, money);
        }
        public void Recharge(string User_Name, int money)
        {
            thanhVienListDAO.Recharge(User_Name, money);
        }

        public void insert()
        {
            DateTime date = DateTime.Now;
            thanhVienListDAO.InsertThanhVien(info.user_name, info.password, info.email, info.phone, date);
        }

        public void UpdateRequest(string User_Name)
        {
            thanhVienListDAO.UpdateRequest(User_Name);
        }

        public DataTable LoadRequest()
        {
            return thanhVienListDAO.LoadRequest();
        }

        public void update()
        {
            thanhVienListDAO.UpdateThanhVien(info.user_name, info.password, info.email, info.phone);
        }

        public void delete(string username)
        {
            thanhVienListDAO.DeleteThanhVien(username);
        }
    }
}
