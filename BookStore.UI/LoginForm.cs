using BookStore.BLL;
using BookStore.Entities;
using System;
using System.Windows.Forms;

namespace BookStore.UI
{
    public partial class LoginForm : Form
    {
        private readonly IAuthService _authService;

        public User LoggedInUser { get; private set; }

        public LoginForm(IAuthService authService)
        {
            InitializeComponent();
            _authService = authService;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter username and password.");
                return;
            }

            try
            {
                btnLogin.Enabled = false;
                Cursor = Cursors.WaitCursor;

                var user = await _authService.LoginAsync(username, password);

                if (user != null)
                {
                    LoggedInUser = user;
                    MessageBox.Show("Login successful!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid username or password.", "Login Failed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                btnLogin.Enabled = true;
                Cursor = Cursors.Default;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}