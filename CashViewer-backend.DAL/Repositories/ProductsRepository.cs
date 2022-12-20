using CashViewer_backend.DAL.Context;
using CashViewer_backend.DAL.Entities;
using CashViewer_backend.DAL.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace CashViewer_backend.DAL.Repositories
{
    public class ProductsRepository : Repository<Product>
    {
        public ProductsRepository(ApplicationDbContext db) : base(db) { }
        public override IQueryable<Product> Items => base.Items.Include(item => item.Shop);
    }
}
