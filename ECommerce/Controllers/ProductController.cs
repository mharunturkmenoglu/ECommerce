using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Entities.Concrete;
using ECommmerce.Service.Abstract;
using Microsoft.AspNetCore.Authorization;

namespace ECommerce.Api.Controllers
{
    public class ProductController : BaseApiController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("allproducts")]
        public ActionResult<IEnumerable<Product>> GetAllProduct()
        {
            var products = _productService.GetAll();
            return products;
        }

        [HttpPost("updateproduct")]
        public ActionResult<Product> UpdateProduct(Product product)
        {
            _productService.Update(product, "admin");
            return product;
        }

        [HttpPost("addproduct")]
        public ActionResult<Product> AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.Add(product, "admin");
                return product;
            }
            else
            {
                return BadRequest("Enter valid product.");
            }
        }
    }
}
