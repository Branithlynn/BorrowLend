using BorrowLend.DataBaseAccess;
using BorrowLend.Entity;
using System.Data.Entity;
using System.Linq.Expressions;

namespace BorrowLend.Repository
{
    public class ItemRepository
    {
        public List<Item> GetAll(Expression<Func<Item, bool>> filter = null, int page = 1, int pageSize = int.MaxValue)
        {
            Context context = new Context();
            IQueryable<Item> query = context.Items;
            if (filter != null)
                query = query.Where(filter);

            return query.OrderBy(x => x.Id).Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
        public int UsersCount(Expression<Func<Item, bool>> filter = null)
        {
            Context context = new Context();
            IQueryable<Item> query = context.Items;

            if (filter != null)
                query = query.Where(filter);

            return query.Count();
        }
        public void Add(Item item)
        {
            Context context = new Context();

            Item newItem = new Item();
            newItem.Name = item.Name;
            newItem.Borrower = item.Borrower;
            newItem.Lender = item.Lender;
            context.Items.Add(newItem);

            context.SaveChanges();
        }
        public void Delete(int id)
        {
            Context context = new Context();

            Item item = context.Items.Find(id);

            context.Items.Remove(item);
            context.SaveChanges();
        }
        public void Update(Item item)
        {
            Context context = new Context();

            Item oldItem = context.Items.Find(item.Id);

            oldItem.Name = item.Name;
            oldItem.Borrower = item.Borrower;
            oldItem.Lender = item.Lender;
            context.Entry(item).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
