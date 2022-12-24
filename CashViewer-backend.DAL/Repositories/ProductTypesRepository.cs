﻿using CashViewer_backend.DAL.Context;
using CashViewer_backend.DAL.Entities;
using CashViewer_backend.DAL.Repositories.Base;

namespace CashViewer_backend.DAL.Repositories
{
    public class ProductTypesRepository : Repository<ProductType>
    {
        public ProductTypesRepository(ApplicationDbContext db) : base(db) { }
    }
}
