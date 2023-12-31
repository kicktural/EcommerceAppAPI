﻿using Bogus;
using DataaAccess.Concreate.SQLServer;
using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataaAccess.DataAccess
{
    public class DataSeed
    {

        public static void AddData()
        {
            using var context = new AppDBContext();


            if (!context.Categories.Any())
            {
                var fakerCategory = new Faker<Category>()
                .RuleFor(x => x.CategoryName, f => f.Commerce.Categories(1)[0])
                .RuleFor(x => x.Status, f => f.Random.Bool())
                .RuleFor(x => x.CreateDate, f => f.Date.Recent())
                .RuleFor(x => x.PhotoUrl, f => f.Image.PicsumUrl());

                var categories = fakerCategory.Generate(20);
                context.Categories.AddRange(categories);
                context.SaveChanges();
            }


            if (!context.Products.Any())
            {
                var fakerProduct = new Faker<Product>();
                fakerProduct.RuleFor(x => x.ProductName, z => z.Commerce.ProductName());
                fakerProduct.RuleFor(x => x.CategoryId, z => z.Random.Int(3, 23));
                fakerProduct.RuleFor(x => x.Quantity, z => z.Random.Int(1, 100));
                fakerProduct.RuleFor(x => x.Price, z => z.Random.Decimal(100, 10000));
                fakerProduct.RuleFor(x => x.Discount, z => z.Random.Decimal(0, 10000));
                fakerProduct.RuleFor(x => x.Status, z => z.Random.Bool());
                fakerProduct.RuleFor(x => x.CreateDate, z => z.Date.Recent());
                fakerProduct.RuleFor(x => x.PhotoUrl, z => z.Image.PicsumUrl());
         

                var products = fakerProduct.Generate(50);
                context.Products.AddRange(products);
                context.SaveChanges();
            }

        }
    }
}
