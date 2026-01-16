namespace BookStore.UI
{
    partial class UserForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            grpInput = new GroupBox();
            btnDeleteUser = new Button();
            label3 = new Label();
            cbRole = new ComboBox();
            txtPassword = new TextBox();
            label2 = new Label();
            btnResetPassword = new Button();
            btnAddUser = new Button();
            txtUsername = new TextBox();
            label1 = new Label();
            dgvUsers = new DataGridView();
            btnSearch = new Button();
            txtSearch = new TextBox();
            grpInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            SuspendLayout();
            // 
            // grpInput
            // 
            grpInput.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpInput.Controls.Add(btnDeleteUser);
            grpInput.Controls.Add(label3);
            grpInput.Controls.Add(cbRole);
            grpInput.Controls.Add(txtPassword);
            grpInput.Controls.Add(label2);
            grpInput.Controls.Add(btnResetPassword);
            grpInput.Controls.Add(btnAddUser);
            grpInput.Controls.Add(txtUsername);
            grpInput.Controls.Add(label1);
            grpInput.Location = new Point(12, 12);
            grpInput.Name = "grpInput";
            grpInput.Size = new Size(960, 200);
            grpInput.TabIndex = 0;
            grpInput.TabStop = false;
            grpInput.Text = "Thông tin Khách hàng";
            // 
            // btnDeleteUser
            // 
            btnDeleteUser.BackColor = Color.IndianRed;
            btnDeleteUser.FlatStyle = FlatStyle.Flat;
            btnDeleteUser.ForeColor = Color.White;
            btnDeleteUser.Location = new Point(678, 138);
            btnDeleteUser.Name = "btnDeleteUser";
            btnDeleteUser.Size = new Size(120, 46);
            btnDeleteUser.TabIndex = 6;
            btnDeleteUser.Text = "Xoá";
            btnDeleteUser.UseVisualStyleBackColor = false;
            btnDeleteUser.Click += btnDeleteUser_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 143);
            label3.Name = "label3";
            label3.Size = new Size(158, 37);
            label3.TabIndex = 23;
            label3.Text = "Role:Vai trò:";
            // 
            // cbRole
            // 
            cbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRole.FormattingEnabled = true;
            cbRole.Items.AddRange(new object[] { "Admin", "Staff" });
            cbRole.Location = new Point(180, 140);
            cbRole.Name = "cbRole";
            cbRole.Size = new Size(200, 45);
            cbRole.TabIndex = 3;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(180, 89);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(250, 43);
            txtPassword.TabIndex = 2;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 93);
            label2.Name = "label2";
            label2.Size = new Size(134, 37);
            label2.TabIndex = 7;
            label2.Text = "Mật khẩu:";
            // 
            // btnResetPassword
            // 
            btnResetPassword.BackColor = Color.SteelBlue;
            btnResetPassword.FlatStyle = FlatStyle.Flat;
            btnResetPassword.ForeColor = Color.White;
            btnResetPassword.Location = new Point(678, 90);
            btnResetPassword.Name = "btnResetPassword";
            btnResetPassword.Size = new Size(120, 43);
            btnResetPassword.TabIndex = 5;
            btnResetPassword.Text = "Sửa";
            btnResetPassword.UseVisualStyleBackColor = false;
            btnResetPassword.Click += btnResetPassword_Click;
            // 
            // btnAddUser
            // 
            btnAddUser.BackColor = Color.SeaGreen;
            btnAddUser.FlatStyle = FlatStyle.Flat;
            btnAddUser.ForeColor = Color.White;
            btnAddUser.Location = new Point(678, 37);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new Size(120, 43);
            btnAddUser.TabIndex = 4;
            btnAddUser.Text = "Thêm";
            btnAddUser.UseVisualStyleBackColor = false;
            btnAddUser.Click += btnAddUser_Click;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(178, 40);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(250, 43);
            txtUsername.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 43);
            label1.Name = "label1";
            label1.Size = new Size(63, 37);
            label1.TabIndex = 0;
            label1.Text = "Tên:";
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.BackgroundColor = Color.White;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Location = new Point(12, 280);
            dgvUsers.MultiSelect = false;
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.RowHeadersWidth = 51;
            dgvUsers.RowTemplate.Height = 29;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.Size = new Size(960, 460);
            dgvUsers.TabIndex = 8;
            dgvUsers.SelectionChanged += dgvUsers_SelectionChanged;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(400, 230);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(120, 44);
            btnSearch.TabIndex = 7;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(12, 230);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search User...";
            txtSearch.Size = new Size(380, 43);
            txtSearch.TabIndex = 6;
            // 
            // UserForm
            // 
            AutoScaleDimensions = new SizeF(15F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 761);
            Controls.Add(txtSearch);
            Controls.Add(btnSearch);
            Controls.Add(dgvUsers);
            Controls.Add(grpInput);
            Font = new Font("Segoe UI", 10F);
            Name = "UserForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "User Management";
            Load += UserForm_Load;
            grpInput.ResumeLayout(false);
            grpInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpInput;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbRole;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnResetPassword;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
    }
}