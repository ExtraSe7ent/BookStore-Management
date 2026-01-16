using BookStore.BLL;
using BookStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 
using System.Windows.Forms;

namespace BookStore.UI
{
    public partial class UserForm : Form
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        private List<User> _userList;
        private User _selectedUser;

        public UserForm(IAuthService authService, IUserService userService)
        {
            InitializeComponent();
            _authService = authService;
            _userService = userService;
        }

        private async void UserForm_Load(object sender, EventArgs e)
        {
            SetupDataGridView();

            await LoadDataAsync();
        }

        private void SetupDataGridView()
        {
            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.MultiSelect = false;
            dgvUsers.ReadOnly = true;
            dgvUsers.AllowUserToAddRows = false;

            dgvUsers.CellFormatting -= dgvUsers_CellFormatting;
            dgvUsers.CellFormatting += dgvUsers_CellFormatting;

            dgvUsers.Columns.Clear();
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ID", DataPropertyName = "UserID", Width = 50 });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Username", DataPropertyName = "UserName", Width = 150 });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Role", DataPropertyName = "Role", Width = 150 });
        }

        private void dgvUsers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvUsers.Columns[e.ColumnIndex].DataPropertyName == "Role" && e.Value != null)
            {
                var role = e.Value as Role;
                if (role != null)
                {
                    e.Value = role.RoleName;
                    e.FormattingApplied = true;
                }
            }
        }

        private async Task LoadDataAsync()
        {
            try
            {
                Cursor = Cursors.WaitCursor; 

                _userList = await _userService.GetAllUsersAsync();

                dgvUsers.DataSource = null;
                dgvUsers.DataSource = _userList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void dgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow != null && dgvUsers.CurrentRow.DataBoundItem != null)
            {
                _selectedUser = dgvUsers.CurrentRow.DataBoundItem as User;
                if (_selectedUser != null)
                {
                    txtUsername.Text = _selectedUser.UserName;

                    if (_selectedUser.Role != null)
                    {
                        cbRole.SelectedItem = _selectedUser.Role.RoleName;
                    }
                    else
                    {
                        cbRole.SelectedIndex = -1;
                    }

                    txtPassword.Clear();
                }
            }
        }

        private async void btnAddUser_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string role = cbRole.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Please enter Username, Password and select Role.", "Validation");
                return;
            }

            try
            {
                btnAddUser.Enabled = false; 

                bool success = await _authService.RegisterAsync(username, password, role);

                if (success)
                {
                    MessageBox.Show("User added successfully!", "Success");
                    await LoadDataAsync(); 
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show("Username already exists or Error.", "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                btnAddUser.Enabled = true;
            }
        }

        private async void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (_selectedUser == null) { MessageBox.Show("Select a user to delete."); return; }

            if (_selectedUser.UserName.ToLower() == "admin")
            {
                MessageBox.Show("Cannot delete the root Admin account.", "Restricted");
                return;
            }

            if (MessageBox.Show($"Delete user '{_selectedUser.UserName}'?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    btnDeleteUser.Enabled = false;

                    if (await _userService.DeleteUserAsync(_selectedUser.UserID))
                    {
                        MessageBox.Show("User deleted successfully!");
                        await LoadDataAsync();
                        ClearInputs();
                    }
                    else
                    {
                        MessageBox.Show("Cannot delete user (Check constraints).", "Error");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    btnDeleteUser.Enabled = true;
                }
            }
        }

        private async void btnResetPassword_Click(object sender, EventArgs e)
        {
            if (_selectedUser == null) { MessageBox.Show("Select a user to reset password."); return; }

            string newPass = txtPassword.Text;
            if (string.IsNullOrEmpty(newPass))
            {
                MessageBox.Show("Please enter the NEW password in the Password box.");
                return;
            }

            if (_selectedUser.UserID == Program.CurrentUser.UserID)
            {
                MessageBox.Show("You cannot reset your own password here.", "Restricted");
                return;
            }

            try
            {
                btnResetPassword.Enabled = false;

                if (await _userService.ResetPasswordAsync(_selectedUser.UserID, newPass))
                {
                    MessageBox.Show($"Password for '{_selectedUser.UserName}' has been reset successfully.", "Success");
                    txtPassword.Clear();
                }
                else
                {
                    MessageBox.Show("Failed to reset password.", "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                btnResetPassword.Enabled = true;
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            try
            {
                Cursor = Cursors.WaitCursor;

                var all = await _userService.GetAllUsersAsync();

                if (!string.IsNullOrEmpty(keyword))
                {
                    _userList = all.Where(u =>
                        (u.UserName != null && u.UserName.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0) ||
                        (u.Role != null && u.Role.RoleName != null && u.Role.RoleName.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                    ).ToList();
                }
                else
                {
                    _userList = all;
                }

                dgvUsers.DataSource = null;
                dgvUsers.DataSource = _userList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching: " + ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void ClearInputs()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            cbRole.SelectedIndex = -1;
            _selectedUser = null;
        }
    }
}