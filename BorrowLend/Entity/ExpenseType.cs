using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BorrowLend.Entity
{
    [Table("ExpenseTypes")]
    public class ExpenseType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
