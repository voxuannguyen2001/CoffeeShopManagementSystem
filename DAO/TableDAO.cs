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
    public class TableDAO
    {
        private static TableDAO instance;

        public static TableDAO Instance 
        {
            get
            {
                if(instance == null)
                {
                    instance = new TableDAO();
                }
                return instance;
            }
            private set => instance = value; 
        }
        public TableDAO() { }
        public List<Table> LoadTableData()
        {
            List<Table> tableList = new List<Table>();
            string query = "EXEC dbo.USP_GetTableList";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                tableList.Add(table);
            }
            return tableList;
        }
        public Table LoadTableByTableId(int id)
        {
            string query = "SELECT * FROM dbo.TableFood WHERE id = " + id.ToString();
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            Table table = new Table(data.Rows[0]);
            return table;
        }
        public bool AddNewTable(string name)
        {
            string query = string.Format("INSERT dbo.TableFood (name) VALUES(N'{0}')", name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool EditTable(int id, string name)
        {
            string query = string.Format("UPDATE dbo.TableFood SET name = N'{0}' WHERE id = {1}", name, id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteTable(int id)
        {
            BillInfoDAO.Instance.DeleteBillInfoByFoodId(id);
            string query = "DELETE dbo.TableFood WHERE id = " + id;
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
