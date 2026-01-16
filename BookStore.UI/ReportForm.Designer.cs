namespace BookStore.UI
{
    partial class ReportForm
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
            grpFilter = new GroupBox();
            btnGenerateReport = new Button();
            cbAllTime = new CheckBox();
            dtpTo = new DateTimePicker();
            label2 = new Label();
            dtpFrom = new DateTimePicker();
            label1 = new Label();
            dgvReport = new DataGridView();
            grpAction = new GroupBox();
            lblTotalRevenue = new Label();
            label3 = new Label();
            btnPrintReport = new Button();
            btnExportExcelReport = new Button();
            btnExportPdfReport = new Button();
            grpFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReport).BeginInit();
            grpAction.SuspendLayout();
            SuspendLayout();
            // 
            // grpFilter
            // 
            grpFilter.Controls.Add(btnGenerateReport);
            grpFilter.Controls.Add(cbAllTime);
            grpFilter.Controls.Add(dtpTo);
            grpFilter.Controls.Add(label2);
            grpFilter.Controls.Add(dtpFrom);
            grpFilter.Controls.Add(label1);
            grpFilter.Dock = DockStyle.Top;
            grpFilter.Location = new Point(10, 10);
            grpFilter.Name = "grpFilter";
            grpFilter.Size = new Size(964, 100);
            grpFilter.TabIndex = 0;
            grpFilter.TabStop = false;
            grpFilter.Text = "Báo cáo doanh thu";
            // 
            // btnGenerateReport
            // 
            btnGenerateReport.BackColor = Color.SteelBlue;
            btnGenerateReport.FlatStyle = FlatStyle.Flat;
            btnGenerateReport.ForeColor = Color.White;
            btnGenerateReport.Location = new Point(790, 35);
            btnGenerateReport.Name = "btnGenerateReport";
            btnGenerateReport.Size = new Size(150, 53);
            btnGenerateReport.TabIndex = 5;
            btnGenerateReport.Text = "Xem";
            btnGenerateReport.UseVisualStyleBackColor = false;
            btnGenerateReport.Click += btnGenerateReport_Click;
            // 
            // cbAllTime
            // 
            cbAllTime.AutoSize = true;
            cbAllTime.Location = new Point(620, 42);
            cbAllTime.Name = "cbAllTime";
            cbAllTime.Size = new Size(140, 41);
            cbAllTime.TabIndex = 4;
            cbAllTime.Text = "All time";
            cbAllTime.UseVisualStyleBackColor = true;
            cbAllTime.CheckedChanged += cbAllTime_CheckedChanged;
            // 
            // dtpTo
            // 
            dtpTo.Format = DateTimePickerFormat.Short;
            dtpTo.Location = new Point(380, 40);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(200, 43);
            dtpTo.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(303, 43);
            label2.Name = "label2";
            label2.Size = new Size(71, 37);
            label2.TabIndex = 2;
            label2.Text = "Đến:";
            // 
            // dtpFrom
            // 
            dtpFrom.Format = DateTimePickerFormat.Short;
            dtpFrom.Location = new Point(69, 40);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(200, 43);
            dtpFrom.TabIndex = 1;
            dtpFrom.ValueChanged += dtpFrom_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 43);
            label1.Name = "label1";
            label1.Size = new Size(53, 37);
            label1.TabIndex = 0;
            label1.Text = "Từ:";
            // 
            // dgvReport
            // 
            dgvReport.AllowUserToAddRows = false;
            dgvReport.AllowUserToDeleteRows = false;
            dgvReport.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReport.BackgroundColor = Color.White;
            dgvReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReport.Location = new Point(10, 120);
            dgvReport.Name = "dgvReport";
            dgvReport.ReadOnly = true;
            dgvReport.RowHeadersWidth = 51;
            dgvReport.RowTemplate.Height = 29;
            dgvReport.Size = new Size(700, 430);
            dgvReport.TabIndex = 6;
            // 
            // grpAction
            // 
            grpAction.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            grpAction.Controls.Add(lblTotalRevenue);
            grpAction.Controls.Add(label3);
            grpAction.Controls.Add(btnPrintReport);
            grpAction.Controls.Add(btnExportExcelReport);
            grpAction.Controls.Add(btnExportPdfReport);
            grpAction.Location = new Point(720, 120);
            grpAction.Name = "grpAction";
            grpAction.Size = new Size(254, 430);
            grpAction.TabIndex = 7;
            grpAction.TabStop = false;
            // 
            // lblTotalRevenue
            // 
            lblTotalRevenue.AutoSize = true;
            lblTotalRevenue.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTotalRevenue.ForeColor = Color.Firebrick;
            lblTotalRevenue.Location = new Point(20, 70);
            lblTotalRevenue.Name = "lblTotalRevenue";
            lblTotalRevenue.Size = new Size(78, 51);
            lblTotalRevenue.TabIndex = 8;
            lblTotalRevenue.Text = "0 đ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.Location = new Point(20, 40);
            label3.Name = "label3";
            label3.Size = new Size(228, 37);
            label3.TabIndex = 7;
            label3.Text = "Tổng doanh thu:";
            // 
            // btnPrintReport
            // 
            btnPrintReport.Location = new Point(20, 150);
            btnPrintReport.Name = "btnPrintReport";
            btnPrintReport.Size = new Size(210, 45);
            btnPrintReport.TabIndex = 9;
            btnPrintReport.Text = "In báo cáo";
            btnPrintReport.UseVisualStyleBackColor = true;
            btnPrintReport.Click += btnPrintReport_Click;
            // 
            // btnExportExcelReport
            // 
            btnExportExcelReport.Location = new Point(20, 210);
            btnExportExcelReport.Name = "btnExportExcelReport";
            btnExportExcelReport.Size = new Size(210, 45);
            btnExportExcelReport.TabIndex = 10;
            btnExportExcelReport.Text = "Xuất file Excel";
            btnExportExcelReport.UseVisualStyleBackColor = true;
            btnExportExcelReport.Click += btnExportExcelReport_Click;
            // 
            // btnExportPdfReport
            // 
            btnExportPdfReport.Location = new Point(20, 270);
            btnExportPdfReport.Name = "btnExportPdfReport";
            btnExportPdfReport.Size = new Size(210, 45);
            btnExportPdfReport.TabIndex = 11;
            btnExportPdfReport.Text = "Xuất file PDF";
            btnExportPdfReport.UseVisualStyleBackColor = true;
            btnExportPdfReport.Click += btnExportPdfReport_Click;
            // 
            // ReportForm
            // 
            AutoScaleDimensions = new SizeF(15F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 561);
            Controls.Add(grpAction);
            Controls.Add(dgvReport);
            Controls.Add(grpFilter);
            Font = new Font("Segoe UI", 10F);
            Name = "ReportForm";
            Padding = new Padding(10);
            StartPosition = FormStartPosition.CenterParent;
            Text = "Revenue Report";
            Load += ReportForm_Load;
            grpFilter.ResumeLayout(false);
            grpFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReport).EndInit();
            grpAction.ResumeLayout(false);
            grpAction.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpFilter;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.CheckBox cbAllTime;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.GroupBox grpAction;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTotalRevenue;
        private System.Windows.Forms.Button btnPrintReport;
        private System.Windows.Forms.Button btnExportExcelReport;
        private System.Windows.Forms.Button btnExportPdfReport;
    }
}