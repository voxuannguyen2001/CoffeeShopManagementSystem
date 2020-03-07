using QuanLyQuanCafe.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafeteria_Management_Application.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;
        public static BillDAO Instance {
            get
            {
                if(instance == null)
                instance = new BillDAO();
                return instance;
            }
            set => instance = value; 
        }
        /// <summary>
        /// Thành công: Bill Id
        /// Thất bại: -1
        /// </summary>
        /// <param name="TableId"></param>
        /// <returns></returns>
        public int GetUncheckedBillByTableId(int TableId)
        {   
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT id FROM dbo.Bill WHERE idTable = " + TableId.ToString()+ " AND status = 0");
            if (data.Rows.Count > 0)
            {
                return (int)data.Rows[0]["id"];
            }
            return -1;
        }
        public void InsertBill(int idTable)
        {
            string query = "UPDATE dbo.TableFood SET status = N'Có người' WHERE id = " + idTable.ToString();

            DataProvider.Instance.ExecuteQuery("EXEC dbo.USP_InsertBill @idTable = " + idTable.ToString());
            DataProvider.Instance.ExecuteQuery(query);
        }

        public void BillCheckout(int idTable, int discount, float total)
        {
            string query = "EXEC dbo.USP_Checkout @idTable , @discount , @totalPrice ";
            DataProvider.Instance.ExecuteQuery(query, new object[] {idTable, discount, total});
        }
        public void SwitchBill (int idTable1, int idTable2)
        {
            string query = "EXEC dbo.USP_SwitchTable @idTable1 , @idTable2 ";
            DataProvider.Instance.ExecuteQuery(query, new object[] { idTable1, idTable2 });
        }
        public DataTable GetListBillByDate(DateTime checkIn, DateTime checkOut)
        {
            string query = "EXEC dbo.USP_GetListBillByDate @checkIn , @checkOut ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { checkIn, checkOut });
            return data;
        }

    }
}
