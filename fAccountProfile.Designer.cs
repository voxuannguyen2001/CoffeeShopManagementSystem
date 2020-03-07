namespace Cafeteria_Management_Application
{
    partial class fAccountProfile
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Button btnUpdate;
            System.Windows.Forms.Button btnExit;
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtbUserName = new System.Windows.Forms.TextBox();
            this.lbUserName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtbDisplayName = new System.Windows.Forms.TextBox();
            this.lbDisplayName = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtbPassword = new System.Windows.Forms.TextBox();
            this.lbPassword = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtbNewPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtbReEnterPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            btnUpdate = new System.Windows.Forms.Button();
            btnExit = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new System.Drawing.Point(329, 375);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new System.Drawing.Size(75, 23);
            btnUpdate.TabIndex = 6;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnExit
            // 
            btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnExit.Location = new System.Drawing.Point(420, 375);
            btnExit.Name = "btnExit";
            btnExit.Size = new System.Drawing.Size(75, 23);
            btnExit.TabIndex = 7;
            btnExit.Text = "Thoát";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtbUserName);
            this.panel2.Controls.Add(this.lbUserName);
            this.panel2.Location = new System.Drawing.Point(12, 22);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(481, 51);
            this.panel2.TabIndex = 1;
            // 
            // txtbUserName
            // 
            this.txtbUserName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtbUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbUserName.Enabled = false;
            this.txtbUserName.Location = new System.Drawing.Point(153, 14);
            this.txtbUserName.Name = "txtbUserName";
            this.txtbUserName.ReadOnly = true;
            this.txtbUserName.Size = new System.Drawing.Size(287, 20);
            this.txtbUserName.TabIndex = 1;
            this.txtbUserName.TabStop = false;
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUserName.Location = new System.Drawing.Point(3, 13);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(130, 19);
            this.lbUserName.TabIndex = 0;
            this.lbUserName.Text = "Tên đăng nhập:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtbDisplayName);
            this.panel1.Controls.Add(this.lbDisplayName);
            this.panel1.Location = new System.Drawing.Point(12, 91);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(481, 51);
            this.panel1.TabIndex = 2;
            // 
            // txtbDisplayName
            // 
            this.txtbDisplayName.Location = new System.Drawing.Point(153, 14);
            this.txtbDisplayName.Name = "txtbDisplayName";
            this.txtbDisplayName.Size = new System.Drawing.Size(287, 20);
            this.txtbDisplayName.TabIndex = 2;
            // 
            // lbDisplayName
            // 
            this.lbDisplayName.AutoSize = true;
            this.lbDisplayName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDisplayName.Location = new System.Drawing.Point(3, 13);
            this.lbDisplayName.Name = "lbDisplayName";
            this.lbDisplayName.Size = new System.Drawing.Size(98, 19);
            this.lbDisplayName.TabIndex = 0;
            this.lbDisplayName.Text = "Tên hiển thị";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtbPassword);
            this.panel3.Controls.Add(this.lbPassword);
            this.panel3.Location = new System.Drawing.Point(13, 160);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(481, 51);
            this.panel3.TabIndex = 3;
            // 
            // txtbPassword
            // 
            this.txtbPassword.Location = new System.Drawing.Point(153, 14);
            this.txtbPassword.Name = "txtbPassword";
            this.txtbPassword.Size = new System.Drawing.Size(287, 20);
            this.txtbPassword.TabIndex = 3;
            this.txtbPassword.UseSystemPasswordChar = true;
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPassword.Location = new System.Drawing.Point(3, 13);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(84, 19);
            this.lbPassword.TabIndex = 0;
            this.lbPassword.Text = "Mật khẩu:";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtbNewPassword);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Location = new System.Drawing.Point(13, 228);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(481, 51);
            this.panel4.TabIndex = 6;
            // 
            // txtbNewPassword
            // 
            this.txtbNewPassword.Location = new System.Drawing.Point(153, 14);
            this.txtbNewPassword.Name = "txtbNewPassword";
            this.txtbNewPassword.Size = new System.Drawing.Size(287, 20);
            this.txtbNewPassword.TabIndex = 4;
            this.txtbNewPassword.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mật khẩu mới:";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.txtbReEnterPassword);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Location = new System.Drawing.Point(14, 298);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(481, 51);
            this.panel5.TabIndex = 7;
            // 
            // txtbReEnterPassword
            // 
            this.txtbReEnterPassword.Location = new System.Drawing.Point(153, 14);
            this.txtbReEnterPassword.Name = "txtbReEnterPassword";
            this.txtbReEnterPassword.Size = new System.Drawing.Size(287, 20);
            this.txtbReEnterPassword.TabIndex = 5;
            this.txtbReEnterPassword.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nhập lại mật khẩu:";
            // 
            // fAccountProfile
            // 
            this.AcceptButton = btnUpdate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = btnExit;
            this.ClientSize = new System.Drawing.Size(507, 411);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(btnExit);
            this.Controls.Add(btnUpdate);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "fAccountProfile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin cá nhân";
            this.Load += new System.EventHandler(this.fAccountProfile_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtbUserName;
        private System.Windows.Forms.Label lbUserName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtbDisplayName;
        private System.Windows.Forms.Label lbDisplayName;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtbPassword;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtbNewPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txtbReEnterPassword;
        private System.Windows.Forms.Label label2;
    }
}