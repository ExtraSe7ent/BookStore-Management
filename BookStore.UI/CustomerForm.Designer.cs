namespace BookStore.UI
{
    partial class CustomerForm
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            grpInput = new GroupBox();
            txtAddress = new TextBox();
            label4 = new Label();
            txtPhone = new TextBox();
            label2 = new Label();
            btnDelete = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            txtFullName = new TextBox();
            label1 = new Label();
            dgvCustomers = new DataGridView();
            btnSearch = new Button();
            txtSearch = new TextBox();
            grpInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
            SuspendLayout();
            // 
            // grpInput
            // 
            grpInput.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpInput.Controls.Add(txtAddress);
            grpInput.Controls.Add(label4);
            grpInput.Controls.Add(txtPhone);
            grpInput.Controls.Add(label2);
            grpInput.Controls.Add(btnDelete);
            grpInput.Controls.Add(btnEdit);
            grpInput.Controls.Add(btnAdd);
            grpInput.Controls.Add(txtFullName);
            grpInput.Controls.Add(label1);
            grpInput.Location = new Point(12, 12);
            grpInput.Name = "grpInput";
            grpInput.Size = new Size(960, 200);
            grpInput.TabIndex = 0;
            grpInput.TabStop = false;
            grpInput.Text = "Thông tin Khách hàng";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(216, 140);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(450, 43);
            txtAddress.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(30, 143);
            label4.Name = "label4";
            label4.Size = new Size(106, 37);
            label4.TabIndex = 11;
            label4.Text = "Địa chr:";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(216, 90);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(250, 43);
            txtPhone.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 93);
            label2.Name = "label2";
            label2.Size = new Size(180, 37);
            label2.TabIndex = 7;
            label2.Text = "Số điện thoại:";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(744, 143);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(110, 40);
            btnDelete.TabIndex = 6;
            btnDelete.Text = "Xoá";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(744, 90);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(110, 40);
            btnEdit.TabIndex = 5;
            btnEdit.Text = "Sửa";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(744, 40);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(110, 40);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(216, 40);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(250, 43);
            txtFullName.TabIndex = 1;
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
            // dgvCustomers
            // 
            dgvCustomers.AllowUserToAddRows = false;
            dgvCustomers.AllowUserToDeleteRows = false;
            dgvCustomers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomers.BackgroundColor = Color.White;
            dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvCustomers.DefaultCellStyle = dataGridViewCellStyle2;
            dgvCustomers.Location = new Point(12, 280);
            dgvCustomers.MultiSelect = false;
            dgvCustomers.Name = "dgvCustomers";
            dgvCustomers.ReadOnly = true;
            dgvCustomers.RowHeadersWidth = 51;
            dgvCustomers.RowTemplate.Height = 29;
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomers.Size = new Size(960, 460);
            dgvCustomers.TabIndex = 9;
            dgvCustomers.SelectionChanged += dgvCustomers_SelectionChanged;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(400, 230);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(120, 44);
            btnSearch.TabIndex = 8;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(12, 230);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search by Name or Phone...";
            txtSearch.Size = new Size(380, 43);
            txtSearch.TabIndex = 7;
            // 
            // CustomerForm
            // 
            AutoScaleDimensions = new SizeF(15F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 761);
            Controls.Add(txtSearch);
            Controls.Add(btnSearch);
            Controls.Add(dgvCustomers);
            Controls.Add(grpInput);
            Font = new Font("Segoe UI", 10F);
            Name = "CustomerForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Customer Management";
            Load += CustomerForm_Load;
            grpInput.ResumeLayout(false);
            grpInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpInput;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label2;
    }
}