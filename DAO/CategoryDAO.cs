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
    public class CategoryDAO
    {
        private static CategoryDAO instance;

        public static CategoryDAO Instance {
            get
            {
                if (instance == null) instance = new CategoryDAO();
                return instance;
            }
            set => instance = value; 
        }
        public List<Category> getCategoryList()
        {
            List<Category> categoryList = new List<Category>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.FoodCategory");
            foreach (DataRow item in data.Rows)
            {
                Category category = new Category(item);
                categoryList.Add(category);
            }
            return categoryList;
        }
        public bool AddNewCategory(string name)
        {
            string query = string.Format("INSERT dbo.FoodCategory (name) VALUES (N'{0}')", name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool EditCategory(string name, int id)
        {
            string query = string.Format("UPDATE dbo.FoodCategory SET name = N'{0}' WHERE id = {1}", name, id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteCategory(int id)
        {
            FoodDAO.Instance.DeleteFoodByCategoryId(id);
            string query = "DELETE dbo.FoodCategory WHERE id = " + id;
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        //public Category GetCategoryById(int id)
        //{
        //    DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.FoodCategory WHERE id = " + id.ToString());
        //    foreach (DataRow item in data.Rows)
        //    {
        //        return new Category(item);
        //    }
        //    return null;
        //}
    }
}
