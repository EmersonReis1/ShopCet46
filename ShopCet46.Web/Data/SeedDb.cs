﻿using Microsoft.AspNetCore.Identity;
using ShopCet46.Web.Data.Entities;
using ShopCet46.Web.Helpers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ShopCet46.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        private readonly Random _random;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
            _random = new Random();
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            var user = await _userHelper.GetUserByEmailAsync("emerson.reis.16@gmail.com");
            if (user == null)
            {
                user = new User
                {
                    FristName = "Emerson",
                    LastName = "Reis",
                    Email = "emerson.reis.16@gmail.com",
                    UserName = "emerson.reis.16@gmail.com",
                    PhoneNumber = "9658545",
                
                };

                var result = await _userHelper.AddUserAsync(user, "123456");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder.");
                }
            }

            if (!_context.Products.Any())
            {
                this.AddProduct("Boné oficial SLB",user);
                this.AddProduct("Cueca Oficial SLB",user);
                this.AddProduct("Biquini oficial SLB",user);
                await _context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name, User user)
        {
            _context.Products.Add(new Product
            {
                Name = name,
                Price = _random.Next(500),
                IsAvailable = true,
                Stock = _random.Next(1000),
                User = user
            });
        }
    }
}
