using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Entities
{
    [Table("InvoiceDetails")]
    public class InvoiceDetail
    {
        [Key]
        public int DetailID { get; set; }

        public int InvoiceID { get; set; }
        [ForeignKey("InvoiceID")]
        public virtual Invoice Invoice { get; set; }

        public int BookID { get; set; }
        [ForeignKey("BookID")]
        public virtual Book Book { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; } 
    }
}