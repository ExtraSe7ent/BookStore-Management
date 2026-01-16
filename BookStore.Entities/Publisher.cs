using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Entities
{
    [Table("Publishers")]
    public class Publisher
    {
        [Key]
        public int PublisherID { get; set; }

        [Required]
        [StringLength(100)]
        public string PublisherName { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}