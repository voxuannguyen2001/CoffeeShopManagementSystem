using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafeteria_Management_Application.DTO
{
    public class Table
    {
        private int id;
        private string name;
        private string status;

        public static int TABLE_HEIGHT = 90;
        public static int TABLE_WIDTH = 90;

        public string Name { get => name; set => name = value; }
        public string Status { get => status; set => status = value; }
        public int Id { get => id; set => id = value; }
        public Table(int _id, string _name, string _status)
        {
            this.Id = _id;
            this.Name = _name;
            this.Status = _status;
        }
        public Table(DataRow dataRow)
        {
            this.Id = (int)dataRow["id"];
            this.Status = dataRow["status"].ToString();
            this.Name = dataRow["name"].ToString();
        }
    }
}
