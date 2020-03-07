using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafeteria_Management_Application.DTO
{
    public class MenuClass
    {
        private string foodName;
        private int count;
        private int price;
        private int total;

        public string FoodName { get => foodName; set => foodName = value; }
        public int Count { get => count; set => count = value; }
        public int Price { get => price; set => price = value; }
        public int Total { get => total; set => total = value; }

        public MenuClass(DataRow row)
        {
            this.FoodName = row["name"].ToString();
            this.Count = (int)row["count"];
            this.Price = (int)Convert.ToDouble(row["price"]);
            this.Total = (int)Convert.ToDouble(row["total"]);
        }
    }
}
