using Asif_nawaz_Assessment_5_Growth_Plan.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication9.ProblemFactory;

namespace Asif_nawaz_Assessment_5_Growth_Plan.Controllers
{
    [Route("ngrock/[action]")]
    [ApiController]
    [AllowAnonymous]
    public class ProdfuctController : ControllerBase
    {
        private readonly IHasher _hasher;

        public List<Products> products = new List<Products>();
        public ProdfuctController( IHasher ihasher)
        {
            _hasher = ihasher;
            products.Add(new Products { Id = 1, Description = "123", Name = "table", Price = 6 });
            products.Add(new Products { Id = 2, Description = "1234", Name = "chair", Price = 7 });
            products.Add(new Products { Id = 3, Description = "1235", Name = "glass", Price = 8 });
            products.Add(new Products { Id = 4, Description = "1236", Name = "clock", Price = 10 });
            products.Add(new Products { Id = 5, Description = "1237", Name = "stair", Price = 11 });

        }
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            return Ok(products);
        }
        [HttpGet("{id:int}")]
        public Products GetProductById(int id)
        { return products[id]; }

        [HttpPost]
        public IActionResult UpdateProductById(Products product)
        {
            var updatedProduct = products[product.Id];
            updatedProduct.Description = product.Description;
            updatedProduct.Name = product.Name;
            updatedProduct.Price = product.Price;
            return Ok(products);
        }
        [HttpPut("{id:int}")]
        public List<Products> UpdateSingleProperty(int id)
        {
            var updatedProduct = products[id];
            updatedProduct.Name = "nawaz";
            return products;
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteProduct(int id)
        {
            foreach (var product in products)
            {
                if (product.Id == id)
                {
                    products.Remove(product);
                    break;
                }
            }
            return Ok(products);
        }

        [HttpGet]
        public IActionResult CheckPassword(string userName, string Password)
        {
            _hasher.Hash(Password);
            var values = _hasher.VerifyPassword(userName, Password);
            return Ok(values);

        }
    }
}
