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
    public class BillInfoDAO
    {
        private static BillInfoDAO instance;
        public static BillInfoDAO Instance {
            get
            {
                if (instance == null) instance = new BillInfoDAO();
                return instance;
            }
            private set => instance = value; 
        }
        public BillInfoDAO() { }
        public List<BillInfo> getListBillInfo(int BillId)
        {
            List<BillInfo> ListBillInfo = new List<BillInfo>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.BillInfo WHERE idBill = " + BillId.ToString());
            foreach (DataRow item in data.Rows)
            {
                BillInfo billInfo = new BillInfo(item);
                ListBillInfo.Add(billInfo);
            }
            return ListBillInfo;
        }
        public void InsertBillInfo(int idBill, int idFood, int count)
        {
            string query = "EXEC USP_InsertBillInfo @idBill , @idFood , @count";
            DataProvider.Instance.ExecuteQuery(query, new object[] { idBill, idFood, count });
        }
        public void DeleteBillInfoByFoodId(int id)
        {
            string query = "DELETE dbo.BillInfo WHERE idFood = " + id;
            DataProvider.Instance.ExecuteNonQuery(query);
        }
    }
    
}
