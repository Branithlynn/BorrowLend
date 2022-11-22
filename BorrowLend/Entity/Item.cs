using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BorrowLend.Entity
{
    [Table("Items")]
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Borrower { get; set; }
        public string Lender { get; set; }
    }
}
