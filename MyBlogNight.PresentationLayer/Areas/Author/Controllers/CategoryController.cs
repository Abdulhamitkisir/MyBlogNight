using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using MyBlogNight.BusinessLayer.Abstract;
using MyBlogNight.BusinessLayer.ValidattionRules.CategoryValidationRules;
using MyBlogNight.EntityLayer.Concrete;

namespace MyBlogNight.PresentationLayer.Areas.Author.Controllers
{
    [Area("Author")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
       
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
      
        public IActionResult CategoryList()
        {
            var values = _categoryService.TGetAll();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            ModelState.Clear();
            CreateCategoryValidator validationRules = new CreateCategoryValidator();
            ValidationResult result = validationRules.Validate(category);
            if (result.IsValid)
            {
                _categoryService.TInsert(category);
                return Redirect("/Author/Category/CategoryList");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }


        }
        public IActionResult DeleteCategory(int id)
        {
            _categoryService.TDelete(id);
			return Redirect("/Author/Category/CategoryList");
		}
        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var value = _categoryService.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            _categoryService.TUpdate(category);
			return Redirect("/Author/Category/CategoryList");
		}
    }
}
