using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Entities
{
    [Table("Authors")]
    public class Author
    {
        [Key]
        public int AuthorID { get; set; }

        [Required]
        [StringLength(100)]
        public string AuthorName { get; set; }

        public int? BirthYear { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}