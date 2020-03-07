using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafeteria_Management_Application.DTO
{
    public class BillInfo
    {
        private int id;
        private int idFood;
        private int idBill;
        private int count;

        public int IdFood { get => idFood; set => idFood = value; }
        public int IdBill { get => idBill; set => idBill = value; }
        public int Count { get => count; set => count = value; }
        public int Id { get => id; set => id = value; }

        public BillInfo() { }
        public BillInfo(int _id, int _idFood, int _idBill, int _count)
        {
            this.Count = _count;
            this.IdBill = _idBill;
            this.IdFood = _idFood;
            this.id = _id;
        }
        
        public BillInfo(DataRow row)
        {
            this.Count = (int)row["count"];
            this.Id = (int)row["id"];
            this.IdBill = (int)row["idBill"];
            this.IdFood = (int)row["idFood"];
        }
    }
}
