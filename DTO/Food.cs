using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafeteria_Management_Application.DTO
{
    public class Food
    {
        private int id;
        private string name;
        private int idCategory;
        private int price;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int IdCategory { get => idCategory; set => idCategory = value; }
        public int Price { get => price; set => price = value; }

        public Food(DataRow row)
        {
            Id = (int)row["id"];
            Name = row["name"].ToString();
            IdCategory = (int)row["idCategory"];
            Price = Convert.ToInt32(row["price"]);
        }
    }
}
