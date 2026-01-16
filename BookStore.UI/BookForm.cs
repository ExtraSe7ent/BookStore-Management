using BookStore.BLL;
using BookStore.Entities;
using ClosedXML.Excel;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore.UI
{
    public partial class BookForm : Form
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        private readonly IPublisherService _publisherService;
        private readonly ICategoryService _categoryService;

        private List<Book> _currentBookList;
        private Book _selectedBook;

        public BookForm(IBookService bookService,
                        IAuthorService authorService,
                        IPublisherService publisherService,
                        ICategoryService categoryService)
        {
            InitializeComponent();
            _bookService = bookService;
            _authorService = authorService;
            _publisherService = publisherService;
            _categoryService = categoryService;

            QuestPDF.Settings.License = LicenseType.Community;
        }

        private async void BookForm_Load(object sender, EventArgs e)
        {
            dgvBooks.AutoGenerateColumns = false;
            dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBooks.MultiSelect = false;
            dgvBooks.AllowUserToAddRows = false;
            dgvBooks.ReadOnly = true;

            SetupDataGridView();

            await LoadComboBoxesAsync();
            await LoadDataGridAsync();

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
            dgvBooks.Columns.Clear();
            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tên sách", DataPropertyName = "Title", Width = 250 });
            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Thể loại", DataPropertyName = "CategoryName" });
            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Giá bán", DataPropertyName = "Price", DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } });
            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tồn kho", DataPropertyName = "Stock" });
            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tác giả", DataPropertyName = "AuthorName" });
            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Nhà xuất bản", DataPropertyName = "PublisherName" });
        }

        private async Task LoadComboBoxesAsync()
        {
            try
            {
                var authors = await _authorService.GetAllAsync();
                cbAuthor.DataSource = authors;
                cbAuthor.DisplayMember = "AuthorName";
                cbAuthor.ValueMember = "AuthorID";

                var publishers = await _publisherService.GetAllAsync();
                cbPublisher.DataSource = publishers;
                cbPublisher.DisplayMember = "PublisherName";
                cbPublisher.ValueMember = "PublisherID";

                var categories = await _categoryService.GetAllAsync();
                cbCategory.DataSource = categories;
                cbCategory.DisplayMember = "CategoryName";
                cbCategory.ValueMember = "CategoryID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục: " + ex.Message);
            }
        }

        private async Task LoadDataGridAsync()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                _currentBookList = await _bookService.GetAllBooksAsync();

                dgvBooks.DataSource = null;
                dgvBooks.DataSource = _currentBookList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải sách: " + ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void dgvBooks_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvBooks.Rows[e.RowIndex].DataBoundItem is Book book)
            {
                if (dgvBooks.Columns[e.ColumnIndex].HeaderText == "Thể loại")
                    e.Value = book.Category?.CategoryName;
                if (dgvBooks.Columns[e.ColumnIndex].HeaderText == "Tác giả")
                    e.Value = book.Author?.AuthorName;
                if (dgvBooks.Columns[e.ColumnIndex].HeaderText == "Nhà xuất bản")
                    e.Value = book.Publisher?.PublisherName;
            }
        }

        private void dgvBooks_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBooks.CurrentRow != null && dgvBooks.CurrentRow.DataBoundItem != null)
            {
                _selectedBook = dgvBooks.CurrentRow.DataBoundItem as Book;
                if (_selectedBook != null)
                {
                    txtTitle.Text = _selectedBook.Title;
                    txtPrice.Text = _selectedBook.Price.ToString("0.##");
                    txtStock.Text = _selectedBook.Stock.ToString();

                    if (_selectedBook.AuthorID > 0) cbAuthor.SelectedValue = _selectedBook.AuthorID;
                    if (_selectedBook.PublisherID > 0) cbPublisher.SelectedValue = _selectedBook.PublisherID;
                    if (_selectedBook.CategoryID > 0) cbCategory.SelectedValue = _selectedBook.CategoryID;
                }
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput(out decimal price, out int stock)) return;

            var newBook = new Book
            {
                Title = txtTitle.Text.Trim(),
                Price = price,
                Stock = stock,
                AuthorID = (int)cbAuthor.SelectedValue,
                PublisherID = (int)cbPublisher.SelectedValue,
                CategoryID = (int)cbCategory.SelectedValue
            };

            try
            {
                btnAdd.Enabled = false;
                await _bookService.AddBookAsync(newBook);
                MessageBox.Show("Thêm sách thành công!", "Thông báo");
                await LoadDataGridAsync();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                // Chỉ bật lại nếu là Admin 
                if (Program.CurrentUser?.Role?.RoleName == "Admin") btnAdd.Enabled = true;
            }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (_selectedBook == null) { MessageBox.Show("Vui lòng chọn sách cần sửa."); return; }
            if (!ValidateInput(out decimal price, out int stock)) return;

            _selectedBook.Title = txtTitle.Text.Trim();
            _selectedBook.Price = price;
            _selectedBook.Stock = stock;
            _selectedBook.AuthorID = (int)cbAuthor.SelectedValue;
            _selectedBook.PublisherID = (int)cbPublisher.SelectedValue;
            _selectedBook.CategoryID = (int)cbCategory.SelectedValue;

            try
            {
                btnEdit.Enabled = false;
                await _bookService.UpdateBookAsync(_selectedBook);
                MessageBox.Show("Cập nhật thành công!");
                await LoadDataGridAsync();
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
            if (_selectedBook == null) { MessageBox.Show("Vui lòng chọn sách cần xóa."); return; }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa sách này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    btnDelete.Enabled = false;
                    await _bookService.DeleteBookAsync(_selectedBook.BookID);
                    MessageBox.Show("Xóa thành công!");
                    await LoadDataGridAsync();
                    ClearInputs();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể xóa sách (Có thể sách đã bán trong hóa đơn).\nChi tiết: " + ex.Message);
                }
                finally
                {
                    if (Program.CurrentUser?.Role?.RoleName == "Admin") btnDelete.Enabled = true;
                }
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            try
            {
                Cursor = Cursors.WaitCursor;
                _currentBookList = await _bookService.SearchBooksAsync(keyword);
                dgvBooks.DataSource = null;
                dgvBooks.DataSource = _currentBookList;
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

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (_currentBookList == null || _currentBookList.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất Excel.");
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel|*.xlsx", FileName = "DanhSachSach.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var wb = new XLWorkbook())
                        {
                            var ws = wb.Worksheets.Add("Books");
                            ws.Cell(1, 1).Value = "Tên sách";
                            ws.Cell(1, 2).Value = "Thể loại";
                            ws.Cell(1, 3).Value = "Tác giả";
                            ws.Cell(1, 4).Value = "Nhà xuất bản";
                            ws.Cell(1, 5).Value = "Giá bán";
                            ws.Cell(1, 6).Value = "Tồn kho";

                            var headerRange = ws.Range("A1:F1");
                            headerRange.Style.Font.Bold = true;
                            headerRange.Style.Fill.BackgroundColor = XLColor.LightGray;

                            int row = 2;
                            foreach (var b in _currentBookList)
                            {
                                ws.Cell(row, 1).Value = b.Title;
                                ws.Cell(row, 2).Value = b.Category?.CategoryName ?? "";
                                ws.Cell(row, 3).Value = b.Author?.AuthorName ?? "";
                                ws.Cell(row, 4).Value = b.Publisher?.PublisherName ?? "";
                                ws.Cell(row, 5).Value = b.Price;
                                ws.Cell(row, 6).Value = b.Stock;
                                row++;
                            }
                            ws.Columns().AdjustToContents();
                            wb.SaveAs(sfd.FileName);
                        }
                        MessageBox.Show("Xuất Excel thành công!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xuất Excel: " + ex.Message);
                    }
                }
            }
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            if (_currentBookList == null || _currentBookList.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất PDF.");
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF File|*.pdf", FileName = "DanhSachSach.pdf" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Document.Create(container =>
                        {
                            container.Page(page =>
                            {
                                page.Margin(50);
                                page.Size(PageSizes.A4);

                                page.Header().Text("DANH SÁCH SÁCH").FontSize(20).SemiBold().AlignCenter();

                                page.Content().PaddingVertical(10).Table(table =>
                                {
                                    table.ColumnsDefinition(columns =>
                                    {
                                        columns.RelativeColumn(3); // Title 
                                        columns.RelativeColumn(2); // Category
                                        columns.RelativeColumn(2); // Author
                                        columns.RelativeColumn(2); // Price
                                        columns.RelativeColumn(1); // Stock
                                    });

                                    table.Header(header =>
                                    {
                                        header.Cell().Element(CellStyle).Text("Tên sách").Bold();
                                        header.Cell().Element(CellStyle).Text("Thể loại").Bold();
                                        header.Cell().Element(CellStyle).Text("Tác giả").Bold();
                                        header.Cell().Element(CellStyle).AlignRight().Text("Giá bán").Bold();
                                        header.Cell().Element(CellStyle).AlignRight().Text("SL").Bold();
                                    });

                                    foreach (var book in _currentBookList)
                                    {
                                        table.Cell().Element(CellStyle).Text(book.Title);
                                        table.Cell().Element(CellStyle).Text(book.Category?.CategoryName ?? "");
                                        table.Cell().Element(CellStyle).Text(book.Author?.AuthorName ?? "");
                                        table.Cell().Element(CellStyle).AlignRight().Text(book.Price.ToString("N0"));
                                        table.Cell().Element(CellStyle).AlignRight().Text(book.Stock.ToString());
                                    }
                                });

                                page.Footer().AlignCenter().Text(x =>
                                {
                                    x.Span("Trang ");
                                    x.CurrentPageNumber();
                                });
                            });
                        }).GeneratePdf(sfd.FileName);

                        MessageBox.Show("Xuất PDF thành công!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xuất PDF: " + ex.Message);
                    }
                }
            }
        }

        static IContainer CellStyle(IContainer container)
        {
            return container.Border(1).BorderColor(Colors.Grey.Lighten2).Padding(5);
        }

        private bool ValidateInput(out decimal price, out int stock)
        {
            price = 0; stock = 0;
            if (string.IsNullOrWhiteSpace(txtTitle.Text)) { MessageBox.Show("Vui lòng nhập tên sách"); return false; }

            if (cbCategory.SelectedIndex < 0) { MessageBox.Show("Vui lòng chọn thể loại"); return false; }
            if (cbAuthor.SelectedIndex < 0) { MessageBox.Show("Vui lòng chọn tác giả"); return false; }
            if (cbPublisher.SelectedIndex < 0) { MessageBox.Show("Vui lòng chọn NXB"); return false; }

            if (!decimal.TryParse(txtPrice.Text, out price) || price < 0) { MessageBox.Show("Giá không hợp lệ"); return false; }
            if (!int.TryParse(txtStock.Text, out stock) || stock < 0) { MessageBox.Show("Số lượng tồn kho không hợp lệ"); return false; }

            return true;
        }

        private void ClearInputs()
        {
            txtTitle.Clear();
            txtPrice.Clear();
            txtStock.Clear();
            if (cbCategory.Items.Count > 0) cbCategory.SelectedIndex = 0;
            if (cbAuthor.Items.Count > 0) cbAuthor.SelectedIndex = 0;
            if (cbPublisher.Items.Count > 0) cbPublisher.SelectedIndex = 0;
            _selectedBook = null;
        }
    }
}