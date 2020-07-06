using System;
using System.Collections.Generic;
using System.Text;

namespace ShopCet46.Common.Models
{
    public class ProductResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public float Price { get; set; }

        public object ImageUrl { get; set; }

        public object LastPurchase { get; set; }

        public object LastSale { get; set; }

        public bool IsAvailable { get; set; }

        public float Stock { get; set; }

        public UserResponse User { get; set; }

        public object ImageFullPath { get; set; }
    }
}
