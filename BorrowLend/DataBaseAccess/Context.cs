using BorrowLend.Entity;
using System.Data.Entity;

namespace BorrowLend.DataBaseAccess
{
    public class Context :DbContext
    {

        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseType> ExpenseTypes { get; set; }
        public DbSet<Item> Items { get; set; }

        public Context() : base("Server = localhost\\sqlexpress; Database=BorrowLend;Trusted_Connection=True;")
        {
            Expenses = this.Set<Expense>();
            ExpenseTypes = this.Set<ExpenseType>();
            Items = this.Set<Item>();
        }
    }
}
