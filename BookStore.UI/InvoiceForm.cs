using BookStore.BLL;
using BookStore.Entities;
using Microsoft.Extensions.DependencyInjection; 
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore.UI
{
    public partial class InvoiceForm : Form
    {
        private readonly IBookService _bookService;
        private readonly ICustomerService _customerService;
        private readonly IInvoiceService _invoiceService;

        private List<(Book Book, int Quantity, decimal UnitPrice)> _cartItems = new List<(Book, int, decimal)>();

        private decimal _totalAmount = 0;
        private int _lastSavedInvoiceId = 0;

        public InvoiceForm(IBookService bookService, ICustomerService customerService, IInvoiceService invoiceService)
        {
            InitializeComponent();
            _bookService = bookService;
            _customerService = customerService;
            _invoiceService = invoiceService;
        }

        private async void InvoiceForm_Load(object sender, EventArgs e)
        {
            txtStaff.Text = Program.CurrentUser?.UserName ?? "Unknown";
            lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            numQuantity.Value = 1;

            SetupDataGridView();

            await LoadCustomersAsync();
            await LoadBooksAsync();
        }

        private void SetupDataGridView()
        {
            dgvItems.AutoGenerateColumns = false;
            dgvItems.AllowUserToAddRows = false;
            dgvItems.ReadOnly = true;
            dgvItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvItems.Columns.Clear();
            dgvItems.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Book Title", DataPropertyName = "BookTitle", Width = 250 });
            dgvItems.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Qty", DataPropertyName = "Quantity", Width = 50 });
            dgvItems.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Price", DataPropertyName = "UnitPrice", DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } });
            dgvItems.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Total", DataPropertyName = "Total", DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } });

            var btnDelete = new DataGridViewButtonColumn();
            btnDelete.HeaderText = "Action";
            btnDelete.Name = "DeleteColumn";
            btnDelete.Text = "Remove";
            btnDelete.UseColumnTextForButtonValue = true;
            btnDelete.Width = 80;
            dgvItems.Columns.Add(btnDelete);
        }

        private async Task LoadCustomersAsync()
        {
            try
            {
                var allCustomers = await _customerService.GetAllCustomersAsync();
                var customers = allCustomers
                    .Select(c => new
                    {
                        c.CustomerID,
                        DisplayText = $"{c.FullName} - {c.Phone}"
                    })
                    .ToList();

                cbCustomer.DataSource = customers;
                cbCustomer.DisplayMember = "DisplayText";
                cbCustomer.ValueMember = "CustomerID";

                SetupComboBox(cbCustomer);

                cbCustomer.SelectedIndex = -1;
                cbCustomer.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customers: " + ex.Message);
            }
        }

        private async Task LoadBooksAsync()
        {
            try
            {
                var allBooks = await _bookService.GetAllBooksAsync();
                var books = allBooks
                    .Where(b => b.Stock > 0)
                    .Select(b => new
                    {
                        b.BookID,
                        b.Title,
                        b.Price,
                        b.Stock,
                        DisplayText = $"{b.Title}  |  {b.Price:N0} đ  |  Stock: {b.Stock}"
                    })
                    .ToList();

                cbBook.DataSource = books;
                cbBook.DisplayMember = "DisplayText";
                cbBook.ValueMember = "BookID";

                SetupComboBox(cbBook);

                cbBook.SelectedIndex = -1;
                cbBook.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading books: " + ex.Message);
            }
        }

        private void SetupComboBox(ComboBox cb)
        {
            cb.DropDownStyle = ComboBoxStyle.DropDown;
            cb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cb.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private async void btnAddNewCustomer_Click(object sender, EventArgs e)
        {
            using (var scope = Program.ServiceProvider.CreateScope())
            {
                var customerForm = scope.ServiceProvider.GetRequiredService<CustomerForm>();

                customerForm.StartPosition = FormStartPosition.CenterParent;
                customerForm.ShowDialog(this);

                await LoadCustomersAsync();

            }
        }

        private async void btnAddItem_Click(object sender, EventArgs e)
        {
            if (cbBook.SelectedValue == null) { MessageBox.Show("Please select a book."); return; }

            int bookId;
            if (cbBook.SelectedValue != null && int.TryParse(cbBook.SelectedValue.ToString(), out bookId))
            {
            }
            else
            {
                MessageBox.Show("Invalid Book Selection"); return;
            }

            try
            {
                btnAddItem.Enabled = false;

                var allBooks = await _bookService.GetAllBooksAsync();
                var selectedBook = allBooks.FirstOrDefault(b => b.BookID == bookId);

                if (selectedBook == null) return;

                int qty = (int)numQuantity.Value;
                if (qty <= 0) return;

                if (selectedBook.Stock < qty)
                {
                    MessageBox.Show($"Not enough stock. Current: {selectedBook.Stock}", "Stock Warning");
                    return;
                }

                var existingItem = _cartItems.FirstOrDefault(x => x.Book.BookID == selectedBook.BookID);
                if (existingItem.Book != null)
                {
                    MessageBox.Show("Book already in cart. Remove to change quantity.");
                    return;
                }

                _cartItems.Add((selectedBook, qty, selectedBook.Price));
                UpdateGridAndTotal();
                numQuantity.Value = 1;

                cbBook.SelectedIndex = -1;
                cbBook.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking stock: " + ex.Message);
            }
            finally
            {
                btnAddItem.Enabled = true;
            }
        }

        private void dgvItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvItems.Columns["DeleteColumn"].Index)
            {
                _cartItems.RemoveAt(e.RowIndex);
                UpdateGridAndTotal();
            }
        }

        private void UpdateGridAndTotal()
        {
            _totalAmount = 0;
            var displayList = new List<object>();

            foreach (var item in _cartItems)
            {
                decimal total = item.Quantity * item.UnitPrice;
                _totalAmount += total;

                displayList.Add(new
                {
                    BookTitle = item.Book.Title,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                    Total = total
                });
            }

            lblTotal.Text = _totalAmount.ToString("N0") + " đ";

            dgvItems.DataSource = null;
            dgvItems.DataSource = displayList;
        }

        private async void btnSaveInvoice_Click(object sender, EventArgs e)
        {
            if (cbCustomer.SelectedValue == null) { MessageBox.Show("Select Customer."); return; }
            if (_cartItems.Count == 0) { MessageBox.Show("Cart is empty."); return; }

            int customerId;
            if (!int.TryParse(cbCustomer.SelectedValue.ToString(), out customerId))
            {
                MessageBox.Show("Invalid Customer."); return;
            }

            try
            {
                btnSaveInvoice.Enabled = false;
                btnAddItem.Enabled = false;
                dgvItems.Enabled = false;
                Cursor = Cursors.WaitCursor;

                var invoice = new Invoice
                {
                    CustomerID = customerId,
                    UserID = Program.CurrentUser.UserID,
                    Date = DateTime.Now,
                    TotalAmount = _totalAmount
                };

                var details = _cartItems.Select(x => new InvoiceDetail
                {
                    BookID = x.Book.BookID,
                    Quantity = x.Quantity,
                    UnitPrice = x.UnitPrice
                }).ToList();

                await _invoiceService.CreateInvoiceAsync(invoice, details);

                MessageBox.Show($"Invoice saved successfully! ID: {invoice.InvoiceID}", "Success");
                _lastSavedInvoiceId = invoice.InvoiceID;

                btnPrintInvoice.Enabled = true;

                _cartItems.Clear();
                UpdateGridAndTotal();

                cbCustomer.SelectedIndex = -1;
                cbBook.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save invoice:\n" + ex.Message, "Transaction Error");

                btnSaveInvoice.Enabled = true;
                btnAddItem.Enabled = true;
                dgvItems.Enabled = true;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnPrintInvoice_Click(object sender, EventArgs e)
        {
            if (_lastSavedInvoiceId == 0) return;

            PrintDocument printDoc = new PrintDocument();
            printDoc.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1169);

            printDoc.PrintPage += (s, ev) =>
            {
                Graphics g = ev.Graphics;
                float y = 50;
                float x = 50;
                float w = ev.PageBounds.Width;

                using var fontTitle = new Font("Arial", 18, FontStyle.Bold);
                using var fontHeader = new Font("Arial", 12, FontStyle.Bold);
                using var fontNormal = new Font("Arial", 12);

                g.DrawString("BOOKSTORE INVOICE", fontTitle, Brushes.Black, x, y); y += 40;
                g.DrawString($"Invoice ID: #{_lastSavedInvoiceId}", fontNormal, Brushes.Black, x, y); y += 25;
                g.DrawString($"Date: {DateTime.Now:dd/MM/yyyy HH:mm}", fontNormal, Brushes.Black, x, y); y += 25;
                g.DrawString($"Staff: {txtStaff.Text}", fontNormal, Brushes.Black, x, y); y += 25;
                g.DrawString($"Customer: {cbCustomer.Text}", fontNormal, Brushes.Black, x, y); y += 40;

                float col1 = x;
                float col2 = x + 300;
                float col3 = x + 400;
                float col4 = x + 550;

                g.DrawString("Book Title", fontHeader, Brushes.Black, col1, y);
                g.DrawString("Qty", fontHeader, Brushes.Black, col2, y);
                g.DrawString("Price", fontHeader, Brushes.Black, col3, y);
                g.DrawString("Total", fontHeader, Brushes.Black, col4, y);
                y += 25;
                g.DrawLine(Pens.Black, x, y, w - 50, y); y += 10;


                foreach (var item in _cartItems)
                {
                    g.DrawString(item.Book.Title, fontNormal, Brushes.Black, col1, y);
                    g.DrawString(item.Quantity.ToString(), fontNormal, Brushes.Black, col2, y);
                    g.DrawString(item.UnitPrice.ToString("N0"), fontNormal, Brushes.Black, col3, y);
                    g.DrawString((item.Quantity * item.UnitPrice).ToString("N0"), fontNormal, Brushes.Black, col4, y);
                    y += 30;
                }

                y += 20;
                g.DrawLine(Pens.Black, x, y, w - 50, y); y += 10;
                g.DrawString($"TOTAL AMOUNT: {_totalAmount:N0} VND", fontTitle, Brushes.Black, col3 - 50, y);
            };

            PrintPreviewDialog previewDlg = new PrintPreviewDialog();
            previewDlg.Document = printDoc;
            previewDlg.Width = 800;
            previewDlg.Height = 600;
            previewDlg.ShowDialog(this);
        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }

        private void txtStaff_TextChanged(object sender, EventArgs e)
        {

        }
    }
}