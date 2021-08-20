using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ECommerce.Entities.Concrete;
using ECommmerce.Service.Abstract;
using ECommmerce.Shared.Results.Concrete;
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
            if (result.ResultStatus == ResultStatus.Success)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }
        [Authorize]
        [HttpPut("updateproduct")]
        public ActionResult UpdateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                var result = _productService.Update(product, "admin");
                if (result.ResultStatus == ResultStatus.Success)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound(result);
                }
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
                if (result.ResultStatus == ResultStatus.Success)
                {
                    return Ok(result);
                }
                else
                {
                    return Conflict(result);
                }
            }
            else
            {
                return BadRequest("Enter valid product.");
            }
        }
        [Authorize]
        [HttpPatch("deleteproduct")]
        public ActionResult<Product> DeleteProduct(int productId)
        {
            if (ModelState.IsValid)
            {
                var result = _productService.Delete(productId, "admin");
                if (result.ResultStatus == ResultStatus.Success)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound(result);
                }

            }
            else
            {
                return BadRequest("Enter valid Product Id.");
            }
        }
    }
}
