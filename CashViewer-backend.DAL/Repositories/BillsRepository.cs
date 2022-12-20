using CashViewer_backend.DAL.Context;
using CashViewer_backend.DAL.Entities;
using CashViewer_backend.DAL.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace CashViewer_backend.DAL.Repositories
{
    public class BillsRepository : Repository<Bill>
    {
        public BillsRepository(ApplicationDbContext db) : base(db) { }
        public override IQueryable<Bill> Items => base.Items.Include(item => item.ProductList);
    }
}
