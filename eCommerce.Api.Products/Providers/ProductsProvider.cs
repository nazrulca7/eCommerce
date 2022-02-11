using AutoMapper;
using eCommerce.Api.Products.Db;
using eCommerce.Api.Products.Interfaces;
using eCommerce.Api.Products.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Api.Products
{
    public class ProductsProvider : IProductProvider
    {
        private readonly ProductsDbContext DbContext;
        private readonly ILogger<ProductsProvider> ILogger;
        private readonly IMapper mapper;

        public ProductsProvider(ProductsDbContext dbContext, ILogger<ProductsProvider> Logger, IMapper Mapper)
        {
            this.DbContext = dbContext;
            this.ILogger = Logger;
            this.mapper = Mapper;

            SeedData();
        }

        private void SeedData()
        {
            if (!DbContext.products.Any())
            {
                DbContext.products.Add(new Db.Product() { Id = 1, Name = "KeyBoard", Price = 20, Inventory = 100 });
                DbContext.products.Add(new Db.Product() { Id = 2, Name = "Mouse", Price = 30, Inventory = 200 });
                DbContext.products.Add(new Db.Product() { Id = 3, Name = "Monitor", Price = 150, Inventory = 300 });
                DbContext.products.Add(new Db.Product() { Id = 4, Name = "CPU", Price = 200, Inventory = 120 });
                DbContext.SaveChanges();
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<Models.Product> Product, string ErrorMessage)> GetProductsAsync()
        {
            try
            {
                var Products = await DbContext.products.ToListAsync();
                if (Products != null && Products.Any())
                {
                    var result = mapper.Map<IEnumerable<Db.Product>, IEnumerable<Models.Product>>(Products);
                    return (true, result, null);
                }
                return (false, null, "Not Found");

            }
            catch (Exception ex)
            {

                ILogger?.LogError(ex.ToString());

                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, Models.Product Product, string ErrorMessage)> GetProductAsync(int Id)
        {
            try
            {
                var Product = await DbContext.products.FirstOrDefaultAsync(p=>p.Id == Id);
                if (Product != null)
                {
                    var result = mapper.Map<Db.Product, Models.Product>(Product);
                    return (true, result, null);
                }
                return (false, null, "Not Found");

            }
            catch (Exception ex)
            {

                ILogger?.LogError(ex.ToString());

                return (false, null, ex.Message);
            }
        }
    }
}
