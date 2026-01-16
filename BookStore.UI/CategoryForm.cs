using BookStore.BLL;
using BookStore.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore.UI
{
    public partial class CategoryForm : Form
    {
        private readonly ICategoryService _categoryService;
        private BookCategory _selectedCategory;

        public CategoryForm(ICategoryService categoryService)
        {
            InitializeComponent();
            _categoryService = categoryService;
        }

        private async void CategoryForm_Load(object sender, EventArgs e)
        {
            dgvCategories.AutoGenerateColumns = false;
            dgvCategories.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategories.MultiSelect = false;
            dgvCategories.ReadOnly = true;
            dgvCategories.AllowUserToAddRows = false;

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
            dgvCategories.Columns.Clear();
            dgvCategories.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã", DataPropertyName = "CategoryID", Width = 50 });
            dgvCategories.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tên Thể Loại", DataPropertyName = "CategoryName", Width = 300 });
        }

        private async Task LoadDataAsync()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                var list = await _categoryService.GetAllAsync();

                dgvCategories.DataSource = null;
                dgvCategories.DataSource = list;
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

        private void dgvCategories_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCategories.CurrentRow != null && dgvCategories.CurrentRow.DataBoundItem != null)
            {
                _selectedCategory = dgvCategories.CurrentRow.DataBoundItem as BookCategory;
                if (_selectedCategory != null)
                {
                    txtID.Text = _selectedCategory.CategoryID.ToString();
                    txtName.Text = _selectedCategory.CategoryName;
                }
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            if (string.IsNullOrEmpty(name)) { MessageBox.Show("Vui lòng nhập tên thể loại"); return; }

            try
            {
                btnAdd.Enabled = false;
                var newCat = new BookCategory { CategoryName = name };
                await _categoryService.AddCategoryAsync(newCat);

                MessageBox.Show("Thêm thể loại thành công!");
                await LoadDataAsync();
                ClearInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm: " + ex.Message);
            }
            finally
            {
                // Chỉ bật lại nếu là Admin
                if (Program.CurrentUser?.Role?.RoleName == "Admin") btnAdd.Enabled = true;
            }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (_selectedCategory == null) { MessageBox.Show("Vui lòng chọn thể loại cần sửa."); return; }
            string name = txtName.Text.Trim();
            if (string.IsNullOrEmpty(name)) { MessageBox.Show("Vui lòng nhập tên thể loại"); return; }

            try
            {
                btnEdit.Enabled = false;
                _selectedCategory.CategoryName = name;
                await _categoryService.UpdateCategoryAsync(_selectedCategory);

                MessageBox.Show("Cập nhật thành công!");
                await LoadDataAsync();
                ClearInput();
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
            if (_selectedCategory == null) { MessageBox.Show("Vui lòng chọn thể loại cần xóa."); return; }

            if (MessageBox.Show($"Bạn có chắc muốn xóa thể loại '{_selectedCategory.CategoryName}'?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    btnDelete.Enabled = false;
                    await _categoryService.DeleteCategoryAsync(_selectedCategory.CategoryID);

                    MessageBox.Show("Xóa thành công!");
                    await LoadDataAsync();
                    ClearInput();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể xóa thể loại này (Đang có sách thuộc thể loại này).", "Lỗi");
                }
                finally
                {
                    if (Program.CurrentUser?.Role?.RoleName == "Admin") btnDelete.Enabled = true;
                }
            }
        }

        private void ClearInput()
        {
            txtID.Clear();
            txtName.Clear();
            _selectedCategory = null;
        }
    }
}