using BookStore.BLL;
using BookStore.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore.UI
{
    public partial class CustomerForm : Form
    {
        private readonly ICustomerService _customerService;
        private List<Customer> _currentList;
        private Customer _selectedCustomer;

        public CustomerForm(ICustomerService customerService)
        {
            InitializeComponent();
            _customerService = customerService;
        }

        private async void CustomerForm_Load(object sender, EventArgs e)
        {
            dgvCustomers.AutoGenerateColumns = false;
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomers.MultiSelect = false;
            dgvCustomers.ReadOnly = true;
            dgvCustomers.AllowUserToAddRows = false;

            SetupDataGridView();
            await LoadDataAsync();
        }

        private void SetupDataGridView()
        {
            dgvCustomers.Columns.Clear();
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ID", DataPropertyName = "CustomerID", Width = 50 });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Full Name", DataPropertyName = "FullName", Width = 200 });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Phone", DataPropertyName = "Phone", Width = 150 });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Address", DataPropertyName = "Address", Width = 300 });
        }

        private async Task LoadDataAsync()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                _currentList = await _customerService.GetAllCustomersAsync();

                dgvCustomers.DataSource = null;
                dgvCustomers.DataSource = _currentList;

                dgvCustomers.ClearSelection(); 
                ClearInputs();                 
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

        private void dgvCustomers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count > 0 && dgvCustomers.CurrentRow != null && dgvCustomers.CurrentRow.DataBoundItem != null)
            {
                _selectedCustomer = dgvCustomers.CurrentRow.DataBoundItem as Customer;
                if (_selectedCustomer != null)
                {
                    txtFullName.Text = _selectedCustomer.FullName;
                    txtPhone.Text = _selectedCustomer.Phone;
                    txtAddress.Text = _selectedCustomer.Address;
                }
            }
            else
            {
                ClearInputs();
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            var newCus = new Customer
            {
                FullName = txtFullName.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Address = txtAddress.Text.Trim()
            };

            try
            {
                btnAdd.Enabled = false;
                await _customerService.AddCustomerAsync(newCus);

                MessageBox.Show("Customer added successfully!", "Success");
                await LoadDataAsync();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to add: " + ex.Message, "Error");
            }
            finally
            {
                btnAdd.Enabled = true;
            }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (_selectedCustomer == null) { MessageBox.Show("Please select a customer first."); return; }
            if (!ValidateInput()) return;

            _selectedCustomer.FullName = txtFullName.Text.Trim();
            _selectedCustomer.Phone = txtPhone.Text.Trim();
            _selectedCustomer.Address = txtAddress.Text.Trim();

            try
            {
                btnEdit.Enabled = false;
                await _customerService.UpdateCustomerAsync(_selectedCustomer);

                MessageBox.Show("Updated successfully!");
                await LoadDataAsync();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to update: " + ex.Message, "Error");
            }
            finally
            {
                btnEdit.Enabled = true;
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedCustomer == null) { MessageBox.Show("Please select a customer first."); return; }

            if (MessageBox.Show($"Are you sure you want to delete '{_selectedCustomer.FullName}'?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    btnDelete.Enabled = false;
                    await _customerService.DeleteCustomerAsync(_selectedCustomer.CustomerID);

                    MessageBox.Show("Deleted successfully!");
                    await LoadDataAsync();
                    ClearInputs();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cannot delete customer (Constraint Error): " + ex.Message, "Error");
                }
                finally
                {
                    btnDelete.Enabled = true;
                }
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string key = txtSearch.Text.Trim().ToLower();

            try
            {
                Cursor = Cursors.WaitCursor;
                _currentList = await _customerService.SearchCustomerAsync(key);

                dgvCustomers.DataSource = null;
                dgvCustomers.DataSource = _currentList;

                dgvCustomers.ClearSelection();
                ClearInputs();
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

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Full Name is required.", "Validation");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Phone Number is required.", "Validation");
                return false;
            }
            return true;
        }

        private void ClearInputs()
        {
            txtFullName.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            _selectedCustomer = null;
        }
    }
}