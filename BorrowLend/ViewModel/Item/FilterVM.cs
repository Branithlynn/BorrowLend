using BorrowLend.Entity;
using System.Linq.Expressions;

namespace BorrowLend.ViewModel.ItemVM
{
    public class FilterVM
    {
        public string  name { get; set; }
        public string borrower { get; set; }
        public string lender { get; set; }
        public Expression<Func<Item,bool>> GetFilter()
        {
            return i => (string.IsNullOrEmpty(name) || i.Name.Contains(name)) &&
                        (string.IsNullOrEmpty(borrower) || i.Borrower.Contains(borrower) &&
                        (string.IsNullOrEmpty(lender) || i.Lender.Contains(lender)));

        }
    }
}
