using BookStore.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace BookStore.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var user = Program.CurrentUser;
            if (user != null)
            {
                string roleName = user.Role?.RoleName ?? "Unknown";
                lblWelcome.Text = $"Welcome, {user.UserName} ({roleName})!";

                if (roleName == "Admin")
                {
                    if (menuUser != null) menuUser.Visible = true;
                    if (menuReport != null) menuReport.Visible = true; 

                }
                else 
                {
                    // Staff bị ẩn chức năng quản trị và báo cáo nhạy cảm
                    if (menuUser != null) menuUser.Visible = false;
                    if (menuReport != null) menuReport.Visible = false; 
                }
            }
        }

        private void OpenForm<T>() where T : Form
        {
            using (var scope = Program.ServiceProvider.CreateScope())
            {
                var form = scope.ServiceProvider.GetRequiredService<T>();
                form.StartPosition = FormStartPosition.CenterParent;
                form.ShowDialog(this);
            }
        }

        private void menuBook_Click(object sender, EventArgs e) => OpenForm<BookForm>();
        private void menuAuthor_Click(object sender, EventArgs e) => OpenForm<AuthorForm>();
        private void menuPublisher_Click(object sender, EventArgs e) => OpenForm<PublisherForm>();
        private void menuCategory_Click(object sender, EventArgs e) => OpenForm<CategoryForm>();
        private void menuCustomer_Click(object sender, EventArgs e) => OpenForm<CustomerForm>();
        private void menuUser_Click(object sender, EventArgs e) => OpenForm<UserForm>();
        private void menuInvoice_Click(object sender, EventArgs e) => OpenForm<InvoiceForm>();

        private void menuReport_Click(object sender, EventArgs e) => OpenForm<ReportForm>();

        private void menuLogout_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}