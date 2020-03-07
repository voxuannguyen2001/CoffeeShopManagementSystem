using Cafeteria_Management_Application.DAO;
using Cafeteria_Management_Application.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafeteria_Management_Application
{
    public partial class fAccountProfile : Form
    {
        private event EventHandler<AccountEvent> updateDisplayName;
        public event EventHandler<AccountEvent> UpdateDisplayName
        {
            add
            {
                updateDisplayName += value;
            }
            remove
            {
                updateDisplayName -= value;
            }
        }
        private Account loginAccount;

        public Account LoginAccount { get => loginAccount;
            set 
            {
                loginAccount = value;
                LoadUser(loginAccount);
            }
        }
        public void UpdateInfo()
        {
            string displayName = txtbDisplayName.Text;
            string password = txtbPassword.Text;
            string newPassword = txtbNewPassword.Text;
            string reEnterPass = txtbReEnterPassword.Text;
            string userName = txtbUserName.Text;
            if (!newPassword.Equals(reEnterPass))
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu đúng với mật khẩu mới", "Thông báo");
            }
            else
            {
                string hashPass = AccountDAO.Instance.GetHashData(password);
                string hashNewPass = AccountDAO.Instance.GetHashData(newPassword);
                if (AccountDAO.Instance.UpdateAccount(userName, displayName, hashPass , hashNewPass))
                {
                    MessageBox.Show("Cập nhật tài khoản thành công");
                    if (updateDisplayName != null)
                    {
                        updateDisplayName(this, new AccountEvent(loginAccount));
                    }
                }
                else
                {
                    MessageBox.Show("Mật khẩu không chính xác. Vui lòng nhập lại mật khẩu", "Thông báo");
                }
            }
        }
        public fAccountProfile(Account account)
        {
            InitializeComponent();
            LoginAccount = account;
        }
        public void LoadUser(Account account)
        {
            txtbDisplayName.Text = account.DisplayName;
            txtbUserName.Text = account.UserName;
        }
        private void fAccountProfile_Load(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateInfo();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    public class AccountEvent : EventArgs
    {
        private Account account;
        public AccountEvent(Account acc)
        {
            this.Account = acc;
        }

        public Account Account { get => account; set => account = value; }
    }
}
