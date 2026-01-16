namespace BookStore.UI
{
    partial class PublisherForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            grpInput = new GroupBox();
            txtAddress = new TextBox();
            btnDelete = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            label2 = new Label();
            txtPublisherName = new TextBox();
            label1 = new Label();
            dgvPublishers = new DataGridView();
            btnSearch = new Button();
            txtSearch = new TextBox();
            grpInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPublishers).BeginInit();
            SuspendLayout();
            // 
            // grpInput
            // 
            grpInput.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpInput.Controls.Add(txtAddress);
            grpInput.Controls.Add(btnDelete);
            grpInput.Controls.Add(btnEdit);
            grpInput.Controls.Add(btnAdd);
            grpInput.Controls.Add(label2);
            grpInput.Controls.Add(txtPublisherName);
            grpInput.Controls.Add(label1);
            grpInput.Location = new Point(12, 12);
            grpInput.Name = "grpInput";
            grpInput.Size = new Size(860, 160);
            grpInput.TabIndex = 0;
            grpInput.TabStop = false;
            grpInput.Text = "Thông tin Nhà xuất bản";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(150, 90);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(350, 43);
            txtAddress.TabIndex = 2;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(720, 40);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(110, 40);
            btnDelete.TabIndex = 6;
            btnDelete.Text = "Xoá";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(600, 40);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(110, 40);
            btnEdit.TabIndex = 5;
            btnEdit.Text = "Sửa";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(480, 40);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(110, 40);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 93);
            label2.Name = "label2";
            label2.Size = new Size(104, 37);
            label2.TabIndex = 2;
            label2.Text = "Địa chỉ:";
            // 
            // txtPublisherName
            // 
            txtPublisherName.Location = new Point(150, 40);
            txtPublisherName.Name = "txtPublisherName";
            txtPublisherName.Size = new Size(250, 43);
            txtPublisherName.TabIndex = 1;
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
            // dgvPublishers
            // 
            dgvPublishers.AllowUserToAddRows = false;
            dgvPublishers.AllowUserToDeleteRows = false;
            dgvPublishers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPublishers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPublishers.BackgroundColor = Color.White;
            dgvPublishers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvPublishers.DefaultCellStyle = dataGridViewCellStyle1;
            dgvPublishers.Location = new Point(12, 240);
            dgvPublishers.MultiSelect = false;
            dgvPublishers.Name = "dgvPublishers";
            dgvPublishers.ReadOnly = true;
            dgvPublishers.RowHeadersWidth = 51;
            dgvPublishers.RowTemplate.Height = 29;
            dgvPublishers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPublishers.Size = new Size(860, 310);
            dgvPublishers.TabIndex = 9;
            dgvPublishers.SelectionChanged += dgvPublishers_SelectionChanged;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(400, 190);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(120, 44);
            btnSearch.TabIndex = 8;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(12, 190);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search Publisher Name...";
            txtSearch.Size = new Size(380, 43);
            txtSearch.TabIndex = 7;
            // 
            // PublisherForm
            // 
            AutoScaleDimensions = new SizeF(15F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 561);
            Controls.Add(txtSearch);
            Controls.Add(btnSearch);
            Controls.Add(dgvPublishers);
            Controls.Add(grpInput);
            Font = new Font("Segoe UI", 10F);
            Name = "PublisherForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Publisher Management";
            Load += PublisherForm_Load;
            grpInput.ResumeLayout(false);
            grpInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPublishers).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpInput;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPublisherName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvPublishers;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
    }
}