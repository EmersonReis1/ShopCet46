﻿using Microsoft.EntityFrameworkCore;
using ShopCet46.Web.Data.Entities;
using System.Linq;

namespace ShopCet46.Web.Data
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable GetAllWithUsers()
        {
            return _context.Products.Include(p => p.User);
        }
    }
}
