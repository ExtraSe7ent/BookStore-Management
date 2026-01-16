using BookStore.BLL;
using BookStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore.UI
{
    public partial class PublisherForm : Form
    {
        private readonly IPublisherService _publisherService;
        private List<Publisher> _currentPublisherList;
        private Publisher _selectedPublisher;

        public PublisherForm(IPublisherService publisherService)
        {
            InitializeComponent();
            _publisherService = publisherService;
        }

        private async void PublisherForm_Load(object sender, EventArgs e)
        {
            dgvPublishers.AutoGenerateColumns = false;
            dgvPublishers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPublishers.MultiSelect = false;
            dgvPublishers.ReadOnly = true;
            dgvPublishers.AllowUserToAddRows = false;

            SetupDataGridView();
            await LoadDataAsync();

            ApplyAuthorization();
        }

        // Hàm kiểm tra quyền hạn (Admin/Staff)
        private void ApplyAuthorization()
        {
            // Nếu là Staff (Nhân viên) -> Chỉ được xem, không được Thêm/Sửa/Xóa
            if (Program.CurrentUser?.Role?.RoleName == "Staff")
            {
                btnAdd.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private void SetupDataGridView()
        {
            dgvPublishers.Columns.Clear();
            dgvPublishers.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ID", DataPropertyName = "PublisherID", Width = 50 });
            dgvPublishers.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tên Nhà Xuất Bản", DataPropertyName = "PublisherName", Width = 250 });
            dgvPublishers.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Địa Chỉ", DataPropertyName = "Address", Width = 300 });
        }

        private async Task LoadDataAsync()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                _currentPublisherList = await _publisherService.GetAllAsync();

                dgvPublishers.DataSource = null;
                dgvPublishers.DataSource = _currentPublisherList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void dgvPublishers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPublishers.CurrentRow != null && dgvPublishers.CurrentRow.DataBoundItem != null)
            {
                _selectedPublisher = dgvPublishers.CurrentRow.DataBoundItem as Publisher;

                if (_selectedPublisher != null)
                {
                    txtPublisherName.Text = _selectedPublisher.PublisherName;
                    txtAddress.Text = _selectedPublisher.Address;
                }
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            var newPublisher = new Publisher
            {
                PublisherName = txtPublisherName.Text.Trim(),
                Address = txtAddress.Text.Trim()
            };

            try
            {
                btnAdd.Enabled = false;
                await _publisherService.AddPublisherAsync(newPublisher);

                MessageBox.Show("Thêm Nhà xuất bản thành công!");
                await LoadDataAsync();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm NXB: " + ex.Message, "Lỗi");
            }
            finally
            {
                // Chỉ bật lại nếu là Admin
                if (Program.CurrentUser?.Role?.RoleName == "Admin") btnAdd.Enabled = true;
            }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (_selectedPublisher == null) { MessageBox.Show("Vui lòng chọn NXB cần sửa."); return; }
            if (!ValidateInput()) return;

            _selectedPublisher.PublisherName = txtPublisherName.Text.Trim();
            _selectedPublisher.Address = txtAddress.Text.Trim();

            try
            {
                btnEdit.Enabled = false;
                await _publisherService.UpdatePublisherAsync(_selectedPublisher);

                MessageBox.Show("Cập nhật thành công!");
                await LoadDataAsync();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật: " + ex.Message);
            }
            finally
            {
                if (Program.CurrentUser?.Role?.RoleName == "Admin") btnEdit.Enabled = true;
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedPublisher == null) { MessageBox.Show("Vui lòng chọn NXB cần xóa."); return; }

            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa NXB '{_selectedPublisher.PublisherName}'?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    btnDelete.Enabled = false;
                    await _publisherService.DeletePublisherAsync(_selectedPublisher.PublisherID);

                    MessageBox.Show("Xóa thành công!");
                    await LoadDataAsync();
                    ClearInputs();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể xóa NXB này (Do ràng buộc dữ liệu sách).", "Lỗi");
                }
                finally
                {
                    if (Program.CurrentUser?.Role?.RoleName == "Admin") btnDelete.Enabled = true;
                }
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToLower();

            try
            {
                Cursor = Cursors.WaitCursor;
                var all = await _publisherService.GetAllAsync();

                if (!string.IsNullOrEmpty(keyword))
                {
                    _currentPublisherList = all.Where(p => p.PublisherName.ToLower().Contains(keyword)).ToList();
                }
                else
                {
                    _currentPublisherList = all;
                }

                dgvPublishers.DataSource = null;
                dgvPublishers.DataSource = _currentPublisherList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtPublisherName.Text))
            {
                MessageBox.Show("Tên Nhà xuất bản không được để trống.");
                return false;
            }
            return true;
        }

        private void ClearInputs()
        {
            txtPublisherName.Clear();
            txtAddress.Clear();
            _selectedPublisher = null;
        }
    }
}