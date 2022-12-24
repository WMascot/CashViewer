using CashViewer_backend.DAL.Context;
using CashViewer_backend.DAL.Entities;
using CashViewer_backend.DAL.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace CashViewer_backend.DAL.Repositories
{
    public class ShopsRepository : Repository<Shop>
    {
        public ShopsRepository(ApplicationDbContext db) : base(db) { }
        public override IQueryable<Shop> Items => base.Items.Include(item => item.Products)
                                                            .Include(item => item.Type);
    }
}
