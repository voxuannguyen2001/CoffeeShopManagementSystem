using Cafeteria_Management_Application.DTO;
using QuanLyQuanCafe.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafeteria_Management_Application.DAO
{
    public class MenuDAO
    {
        private static MenuDAO instance;

        public static MenuDAO Instance {
            get
            {
                if (instance == null) instance = new MenuDAO();
                return instance;
            }
            private set => instance = value; 
        }
        public MenuDAO() { }
        
        public List<MenuClass> getMenu(int id)
        {
            List<MenuClass> menuList = new List<MenuClass>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT f.name, bi.count , f.price , f.price * bi.count AS total FROM dbo.Food AS f, dbo.BillInfo AS bi, dbo.Bill as b WHERE b.idTable = " + id.ToString() + " AND f.id = bi.idFood AND bi.idBill = b.id AND b.status = 0 ");
            foreach (DataRow item in data.Rows)
            {
                MenuClass menu = new MenuClass(item);
                menuList.Add(menu);
            }
            return menuList;
        }
    }
}
