using eCommerce.Api.Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Api.Products.Interfaces
{
    public interface IProductProvider
    {

        Task<(bool IsSuccess, IEnumerable<Product> Product, String ErrorMessage)> GetProductsAsync();
        Task<(bool IsSuccess, Product Product, String ErrorMessage)> GetProductAsync(int Id);
    }
}
