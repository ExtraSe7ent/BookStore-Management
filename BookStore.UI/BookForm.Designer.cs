namespace BookStore.UI
{
    partial class BookForm
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
            groupBox1 = new GroupBox();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            cbPublisher = new ComboBox();
            label6 = new Label();
            cbAuthor = new ComboBox();
            label5 = new Label();
            txtStock = new TextBox();
            label4 = new Label();
            txtPrice = new TextBox();
            label3 = new Label();
            cbCategory = new ComboBox();
            label7 = new Label();
            txtTitle = new TextBox();
            label1 = new Label();
            dgvBooks = new DataGridView();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnExportExcel = new Button();
            btnExportPdf = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnAdd);
            groupBox1.Controls.Add(btnEdit);
            groupBox1.Controls.Add(btnDelete);
            groupBox1.Controls.Add(cbPublisher);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(cbAuthor);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txtStock);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtPrice);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(cbCategory);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(txtTitle);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(16, 15);
            groupBox1.Margin = new Padding(4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4);
            groupBox1.Size = new Size(1170, 384);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin Sách";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(967, 45);
            btnAdd.Margin = new Padding(4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(156, 51);
            btnAdd.TabIndex = 16;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(967, 122);
            btnEdit.Margin = new Padding(4);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(156, 51);
            btnEdit.TabIndex = 17;
            btnEdit.Text = "Sửa";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(967, 199);
            btnDelete.Margin = new Padding(4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(156, 51);
            btnDelete.TabIndex = 18;
            btnDelete.Text = "Xoá";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // cbPublisher
            // 
            cbPublisher.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPublisher.FormattingEnabled = true;
            cbPublisher.Location = new Point(650, 205);
            cbPublisher.Margin = new Padding(4);
            cbPublisher.Name = "cbPublisher";
            cbPublisher.Size = new Size(259, 40);
            cbPublisher.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(520, 209);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(114, 32);
            label6.TabIndex = 10;
            label6.Text = "Xuất bản:";
            // 
            // cbAuthor
            // 
            cbAuthor.DropDownStyle = ComboBoxStyle.DropDownList;
            cbAuthor.FormattingEnabled = true;
            cbAuthor.Location = new Point(195, 205);
            cbAuthor.Margin = new Padding(4);
            cbAuthor.Name = "cbAuthor";
            cbAuthor.Size = new Size(259, 40);
            cbAuthor.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(39, 209);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(91, 32);
            label5.TabIndex = 8;
            label5.Text = "Tác giả:";
            // 
            // txtStock
            // 
            txtStock.Location = new Point(650, 128);
            txtStock.Margin = new Padding(4);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(259, 39);
            txtStock.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(520, 132);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(107, 32);
            label4.TabIndex = 6;
            label4.Text = "Tồn kho:";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(195, 128);
            txtPrice.Margin = new Padding(4);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(259, 39);
            txtPrice.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(39, 132);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(100, 32);
            label3.TabIndex = 4;
            label3.Text = "Giá bán:";
            // 
            // cbCategory
            // 
            cbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCategory.FormattingEnabled = true;
            cbCategory.Location = new Point(650, 51);
            cbCategory.Margin = new Padding(4);
            cbCategory.Name = "cbCategory";
            cbCategory.Size = new Size(259, 40);
            cbCategory.TabIndex = 3;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(520, 55);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(104, 32);
            label7.TabIndex = 2;
            label7.Text = "Thể loại:";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(195, 51);
            txtTitle.Margin = new Padding(4);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(259, 39);
            txtTitle.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 55);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(111, 32);
            label1.TabIndex = 0;
            label1.Text = "Tên sách:";
            // 
            // dgvBooks
            // 
            dgvBooks.AllowUserToAddRows = false;
            dgvBooks.AllowUserToDeleteRows = false;
            dgvBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBooks.Location = new Point(16, 486);
            dgvBooks.Margin = new Padding(4);
            dgvBooks.Name = "dgvBooks";
            dgvBooks.ReadOnly = true;
            dgvBooks.RowHeadersWidth = 62;
            dgvBooks.Size = new Size(1170, 512);
            dgvBooks.TabIndex = 1;
            dgvBooks.CellFormatting += dgvBooks_CellFormatting;
            dgvBooks.SelectionChanged += dgvBooks_SelectionChanged;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(16, 422);
            txtSearch.Margin = new Padding(4);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search by Title...";
            txtSearch.Size = new Size(389, 39);
            txtSearch.TabIndex = 17;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(429, 420);
            btnSearch.Margin = new Padding(4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(130, 45);
            btnSearch.TabIndex = 18;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnExportExcel
            // 
            btnExportExcel.Location = new Point(806, 420);
            btnExportExcel.Margin = new Padding(4);
            btnExportExcel.Name = "btnExportExcel";
            btnExportExcel.Size = new Size(182, 45);
            btnExportExcel.TabIndex = 19;
            btnExportExcel.Text = "Xuất file Excel";
            btnExportExcel.UseVisualStyleBackColor = true;
            btnExportExcel.Click += btnExportExcel_Click;
            // 
            // btnExportPdf
            // 
            btnExportPdf.Location = new Point(1001, 420);
            btnExportPdf.Margin = new Padding(4);
            btnExportPdf.Name = "btnExportPdf";
            btnExportPdf.Size = new Size(182, 45);
            btnExportPdf.TabIndex = 20;
            btnExportPdf.Text = "Xuất file PDF";
            btnExportPdf.UseVisualStyleBackColor = true;
            btnExportPdf.Click += btnExportPDF_Click;
            // 
            // BookForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1209, 1024);
            Controls.Add(btnExportPdf);
            Controls.Add(btnExportExcel);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(dgvBooks);
            Controls.Add(groupBox1);
            Margin = new Padding(4);
            Name = "BookForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Book Management";
            Load += BookForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbPublisher;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbAuthor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvBooks;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.Button btnExportPdf;
    }
}