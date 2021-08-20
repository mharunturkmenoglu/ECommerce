using Microsoft.AspNetCore.Mvc;
using ECommerce.Entities.Concrete;
using ECommmerce.Service.Abstract;
using ECommmerce.Shared.Results.Concrete;
using Microsoft.AspNetCore.Authorization;

namespace ECommerce.Api.Controllers
{
    public class CategoriesController : BaseApiController
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [Authorize]
        [HttpGet("allcategories")]
        public ActionResult GetAllCategory()
        {
            var result = _categoryService.GetAllByNonDeletedAndActive();
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
        [HttpPost("addcategory")]
        public ActionResult AddCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                var result = _categoryService.Add(category, "admin");
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
                return BadRequest("Enter a valid category.");
            }
        }
        [Authorize]
        [HttpPut("updatecategory")]
        public ActionResult UpdateCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                var result = _categoryService.Update(category, "admin");
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
                return BadRequest("Enter a valid category.");
            }
        }
        [Authorize]
        [HttpPatch("deletecategory")]
        public ActionResult DeleteCategory(int categoryId)
        {
            if (ModelState.IsValid)
            {
                var result = _categoryService.Delete(categoryId, "admin");
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
                return BadRequest("Enter a valid Id.");
            }
        }
    }
}