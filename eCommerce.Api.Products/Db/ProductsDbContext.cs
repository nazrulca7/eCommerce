using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Api.Products.Db
{
    public class ProductsDbContext:DbContext
     {
        public DbSet<Product> products { get; set; }
        public ProductsDbContext(DbContextOptions Options):base(Options)
        { 
        
        
        }
    }
}
