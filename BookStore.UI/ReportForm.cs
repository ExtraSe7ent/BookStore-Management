using BookStore.BLL;
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
    public partial class ReportForm : Form
    {
        private readonly IReportService _reportService;
        private List<BookRevenueDto> _reportData;

        public ReportForm(IReportService reportService)
        {
            InitializeComponent();
            _reportService = reportService;
            QuestPDF.Settings.License = LicenseType.Community;
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpTo.Value = DateTime.Now;

            lblTotalRevenue.Text = "0 đ";
            SetupDataGridView();
        }

        private void SetupDataGridView()
        {
            dgvReport.AutoGenerateColumns = false;
            dgvReport.AllowUserToAddRows = false;
            dgvReport.AllowUserToDeleteRows = false;
            dgvReport.ReadOnly = true;
            dgvReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvReport.Columns.Clear();
            dgvReport.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Book Title", DataPropertyName = "BookTitle", Width = 250 });
            dgvReport.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Genre", DataPropertyName = "Genre", Width = 150 });
            dgvReport.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Sold Qty", DataPropertyName = "TotalSold", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter } });
            dgvReport.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Revenue", DataPropertyName = "TotalRevenue", Width = 150, DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight } });
        }

        private void cbAllTime_CheckedChanged(object sender, EventArgs e)
        {
            bool isAllTime = cbAllTime.Checked;
            dtpFrom.Enabled = !isAllTime;
            dtpTo.Enabled = !isAllTime;
        }

        private async void btnGenerateReport_Click(object sender, EventArgs e)
        {
            DateTime? fromDate = cbAllTime.Checked ? (DateTime?)null : dtpFrom.Value.Date;
            DateTime? toDate = cbAllTime.Checked ? (DateTime?)null : dtpTo.Value.Date;

            try
            {
                btnGenerateReport.Enabled = false;
                btnGenerateReport.Text = "Loading...";
                Cursor = Cursors.WaitCursor;

                _reportData = await _reportService.GetBookRevenueReportAsync(fromDate, toDate);

                if (_reportData == null || _reportData.Count == 0)
                {
                    MessageBox.Show("No data found.", "Info");
                    dgvReport.DataSource = null;
                    lblTotalRevenue.Text = "0 đ";
                }
                else
                {
                    dgvReport.DataSource = _reportData;
                    decimal total = _reportData.Sum(x => x.TotalRevenue);
                    lblTotalRevenue.Text = total.ToString("N0") + " đ";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                btnGenerateReport.Enabled = true;
                btnGenerateReport.Text = "View Report";
                Cursor = Cursors.Default;
            }
        }

        private async void btnExportExcelReport_Click(object sender, EventArgs e)
        {
            if (_reportData == null || _reportData.Count == 0) { MessageBox.Show("No data to export."); return; }

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel|*.xlsx", FileName = "BookRevenueReport.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        btnExportExcelReport.Enabled = false;
                        Cursor = Cursors.WaitCursor;

                        await Task.Run(() =>
                        {
                            using (var wb = new XLWorkbook())
                            {
                                var ws = wb.Worksheets.Add("BookRevenue");
                                ws.Cell(1, 1).Value = "Book Title";
                                ws.Cell(1, 2).Value = "Genre";
                                ws.Cell(1, 3).Value = "Quantity Sold";
                                ws.Cell(1, 4).Value = "Total Revenue";
                                ws.Range("A1:D1").Style.Font.Bold = true;

                                int row = 2;
                                foreach (var item in _reportData)
                                {
                                    ws.Cell(row, 1).Value = item.BookTitle;
                                    ws.Cell(row, 2).Value = item.Genre;
                                    ws.Cell(row, 3).Value = item.TotalSold;
                                    ws.Cell(row, 4).Value = item.TotalRevenue;
                                    row++;
                                }
                                ws.Column(4).Style.NumberFormat.Format = "#,##0";
                                ws.Columns().AdjustToContents();
                                wb.SaveAs(sfd.FileName);
                            }
                        });

                        MessageBox.Show("Export Excel Success!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                    finally
                    {
                        btnExportExcelReport.Enabled = true;
                        Cursor = Cursors.Default;
                    }
                }
            }
        }

        private async void btnExportPdfReport_Click(object sender, EventArgs e)
        {
            if (_reportData == null || _reportData.Count == 0) { MessageBox.Show("No data to export."); return; }

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF|*.pdf", FileName = "BookRevenueReport.pdf" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        btnExportPdfReport.Enabled = false;
                        Cursor = Cursors.WaitCursor;

                        await Task.Run(() =>
                        {
                            Document.Create(container =>
                            {
                                container.Page(page =>
                                {
                                    page.Margin(30);
                                    page.Size(PageSizes.A4);
                                    page.Header().Text("BOOK REVENUE REPORT").FontSize(20).Bold().AlignCenter();

                                    page.Content().PaddingVertical(20).Table(table =>
                                    {
                                        table.ColumnsDefinition(columns =>
                                        {
                                            columns.RelativeColumn(3);
                                            columns.RelativeColumn(2);
                                            columns.RelativeColumn(1);
                                            columns.RelativeColumn(2);
                                        });

                                        table.Header(header =>
                                        {
                                            header.Cell().Element(CellStyle).Text("Book Title").Bold();
                                            header.Cell().Element(CellStyle).Text("Genre").Bold();
                                            header.Cell().Element(CellStyle).AlignRight().Text("Qty").Bold();
                                            header.Cell().Element(CellStyle).AlignRight().Text("Revenue").Bold();
                                        });

                                        foreach (var item in _reportData)
                                        {
                                            table.Cell().Element(CellStyle).Text(item.BookTitle);
                                            table.Cell().Element(CellStyle).Text(item.Genre);
                                            table.Cell().Element(CellStyle).AlignRight().Text(item.TotalSold.ToString());
                                            table.Cell().Element(CellStyle).AlignRight().Text(item.TotalRevenue.ToString("N0"));
                                        }

                                        table.Footer(footer =>
                                        {
                                            decimal total = _reportData.Sum(x => x.TotalRevenue);

                                            footer.Cell().ColumnSpan(3).Element(CellStyle).Text("Total:").Bold().AlignRight();
                                            footer.Cell().Element(CellStyle).AlignRight().Text(total.ToString("N0") + " đ").Bold();
                                        });
                                    });
                                });
                            }).GeneratePdf(sfd.FileName);
                        });

                        MessageBox.Show("Export PDF Success!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                    finally
                    {
                        btnExportPdfReport.Enabled = true;
                        Cursor = Cursors.Default;
                    }
                }
            }
        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            btnExportPdfReport_Click(sender, e);
        }

        static IContainer CellStyle(IContainer container)
        {
            return container.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5);
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}