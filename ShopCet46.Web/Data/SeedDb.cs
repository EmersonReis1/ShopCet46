using Microsoft.EntityFrameworkCore;
using ShopCet46.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopCet46.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        private Random _random;

        public SeedDb(DataContext context)
        {
            _context = context;
            _random = new Random();
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            if (!_context.Products.Any())
            {
                this.AddProduct("Boné oficial SLB");
                this.AddProduct("Cueca Oficial SLB");
                this.AddProduct("Biquini oficial SLB");
                await _context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name)
        {
            _context.Products.Add(new Product 
            { 
                Name = name,
                Price = _random.Next(500),
                IsAvailable = true,
                Stock = _random.Next(1000)
            });
        }
    }
}
