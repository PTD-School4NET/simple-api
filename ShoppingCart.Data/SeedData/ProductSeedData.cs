using ShoppingCart.Models;
using System;
using System.Collections.Generic;

namespace ShoppingCart.Data.SeedData
{
    public static class ProductSeedData
    {
        public static List<Product> GetInitialProducts()
        {
            var createdAt = new DateTimeOffset(2021, 9, 24, 15, 0, 0, TimeSpan.FromHours(3));
            var modifiedAt = new DateTimeOffset(2021, 9, 24, 15, 0, 0, TimeSpan.FromHours(3)); 
            return new List<Product>
            {
                new Product
                {
                    Name = "Product 1",
                    CreatedAt = createdAt,
                    ModifiedAt = modifiedAt,
                    Description = "product 1 description",
                    Id = 1,
                    Image = "//todo",
                    IsDeleted = false,
                    Price = 100
                },
                new Product
                {
                    Name = "Product 2",
                    CreatedAt = createdAt,
                    ModifiedAt = modifiedAt,
                    Description = "product 2 description",
                    Id = 2,
                    Image = "//todo",
                    IsDeleted = false,
                    Price = 200
                },
                new Product
                {
                    Name = "Product 3",
                    CreatedAt = createdAt,
                    ModifiedAt = modifiedAt,
                    Description = "product 3 description",
                    Id = 3,
                    Image = "//todo",
                    IsDeleted = false,
                    Price = 300
                }
            };
        }
    }
}