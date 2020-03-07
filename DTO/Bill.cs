﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafeteria_Management_Application.DTO
{
    public class Bill
    {
        private int id;
        private DateTime? dateCheckIn;
        private DateTime? dateCheckOut;
        private int status;
        private int discount;
        public int Id { get => id; set => id = value; }
   
        public int Status { get => status; set => status = value; }
        public int Discount { get => discount; set => discount = value; }
        public DateTime? DateCheckIn { get => dateCheckIn; set => dateCheckIn = value; }
        public DateTime? DateCheckOut { get => dateCheckOut; set => dateCheckOut = value; }

        public Bill(DataRow row)
        {
            this.Id = (int) row["id"];
            this.DateCheckIn = (DateTime?)row["DateCheckIn"];
            this.DateCheckOut = (DateTime?)row["DateCheckOut"];
            this.Status = (int)row["status"];
            this.Discount = (int)row["discount"];
        }
    }
}
