namespace BookStore.UI
{
    partial class InvoiceForm
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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            grpInfo = new GroupBox();
            btnAddNewCustomer = new Button();
            cbCustomer = new ComboBox();
            label3 = new Label();
            txtStaff = new TextBox();
            label2 = new Label();
            lblDate = new Label();
            label1 = new Label();
            grpBook = new GroupBox();
            btnAddItem = new Button();
            numQuantity = new NumericUpDown();
            label5 = new Label();
            cbBook = new ComboBox();
            label4 = new Label();
            dgvItems = new DataGridView();
            panelFooter = new Panel();
            btnPrintInvoice = new Button();
            btnSaveInvoice = new Button();
            lblTotal = new Label();
            label6 = new Label();
            grpInfo.SuspendLayout();
            grpBook.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvItems).BeginInit();
            panelFooter.SuspendLayout();
            SuspendLayout();
            // 
            // grpInfo
            // 
            grpInfo.BackColor = Color.White;
            grpInfo.Controls.Add(btnAddNewCustomer);
            grpInfo.Controls.Add(cbCustomer);
            grpInfo.Controls.Add(txtStaff);
            grpInfo.Controls.Add(label2);
            grpInfo.Controls.Add(label3);
            grpInfo.Controls.Add(lblDate);
            grpInfo.Controls.Add(label1);
            grpInfo.Dock = DockStyle.Top;
            grpInfo.Font = new Font("Segoe UI", 10F);
            grpInfo.Location = new Point(15, 15);
            grpInfo.Name = "grpInfo";
            grpInfo.Padding = new Padding(10);
            grpInfo.Size = new Size(1070, 140);
            grpInfo.TabIndex = 0;
            grpInfo.TabStop = false;
            grpInfo.Text = "Thông tin chung";
            // 
            // btnAddNewCustomer
            // 
            btnAddNewCustomer.Cursor = Cursors.Hand;
            btnAddNewCustomer.Location = new Point(566, 88);
            btnAddNewCustomer.Name = "btnAddNewCustomer";
            btnAddNewCustomer.Size = new Size(250, 45);
            btnAddNewCustomer.TabIndex = 6;
            btnAddNewCustomer.Text = "Thêm khách hàng";
            btnAddNewCustomer.UseVisualStyleBackColor = true;
            btnAddNewCustomer.Click += btnAddNewCustomer_Click;
            // 
            // cbCustomer
            // 
            cbCustomer.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCustomer.FormattingEnabled = true;
            cbCustomer.Location = new Point(193, 89);
            cbCustomer.Name = "cbCustomer";
            cbCustomer.Size = new Size(360, 45);
            cbCustomer.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 92);
            label3.Name = "label3";
            label3.Size = new Size(162, 37);
            label3.TabIndex = 4;
            label3.Text = "Khách hàng:";
            // 
            // txtStaff
            // 
            txtStaff.BackColor = SystemColors.ControlLightLight;
            txtStaff.Location = new Point(566, 40);
            txtStaff.Name = "txtStaff";
            txtStaff.ReadOnly = true;
            txtStaff.Size = new Size(250, 43);
            txtStaff.TabIndex = 3;
            txtStaff.TextChanged += txtStaff_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(417, 44);
            label2.Name = "label2";
            label2.Size = new Size(143, 37);
            label2.TabIndex = 2;
            label2.Text = "Nhân viên:";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDate.Location = new Point(170, 43);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(189, 38);
            lblDate.TabIndex = 1;
            lblDate.Text = "dd/MM/yyyy";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 44);
            label1.Name = "label1";
            label1.Size = new Size(130, 37);
            label1.TabIndex = 0;
            label1.Text = "Ngày lập:";
            // 
            // grpBook
            // 
            grpBook.BackColor = Color.White;
            grpBook.Controls.Add(btnAddItem);
            grpBook.Controls.Add(numQuantity);
            grpBook.Controls.Add(label5);
            grpBook.Controls.Add(cbBook);
            grpBook.Controls.Add(label4);
            grpBook.Dock = DockStyle.Top;
            grpBook.Font = new Font("Segoe UI", 10F);
            grpBook.Location = new Point(15, 155);
            grpBook.Name = "grpBook";
            grpBook.Size = new Size(1070, 100);
            grpBook.TabIndex = 1;
            grpBook.TabStop = false;
            grpBook.Text = "Chọn sản phẩm";
            // 
            // btnAddItem
            // 
            btnAddItem.BackColor = SystemColors.Control;
            btnAddItem.Cursor = Cursors.Hand;
            btnAddItem.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAddItem.ForeColor = Color.Black;
            btnAddItem.Location = new Point(892, 40);
            btnAddItem.Name = "btnAddItem";
            btnAddItem.Size = new Size(120, 45);
            btnAddItem.TabIndex = 4;
            btnAddItem.Text = "Thêm sách";
            btnAddItem.UseVisualStyleBackColor = false;
            btnAddItem.Click += btnAddItem_Click;
            // 
            // numQuantity
            // 
            numQuantity.Location = new Point(726, 41);
            numQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(100, 43);
            numQuantity.TabIndex = 3;
            numQuantity.TextAlign = HorizontalAlignment.Center;
            numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(590, 44);
            label5.Name = "label5";
            label5.Size = new Size(130, 37);
            label5.TabIndex = 2;
            label5.Text = "Số lượng:";
            // 
            // cbBook
            // 
            cbBook.DropDownStyle = ComboBoxStyle.DropDownList;
            cbBook.FormattingEnabled = true;
            cbBook.Location = new Point(153, 40);
            cbBook.Name = "cbBook";
            cbBook.Size = new Size(420, 45);
            cbBook.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(25, 44);
            label4.Name = "label4";
            label4.Size = new Size(122, 37);
            label4.TabIndex = 0;
            label4.Text = "Tên sách:";
            // 
            // dgvItems
            // 
            dgvItems.AllowUserToAddRows = false;
            dgvItems.AllowUserToDeleteRows = false;
            dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvItems.BackgroundColor = Color.White;
            dgvItems.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Control;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvItems.ColumnHeadersHeight = 40;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Window;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(224, 224, 224);
            dataGridViewCellStyle6.SelectionForeColor = Color.Black;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dgvItems.DefaultCellStyle = dataGridViewCellStyle6;
            dgvItems.Dock = DockStyle.Fill;
            dgvItems.GridColor = Color.LightGray;
            dgvItems.Location = new Point(15, 255);
            dgvItems.MultiSelect = false;
            dgvItems.Name = "dgvItems";
            dgvItems.ReadOnly = true;
            dgvItems.RowHeadersWidth = 51;
            dgvItems.RowTemplate.Height = 35;
            dgvItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvItems.Size = new Size(1070, 330);
            dgvItems.TabIndex = 2;
            dgvItems.CellClick += dgvItems_CellClick;
            // 
            // panelFooter
            // 
            panelFooter.BackColor = Color.White;
            panelFooter.Controls.Add(btnPrintInvoice);
            panelFooter.Controls.Add(btnSaveInvoice);
            panelFooter.Controls.Add(lblTotal);
            panelFooter.Controls.Add(label6);
            panelFooter.Dock = DockStyle.Bottom;
            panelFooter.Location = new Point(15, 585);
            panelFooter.Name = "panelFooter";
            panelFooter.Size = new Size(1070, 80);
            panelFooter.TabIndex = 3;
            // 
            // btnPrintInvoice
            // 
            btnPrintInvoice.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPrintInvoice.Cursor = Cursors.Hand;
            btnPrintInvoice.Enabled = false;
            btnPrintInvoice.Font = new Font("Segoe UI", 10F);
            btnPrintInvoice.Location = new Point(850, 20);
            btnPrintInvoice.Name = "btnPrintInvoice";
            btnPrintInvoice.Size = new Size(162, 45);
            btnPrintInvoice.TabIndex = 3;
            btnPrintInvoice.Text = "In Hóa Đơn";
            btnPrintInvoice.UseVisualStyleBackColor = true;
            btnPrintInvoice.Click += btnPrintInvoice_Click;
            // 
            // btnSaveInvoice
            // 
            btnSaveInvoice.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSaveInvoice.Cursor = Cursors.Hand;
            btnSaveInvoice.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSaveInvoice.Location = new Point(662, 21);
            btnSaveInvoice.Name = "btnSaveInvoice";
            btnSaveInvoice.Size = new Size(182, 45);
            btnSaveInvoice.TabIndex = 2;
            btnSaveInvoice.Text = "Thanh Toán";
            btnSaveInvoice.UseVisualStyleBackColor = true;
            btnSaveInvoice.Click += btnSaveInvoice_Click;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.ForeColor = Color.Black;
            lblTotal.Location = new Point(258, 3);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(99, 65);
            lblTotal.TabIndex = 1;
            lblTotal.Text = "0 đ";
            lblTotal.Click += lblTotal_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(25, 18);
            label6.Name = "label6";
            label6.Size = new Size(227, 45);
            label6.TabIndex = 0;
            label6.Text = "Tổng hoá đơn:";
            // 
            // InvoiceForm
            // 
            AutoScaleDimensions = new SizeF(15F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1100, 680);
            Controls.Add(dgvItems);
            Controls.Add(panelFooter);
            Controls.Add(grpBook);
            Controls.Add(grpInfo);
            Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "InvoiceForm";
            Padding = new Padding(15);
            StartPosition = FormStartPosition.CenterParent;
            Text = "Lập Hóa Đơn";
            Load += InvoiceForm_Load;
            grpInfo.ResumeLayout(false);
            grpInfo.PerformLayout();
            grpBook.ResumeLayout(false);
            grpBook.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvItems).EndInit();
            panelFooter.ResumeLayout(false);
            panelFooter.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStaff;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbCustomer;
        private System.Windows.Forms.GroupBox grpBook;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbBook;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnSaveInvoice;
        private System.Windows.Forms.Button btnPrintInvoice;
        private System.Windows.Forms.Button btnAddNewCustomer;
    }
}