namespace BookStore.UI
{
    partial class MainForm
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
            menuStrip1 = new MenuStrip();
            systemToolStripMenuItem = new ToolStripMenuItem();
            menuLogout = new ToolStripMenuItem();
            menuExit = new ToolStripMenuItem();
            managementToolStripMenuItem = new ToolStripMenuItem();
            menuBook = new ToolStripMenuItem();
            menuCategory = new ToolStripMenuItem();
            menuAuthor = new ToolStripMenuItem();
            menuPublisher = new ToolStripMenuItem();
            menuCustomer = new ToolStripMenuItem();
            menuUser = new ToolStripMenuItem();
            businessToolStripMenuItem = new ToolStripMenuItem();
            menuInvoice = new ToolStripMenuItem();
            menuReport = new ToolStripMenuItem();
            lblWelcome = new Label();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { systemToolStripMenuItem, managementToolStripMenuItem, businessToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(10, 3, 0, 3);
            menuStrip1.Size = new Size(1300, 42);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // systemToolStripMenuItem
            // 
            systemToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menuLogout, menuExit });
            systemToolStripMenuItem.Name = "systemToolStripMenuItem";
            systemToolStripMenuItem.Size = new Size(110, 36);
            systemToolStripMenuItem.Text = "System";
            // 
            // menuLogout
            // 
            menuLogout.Name = "menuLogout";
            menuLogout.Size = new Size(222, 44);
            menuLogout.Text = "Logout";
            menuLogout.Click += menuLogout_Click;
            // 
            // menuExit
            // 
            menuExit.Name = "menuExit";
            menuExit.Size = new Size(222, 44);
            menuExit.Text = "Exit";
            menuExit.Click += menuExit_Click;
            // 
            // managementToolStripMenuItem
            // 
            managementToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menuBook, menuCategory, menuAuthor, menuPublisher, menuCustomer, menuUser });
            managementToolStripMenuItem.Name = "managementToolStripMenuItem";
            managementToolStripMenuItem.Size = new Size(177, 36);
            managementToolStripMenuItem.Text = "Management";
            // 
            // menuBook
            // 
            menuBook.Name = "menuBook";
            menuBook.Size = new Size(295, 44);
            menuBook.Text = "Books";
            menuBook.Click += menuBook_Click;
            // 
            // menuCategory
            // 
            menuCategory.Name = "menuCategory";
            menuCategory.Size = new Size(295, 44);
            menuCategory.Text = "Categories";
            menuCategory.Click += menuCategory_Click;
            // 
            // menuAuthor
            // 
            menuAuthor.Name = "menuAuthor";
            menuAuthor.Size = new Size(295, 44);
            menuAuthor.Text = "Authors";
            menuAuthor.Click += menuAuthor_Click;
            // 
            // menuPublisher
            // 
            menuPublisher.Name = "menuPublisher";
            menuPublisher.Size = new Size(295, 44);
            menuPublisher.Text = "Publishers";
            menuPublisher.Click += menuPublisher_Click;
            // 
            // menuCustomer
            // 
            menuCustomer.Name = "menuCustomer";
            menuCustomer.Size = new Size(295, 44);
            menuCustomer.Text = "Customers";
            menuCustomer.Click += menuCustomer_Click;
            // 
            // menuUser
            // 
            menuUser.Name = "menuUser";
            menuUser.Size = new Size(295, 44);
            menuUser.Text = "Users (Admin)";
            menuUser.Click += menuUser_Click;
            // 
            // businessToolStripMenuItem
            // 
            businessToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menuInvoice, menuReport });
            businessToolStripMenuItem.Name = "businessToolStripMenuItem";
            businessToolStripMenuItem.Size = new Size(125, 36);
            businessToolStripMenuItem.Text = "Business";
            // 
            // menuInvoice
            // 
            menuInvoice.Name = "menuInvoice";
            menuInvoice.Size = new Size(316, 44);
            menuInvoice.Text = "Create Invoice";
            menuInvoice.Click += menuInvoice_Click;
            // 
            // menuReport
            // 
            menuReport.Name = "menuReport";
            menuReport.Size = new Size(316, 44);
            menuReport.Text = "Revenue Report";
            menuReport.Click += menuReport_Click;
            // 
            // lblWelcome
            // 
            lblWelcome.Anchor = AnchorStyles.None;
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblWelcome.ForeColor = SystemColors.Highlight;
            lblWelcome.Location = new Point(406, 288);
            lblWelcome.Margin = new Padding(5, 0, 5, 0);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(489, 86);
            lblWelcome.TabIndex = 1;
            lblWelcome.Text = "Welcome User!";
            lblWelcome.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1300, 720);
            Controls.Add(lblWelcome);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(5);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Book Store Management System";
            WindowState = FormWindowState.Maximized;
            Load += MainForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem systemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuLogout;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.ToolStripMenuItem managementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuBook;
        private System.Windows.Forms.ToolStripMenuItem menuCategory;
        private System.Windows.Forms.ToolStripMenuItem menuAuthor;
        private System.Windows.Forms.ToolStripMenuItem menuPublisher;
        private System.Windows.Forms.ToolStripMenuItem menuCustomer;
        private System.Windows.Forms.ToolStripMenuItem menuUser;
        private System.Windows.Forms.ToolStripMenuItem businessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuInvoice;
        private System.Windows.Forms.ToolStripMenuItem menuReport;
        private System.Windows.Forms.Label lblWelcome;
    }
}