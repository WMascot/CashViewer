using CashViewer_backend.DAL.Context;
using CashViewer_backend.DAL.Entities;
using CashViewer_backend.DAL.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace CashViewer_backend.DAL.Repositories
{
    public class BillProductsRepository : Repository<BillProduct>
    {
        public BillProductsRepository(ApplicationDbContext db) : base(db) { }
        public override IQueryable<BillProduct> Items => base.Items.Include(item => item.Product);
    }
}
