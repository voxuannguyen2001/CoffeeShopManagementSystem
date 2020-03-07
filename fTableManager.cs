using Cafeteria_Management_Application.DAO;
using Cafeteria_Management_Application.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using Button = System.Windows.Forms.Button;
using ComboBox = System.Windows.Forms.ComboBox;
using ListViewItem = System.Windows.Forms.ListViewItem;

namespace Cafeteria_Management_Application
{
    public partial class fTableManager : Form
    {
        private List<Button> listBtn = new List<Button>();
        private Account account;

        public Account Account
        {
            get => account;
            set
            {
                account = value;
                ChangeAccount(account.Type);
            }
        }

        public fTableManager(Account _acc)
        {
            InitializeComponent();
            this.Account = _acc;
            LoadTable();
            LoadCategory();
        }
        void ChangeAccount(int type)
        {
            adminToolStripMenuItem.Enabled = (type == 1);
            tàiKhoảnToolStripMenuItem.Text += " ( " + account.DisplayName + " ) ";
        }
        private void LoadTable()
        {
            lsvBill.Tag = null;
            lsvBill.Items.Clear();
            btnAddfood.Tag = null;
            nmDiscount.Value = 0;
            txtbTotal.Text = null;
            flpTable.Controls.Clear();
            List<Table> TableList = TableDAO.Instance.LoadTableData();
            cbSwitchTable.DataSource = TableList;
            cbSwitchTable.DisplayMember = "name";
            foreach (Table item in TableList)
            {
                Button btn = new Button()
                {
                    Width = Table.TABLE_WIDTH,
                    Height = Table.TABLE_WIDTH
                };
                btn.Tag = item;
                btn.Click += Btn_Click;

                DisplayTableStatus(item, btn);

                flpTable.Controls.Add(btn);

                listBtn.Add(btn);
            }
        }
        private void ShowBill(int TableId)
        {
            lsvBill.Items.Clear();
            int totalPrice = 0;
            List<MenuClass> menuList = MenuDAO.Instance.getMenu(TableId);
            foreach (MenuClass item in menuList)
            {
                ListViewItem lvItem = new ListViewItem(item.FoodName);
                lvItem.SubItems.Add(item.Count.ToString());
                lvItem.SubItems.Add(item.Price.ToString());
                lvItem.SubItems.Add(item.Total.ToString());
                lsvBill.Items.Add(lvItem);
                totalPrice += item.Total;
            }
            CultureInfo cultureInfo = new CultureInfo("vi-VN");
            txtbTotal.Text = totalPrice.ToString("c",cultureInfo);
        }
        private void Btn_Click(object sender, EventArgs e)
        {
            int TableId = ((sender as Button).Tag as Table).Id;
            lsvBill.Tag = (sender as Button).Tag as Table;
            btnAddfood.Tag = sender;
            ShowBill(TableId);
            foreach (Button item in listBtn)
            {
                item.FlatStyle = FlatStyle.Standard;
                item.FlatAppearance.BorderSize = 1;
            }
            Button button = sender as Button;
            button.FlatStyle = FlatStyle.Popup;
            button.FlatAppearance.BorderSize = 4;
        }

        private void LoadCategory()
        {
            cbCategory.DataSource = CategoryDAO.Instance.getCategoryList();
            cbCategory.DisplayMember = "name";
        }


        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAccountProfile accountProfile = new fAccountProfile(Account);
            accountProfile.UpdateDisplayName += AccountProfile_UpdateDisplayName;
            accountProfile.ShowDialog();
        }

        private void AccountProfile_UpdateDisplayName(object sender, AccountEvent e)
        {
            tàiKhoảnToolStripMenuItem.Text = "Tài khoản" + " ( " + e.Account.DisplayName + " )";
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            admin.LoginAccount = account;
            admin.EditFood += Admin_EditFood;
            admin.ShowDialog();
        }

        private void Admin_EditFood(object sender, EventArgs e)
        {
            LoadFoodByCategoryId((cbCategory.SelectedItem as Category).Id);
            LoadTable();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (lsvBill.Tag == null)
            {
                MessageBox.Show("Vui lòng chọn bàn","Thông báo");
                return;
            }
            Table table = lsvBill.Tag as Table;
            int id = BillDAO.Instance.GetUncheckedBillByTableId(table.Id);
            if (id != -1)
            {
                double total = Convert.ToDouble(txtbTotal.Text.Split(',')[0].Replace(".", ""));
                int discount = Convert.ToInt32(nmDiscount.Value);
                double discountValue = (double)discount / 100 * total;
                double finalTotal = total - discountValue;
                if (MessageBox.Show(string.Format("Bạn có chắc chắn muốn thanh toán hóa đơn cho {0}\nTổng: {1} \nGiảm giá( {2}% ): {3} \nTiền mặt: {4}", table.Name, total, discount, discountValue, finalTotal),
                    "Thông báo",
                    MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    BillDAO.Instance.BillCheckout(table.Id, discount,(float)finalTotal);
                    txtbTotal.Text = null;
                    nmDiscount.Value = 0;
                    table = TableDAO.Instance.LoadTableByTableId(table.Id);
                    Button btn = btnAddfood.Tag as Button;
                    DisplayTableStatus(table, btn);
                    lsvBill.Items.Clear();
                    lsvBill.Tag = table;
                }
            }
        }
        private void btnAddfood_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;
            if (lsvBill.Tag == null)
            {
                MessageBox.Show("Vui lòng chọn bàn", "Thông báo");
                return;
            }
            Food foodToAdd = cbFood.SelectedItem as Food;
            int TableId = (table).Id;
            int count = (int)nmFoodCount.Value;
            int BillId = BillDAO.Instance.GetUncheckedBillByTableId(TableId);
            if (BillId == -1 && count > 0)
            {
                BillDAO.Instance.InsertBill(TableId);
                BillId = BillDAO.Instance.GetUncheckedBillByTableId(TableId);
            }
            BillInfoDAO.Instance.InsertBillInfo(BillId, foodToAdd.Id, count);
            table = TableDAO.Instance.LoadTableByTableId(TableId);
            Button btn = btnAddfood.Tag as Button;
            DisplayTableStatus(table, btn);
            ShowBill(TableId);
        }
        private void DisplayTableStatus(Table table, Button btn)
        {
            string status = table.Status;
            btn.Text = table.Name + Environment.NewLine + status ;
            if (status == "Trống")
            {
                btn.BackColor = Color.Aqua;
            }
            else btn.BackColor = Color.DeepPink;
        }
        private void LoadFoodByCategoryId(int id)
        {
            cbFood.DataSource = FoodDAO.Instance.getListFoodByCategoryId(id);
            cbFood.DisplayMember = "name";
        }
        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null) return;
            Category category = cb.SelectedItem as Category;
            id = category.Id;
            LoadFoodByCategoryId(id);
        }
        private void btnSwitchTable_Click(object sender, EventArgs e)
        {
            Table table1 = lsvBill.Tag as Table;
            if (table1 == null)
            {
                MessageBox.Show("Vui lòng chọn bàn", "Thông báo");
                return;
            }
            Table table2 = cbSwitchTable.SelectedItem as Table;
            if (MessageBox.Show(String.Format("Bạn có thật sự muốn đổi {0} và {1} không?",table1.Name,table2.Name), "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                BillDAO.Instance.SwitchBill(table1.Id, table2.Id);
                lsvBill.Items.Clear();
                txtbTotal.Text = null;
                LoadTable();
            }
        }
        private void cbSwitchTable_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void flpTable_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lsvBill_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void fTableManager_Load(object sender, EventArgs e)
        {

        }
    }
}
