using Cafeteria_Management_Application.DAO;
using Cafeteria_Management_Application.DTO;
using QuanLyQuanCafe.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafeteria_Management_Application
{
    public partial class Admin : Form
    {
        private event EventHandler editFood;
        public event EventHandler EditFood
        {
            add
            {
                editFood += value;
            }
            remove
            {
                editFood -= value;
            }
        }
        BindingSource foodList = new BindingSource();
        BindingSource accountList = new BindingSource();
        BindingSource categoryList = new BindingSource();
        BindingSource tableList = new BindingSource();
        private Account loginAccount;

        public Account LoginAccount { get => loginAccount; set => loginAccount = value; }

        public Admin()
        {
            InitializeComponent();
            LoadForm();
        }
        #region Methods
        
        public void AddFoodBinding()
        {
            txbFoodId.DataBindings.Add(new Binding("Text", dgvFood.DataSource, "id", true, DataSourceUpdateMode.Never));
            txtbFoodName.DataBindings.Add(new Binding("Text", dgvFood.DataSource, "name", true, DataSourceUpdateMode.Never));
            nmPrice.DataBindings.Add(new Binding("Value", dgvFood.DataSource, "price", true, DataSourceUpdateMode.Never));            
        }
        public void LoadForm()
        {
            dgvCategory.DataSource = categoryList;
            LoadCategoryList();
            dgvCategory.Columns[0].HeaderText = "Id";
            dgvCategory.Columns[1].HeaderText = "Tên danh mục";

            dgvFood.DataSource = foodList;
            LoadFood();
            dgvFood.Columns[0].HeaderText = "Id";
            dgvFood.Columns[1].HeaderText = "Tên món ăn";
            dgvFood.Columns[2].HeaderText = "Danh mục";
            dgvFood.Columns[3].HeaderText = "Đơn giá";

            dgvAccount.DataSource = accountList;

            dgvTable.DataSource = tableList;
            LoadTableList();

            LoadDefaultDateTime();
            LoadListBill(dtpFromDate.Value, dtpToDate.Value);
            LoadCategory(cbFoodCategory);
            LoadAccountList();
            AddFoodBinding();
            AddAccountBinding();
            AddCategoryBinding();
            AddTableBinding();
        }
        public void AddTableBinding()
        {
            txtbTableId.DataBindings.Add("Text", dgvTable.DataSource, "id", true, DataSourceUpdateMode.Never);
            txtbTableName.DataBindings.Add("Text", dgvTable.DataSource, "name", true, DataSourceUpdateMode.Never);
            txtbTableStatus.DataBindings.Add("Text", dgvTable.DataSource, "status", true, DataSourceUpdateMode.Never);

        }
        public void AddAccountBinding()
        {
            txtbUserName.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            txtbDisplayName.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));
            nmType.DataBindings.Add(new Binding("Value", dgvAccount.DataSource, "Type", true, DataSourceUpdateMode.Never));

        }
        public void LoadCategory(ComboBox cb)
        {
            cb.DataSource = CategoryDAO.Instance.getCategoryList();
            cb.DisplayMember = "name";
        }
        public void LoadDefaultDateTime()
        {
            DateTime date = DateTime.Now;
            dtpFromDate.Value = new DateTime(date.Year, date.Month, 1);
            dtpToDate.Value = dtpFromDate.Value.AddMonths(1).AddDays(-1);

        }
        public void LoadListBill(DateTime checkIn, DateTime checkOut)
        {
            DataTable data = BillDAO.Instance.GetListBillByDate(checkIn, checkOut);
            dtgvBill.DataSource = data;
        }
        public void LoadFood()
        {
           foodList.DataSource = FoodDAO.Instance.GetListFood();
        }
        public List<Food> SearchFoodByName(string name)
        {
            return FoodDAO.Instance.FindFoodByName(name);
        }
        public void LoadAccountList()
        {
            accountList.DataSource = AccountDAO.Instance.GetAccountList();
        }
        public void LoadCategoryList()
        {
            categoryList.DataSource = CategoryDAO.Instance.getCategoryList();
        }
        public void AddCategoryBinding()
        {
            txtbCategory.DataBindings.Add("Text", dgvCategory.DataSource, "name", true, DataSourceUpdateMode.Never);
            txtbCategoryId.DataBindings.Add("Text", dgvCategory.DataSource, "id", true, DataSourceUpdateMode.Never);

        }
        public void LoadTableList()
        {
            tableList.DataSource = TableDAO.Instance.LoadTableData();
        }
        #endregion

        #region Events


        private void btnAddTable_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtbTableId.Text);
            string tableName = txtbTableName.Text;
            if (TableDAO.Instance.AddNewTable(tableName))
            {
                MessageBox.Show("Thêm bàn thành công", "Thông báo");
                LoadTableList();
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm bàn");
            }
        }

        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtbTableId.Text);
            string tableName = txtbTableName.Text;
            if (TableDAO.Instance.DeleteTable(id))
            {
                MessageBox.Show("Xóa bàn thành công", "Thông báo");
                LoadTableList();

            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa bàn");
            }
        }
    

        private void btnShowTable_Click(object sender, EventArgs e)
        {
            LoadTableList();
        }

        private void btnEditTable_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtbTableId.Text);
            string tableName = txtbTableName.Text;
            if (TableDAO.Instance.EditTable(id, tableName))
            {
                MessageBox.Show("Sửa bàn thành công", "Thông báo");
                LoadTableList();
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa bàn");
            }
        }
        private void btnShowCategory_Click(object sender, EventArgs e)
        {
            LoadCategoryList();
        }
        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            string UserName = txtbUserName.Text;
            string DisplayName = txtbDisplayName.Text;
            int Type = (int)nmType.Value;
            if(AccountDAO.Instance.AddNewAcount(UserName, DisplayName, Type))
            {
                MessageBox.Show("Thêm tài khoản thành công", "Thông báo");
                LoadAccountList();
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm tài khoản");
            }
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            string UserName = txtbUserName.Text;
            if (loginAccount.UserName.Equals(UserName))
            {
                MessageBox.Show("Không thể xóa tài khoản đang đăng nhập", "Thông báo");
                return;
            }
            if (AccountDAO.Instance.DeleteAccount(UserName))
            {
                MessageBox.Show("Xóa tài khoản thành công", "Thông báo");
                LoadAccountList();
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa tài khoản");
            }
        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            string UserName = txtbUserName.Text;
            string DisplayName = txtbDisplayName.Text;
            int Type = (int)nmType.Value;
            if (AccountDAO.Instance.EditAccount(UserName, DisplayName, Type))
            {
                MessageBox.Show("Sửa tài khoản thành công", "Thông báo");
                LoadAccountList();
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa tài khoản");
            }
        }

        private void btnViewAccount_Click(object sender, EventArgs e)
        {
            LoadAccountList();
        }
        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            string UserName = txtbUserName.Text;
            if (AccountDAO.Instance.ResetPassword(UserName))
            {
                MessageBox.Show("Cập nhật mật khẩu thành công", "Thông báo");
                LoadAccountList();
            }
            else
            {
                MessageBox.Show("Có lỗi khi cập nhật mật khẩu");
            }
        }
        private void btnViewBill_Click(object sender, EventArgs e)
        {
            LoadListBill(dtpFromDate.Value, dtpToDate.Value);
        }

        private void btnShowFood_Click(object sender, EventArgs e)
        {
            LoadFood();
        }
        private void txbFoodId_TextChanged(object sender, EventArgs e)
        {
            if (dgvFood.SelectedCells.Count > 0)
            {
                int id = (int)dgvFood.SelectedCells[0].OwningRow.Cells["idCategory"].Value;
                foreach (Category item in cbFoodCategory.Items)
                {
                    if (item.Id == id)
                    {
                        cbFoodCategory.SelectedItem = item;
                        break;
                    }
                }
            }
        }
        private void btnAddFood_Click(object sender, EventArgs e)
        {
            string name = txtbFoodName.Text;
            int idCategory = (cbFoodCategory.SelectedItem as Category).Id;
            float price = (float)nmPrice.Value;
            if (FoodDAO.Instance.AddNewFood(name, idCategory, price))
            {
                MessageBox.Show("Thêm thức ăn thành công!", "Thông báo");
                LoadFood();
                editFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm thức ăn!", "Thông báo");
            }
        }
        private void btnEditFood_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbFoodId.Text);
            string name = txtbFoodName.Text;
            int idCategory = (cbFoodCategory.SelectedItem as Category).Id;
            float price = (float)nmPrice.Value;
            if (FoodDAO.Instance.EditFood(id, name, idCategory, price))
            {
                MessageBox.Show("Thay đổi thức ăn thành công!", "Thông báo");
                LoadFood();
                if (editFood != null)
                {
                    editFood(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Có lỗi khi thay đổi thức ăn!", "Thông báo");
            }
        }
        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbFoodId.Text);
            if (MessageBox.Show(String.Format("Bạn có muốn xóa món {0} hay không?", txtbFoodName.Text), "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (FoodDAO.Instance.DeleteFood(id))
                {
                    MessageBox.Show("Xóa thức ăn thành công!", "Thông báo");
                    LoadFood();
                    editFood(this, new EventArgs());
                }
                else
                {
                    MessageBox.Show("Có lỗi khi xóa thức ăn!", "Thông báo");
                }
            }
        }
        private void btnSearchFood_Click(object sender, EventArgs e)
        {
            foodList.DataSource = SearchFoodByName(txtbSearchFood.Text);
        }
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            string name = txtbCategory.Text;
            if (CategoryDAO.Instance.AddNewCategory(name))
            {
                MessageBox.Show("Thêm danh mục thành công!", "Thông báo");
                LoadCategoryList();
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm danh mục!", "Thông báo");
            }
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            string name = txtbCategory.Text;
            int id = Convert.ToInt32(txtbCategoryId.Text);
            if (MessageBox.Show(String.Format("Bạn có muốn xóa danh mục {0} hay không? Tất cả các món ăn liên quan sẽ bị xóa", txtbCategory.Text), "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (CategoryDAO.Instance.DeleteCategory(id))
                {
                    MessageBox.Show("Xóa danh mục thành công!", "Thông báo");
                    LoadCategoryList();
                }
                else
                {
                    MessageBox.Show("Có lỗi khi xóa danh mục!", "Thông báo");
                }
            }
        }

        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            string name = txtbCategory.Text;
            int id = Convert.ToInt32(txtbCategoryId.Text);
            if (CategoryDAO.Instance.EditCategory(name, id))
            {
                MessageBox.Show("Thay đổi danh mục thành công!", "Thông báo");
                LoadCategory(cbFoodCategory);
                LoadCategoryList();
            }
            else
            {
                MessageBox.Show("Có lỗi khi thay đổi danh mục!", "Thông báo");
            }
        }

        #endregion

    }
}
