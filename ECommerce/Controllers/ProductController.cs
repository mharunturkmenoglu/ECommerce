using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        [Authorize]
        [HttpGet("allproducts")]
        public ActionResult<IEnumerable<Product>> GetAllProduct()
        {
            var result = _productService.GetAllByNonDeleted();
            return Ok(result);
        }
        [Authorize]
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
        [Authorize]
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
        [Authorize]
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
