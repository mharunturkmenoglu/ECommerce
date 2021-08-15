using Microsoft.AspNetCore.Mvc;
using ECommerce.Entities.Concrete;
using ECommmerce.Service.Abstract;

namespace ECommerce.Api.Controllers
{
    public class CategoriesController : BaseApiController
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet("allcategories")]
        public ActionResult GetAllCategory()
        {
            var result = _categoryService.GetAllByNonDeletedAndActive();
            return Ok(result);
        }
        [HttpPost("addcategory")]
        public ActionResult AddCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                var result = _categoryService.Add(category, "admin");
                return Ok(result);
            }
            else
            {
                return BadRequest("Enter a valid category.");
            }
        }

        [HttpPost("updatecategory")]
        public ActionResult UpdateCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                var result = _categoryService.Update(category, "admin");
                return Ok(result);
            }
            else
            {
                return BadRequest("Enter a valid category.");
            }
        }

        [HttpPost("deletecategory")]
        public ActionResult DeleteCategory(int productId)
        {
            if (ModelState.IsValid)
            {
                var result = _categoryService.Delete(productId, "admin");
                return Ok(result);
            }
            else
            {
                return BadRequest("Enter a valid Id.");
            }
        }
    }
}