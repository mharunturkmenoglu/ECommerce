using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Entities.Concrete;
using ECommmerce.Service.Abstract;
using ECommmerce.Service.Results.Concrete;
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
            var result = _productService.GetAllByNonDeleted();
            return Ok(result);


        }

        [HttpPost("updateproduct")]
        public ActionResult UpdateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                var result = _productService.Update(product, "admin");
                return Ok(result);

            }
            else
            {
                return BadRequest("Please enter a valid product");
            }
        }

        [HttpPost("addproduct")]
        public ActionResult<Product> AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                var result = _productService.Add(product, "admin");
                return Ok(result);

            }
            else
            {
                return BadRequest("Enter valid product.");
            }
        }

        [HttpPost("deleteproduct")]
        public ActionResult<Product> DeleteProduct(int productId)
        {
            if (ModelState.IsValid)
            {
                var result = _productService.Delete(productId, "admin");
                return Ok(result);

            }
            else
            {
                return BadRequest("Enter valid Product Id.");
            }
        }
    }
}
