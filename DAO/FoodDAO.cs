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
    public class FoodDAO
    {
        private static FoodDAO instance;
        public static FoodDAO Instance {
            get
            {
                if (instance == null) instance = new FoodDAO();
                return instance;
            }
            set => instance = value; 
        }

        public List<Food> getListFoodByCategoryId(int id)
        {
            List<Food> listFood = new List<Food>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Food WHERE idCategory = " + id.ToString());
            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                listFood.Add(food);
            }
            return listFood;
        }
        public List<Food> GetListFood()
        {
            List<Food> listFood = new List<Food>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Food");
            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                listFood.Add(food);
            }
            return listFood;
        }
        public bool AddNewFood(string name, int idCategory, float price)
        {
            string query = string.Format("INSERT dbo.Food (name, idCategory, price) VALUES (N'{0}', {1}, {2})", name, idCategory, price);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool EditFood(int id , string name, int idCategory, float price)
        {
            string query = string.Format("UPDATE dbo.Food SET name = N'{0}', idCategory = {1}, price = {2} WHERE id = {3}", name, idCategory, price, id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteFood(int id)
        {
            BillInfoDAO.Instance.DeleteBillInfoByFoodId(id);
            string query = "DELETE dbo.Food WHERE id = " + id;
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public List<Food> FindFoodByName(string name)
        {
            List<Food> listFood = new List<Food>();
            DataTable data = DataProvider.Instance.ExecuteQuery(String.Format("SELECT * FROM dbo.Food WHERE dbo.GetUnsignString(name) like N'%' + dbo.GetUnsignString(N'{0}') +N'%'",name));
            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                listFood.Add(food);
            }
            return listFood;
        }
        public void DeleteFoodByCategoryId(int id)
        {
            DataProvider.Instance.ExecuteQuery("DELETE FROM dbo.Food WHERE idCategory = " + id);
        }
    }
}
