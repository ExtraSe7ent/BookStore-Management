using BookStore.BLL;
using BookStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore.UI
{
    public partial class AuthorForm : Form
    {
        private readonly IAuthorService _authorService;

        private List<Author> _currentAuthorList;
        private Author _selectedAuthor;

        public AuthorForm(IAuthorService authorService)
        {
            InitializeComponent();
            _authorService = authorService;
        }

        private async void AuthorForm_Load(object sender, EventArgs e)
        {
            dgvAuthors.AutoGenerateColumns = false;
            dgvAuthors.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAuthors.MultiSelect = false;
            dgvAuthors.ReadOnly = true;
            dgvAuthors.AllowUserToAddRows = false;

            SetupDataGridView();
            await LoadDataAsync();

            // --- QUAN TRỌNG: Áp dụng phân quyền ---
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
            dgvAuthors.Columns.Clear();
            dgvAuthors.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tên Tác Giả", DataPropertyName = "AuthorName", Width = 250 });
            dgvAuthors.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Năm Sinh", DataPropertyName = "BirthYear", Width = 150 });
        }

        private async Task LoadDataAsync()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                _currentAuthorList = await _authorService.GetAllAsync();

                dgvAuthors.DataSource = null;
                dgvAuthors.DataSource = _currentAuthorList;
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

        private void dgvAuthors_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAuthors.CurrentRow != null && dgvAuthors.CurrentRow.DataBoundItem != null)
            {
                _selectedAuthor = dgvAuthors.CurrentRow.DataBoundItem as Author;

                if (_selectedAuthor != null)
                {
                    txtAuthorName.Text = _selectedAuthor.AuthorName;
                    if (_selectedAuthor.BirthYear.HasValue)
                    {
                        int year = _selectedAuthor.BirthYear.Value;
                        if (year >= dtpBirthDate.MinDate.Year && year <= dtpBirthDate.MaxDate.Year)
                        {
                            dtpBirthDate.Value = new DateTime(year, 1, 1);
                        }
                        dtpBirthDate.Checked = true;
                    }
                    else
                    {
                        dtpBirthDate.Checked = false;
                    }
                }
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtAuthorName.Text.Trim();
            int? birthYear = null;
            if (dtpBirthDate.Checked) birthYear = dtpBirthDate.Value.Year;

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Vui lòng nhập tên tác giả.", "Thông báo");
                return;
            }

            var newAuthor = new Author
            {
                AuthorName = name,
                BirthYear = birthYear
            };

            try
            {
                btnAdd.Enabled = false;
                await _authorService.AddAuthorAsync(newAuthor);

                MessageBox.Show("Thêm tác giả thành công!");
                await LoadDataAsync();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm tác giả: " + ex.Message);
            }
            finally
            {
                // Chỉ bật lại nếu là Admin
                if (Program.CurrentUser?.Role?.RoleName == "Admin") btnAdd.Enabled = true;
            }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (_selectedAuthor == null) { MessageBox.Show("Vui lòng chọn tác giả cần sửa."); return; }

            string name = txtAuthorName.Text.Trim();
            int? birthYear = null;
            if (dtpBirthDate.Checked) birthYear = dtpBirthDate.Value.Year;

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Tên tác giả không được để trống.");
                return;
            }

            try
            {
                btnEdit.Enabled = false;
                _selectedAuthor.AuthorName = name;
                _selectedAuthor.BirthYear = birthYear;

                await _authorService.UpdateAuthorAsync(_selectedAuthor);

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
            if (_selectedAuthor == null) { MessageBox.Show("Vui lòng chọn tác giả cần xóa."); return; }

            if (MessageBox.Show($"Bạn có chắc muốn xóa tác giả '{_selectedAuthor.AuthorName}'?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    btnDelete.Enabled = false;
                    await _authorService.DeleteAuthorAsync(_selectedAuthor.AuthorID);

                    MessageBox.Show("Xóa thành công!");
                    await LoadDataAsync();
                    ClearInputs();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể xóa tác giả này (Có thể do ràng buộc dữ liệu sách). \nChi tiết: " + ex.Message);
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
                var allAuthors = await _authorService.GetAllAsync();

                if (!string.IsNullOrEmpty(keyword))
                {
                    _currentAuthorList = allAuthors.Where(a => a.AuthorName.ToLower().Contains(keyword)).ToList();
                }
                else
                {
                    _currentAuthorList = allAuthors;
                }

                dgvAuthors.DataSource = null;
                dgvAuthors.DataSource = _currentAuthorList;
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

        private void ClearInputs()
        {
            txtAuthorName.Clear();
            dtpBirthDate.Checked = false;
            _selectedAuthor = null;
        }
    }
}