using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Entities
{
    [Table("Books")]
    public class Book
    {
        [Key]
        public int BookID { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; } 

        public int CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public virtual BookCategory Category { get; set; }

        public int AuthorID { get; set; }
        [ForeignKey("AuthorID")]
        public virtual Author Author { get; set; }

        public int PublisherID { get; set; }
        [ForeignKey("PublisherID")]
        public virtual Publisher Publisher { get; set; }

        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}