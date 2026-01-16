using BookStore.BLL;
using BookStore.DAL;
using BookStore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace BookStore.UI
{
    static class Program
    {
        // Biến toàn cục lưu người dùng đang đăng nhập
        public static User CurrentUser;

        public static IServiceProvider ServiceProvider { get; private set; }

        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // --- BƯỚC 1: CẤU HÌNH DI CONTAINER ---
            var services = new ServiceCollection();

            // 1. Database
            string connString = ConfigurationManager.ConnectionStrings["BookStoreContext"].ConnectionString;
            services.AddDbContext<BookStoreContext>(options => options.UseSqlServer(connString));

            // 2. Services (BLL)
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IUserService, UserService>();

            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IAuthorService, AuthorService>();
            services.AddTransient<IPublisherService, PublisherService>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IInvoiceService, InvoiceService>();
            services.AddTransient<IReportService, ReportService>();

            // 3. Forms (UI)
            services.AddTransient<LoginForm>();
            services.AddTransient<MainForm>();
            services.AddTransient<BookForm>();
            services.AddTransient<AuthorForm>();
            services.AddTransient<PublisherForm>();
            services.AddTransient<CustomerForm>();
            services.AddTransient<UserForm>();
            services.AddTransient<InvoiceForm>();
            services.AddTransient<ReportForm>();
            services.AddTransient<CategoryForm>();

            // --- BƯỚC 2: BUILD ---
            ServiceProvider = services.BuildServiceProvider();

            // --- BƯỚC 3: CHẠY LOGIN TRƯỚC ---
            try
            {
                var loginForm = ServiceProvider.GetRequiredService<LoginForm>();

                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // Lấy user đã đăng nhập thành công từ LoginForm
                    CurrentUser = loginForm.LoggedInUser;

                    var mainForm = ServiceProvider.GetRequiredService<MainForm>();
                    Application.Run(mainForm);
                }
                else
                {
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khởi động ứng dụng: {ex.Message}\n{ex.InnerException?.Message}");
            }
        }
    }
}