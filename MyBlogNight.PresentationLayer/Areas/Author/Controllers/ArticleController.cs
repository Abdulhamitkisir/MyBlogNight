using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlogNight.BusinessLayer.Abstract;
using MyBlogNight.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MyBlogNight.PresentationLayer.Areas.Author.Controllers
{
    [Area("Author")]
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        private readonly UserManager<AppUser> _userManager;

        public ArticleController(IArticleService articleService, UserManager<AppUser> userManager, ICategoryService categoryService)
        {
            _articleService = articleService;
            _userManager = userManager;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var userValue = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _articleService.TGetArticlesByAppUserID(userValue.Id);
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateArticle()
        {
            var categoryList = _categoryService.TGetAll();
            List<SelectListItem> values1 = (from x in categoryList
                                            select new SelectListItem
                                            {
                                                Text = x.CategoryName,
                                                Value = x.CategoryId.ToString()
                                            }).ToList();
            ViewBag.v1 = values1;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateArticle(Article article)
        {
            var userValue = await _userManager.FindByNameAsync(User.Identity.Name);
            article.AppUserID = userValue.Id;
            article.ArticleViewCount = 0;
            article.CreateDate = DateTime.Now;
            _articleService.TInsert(article);
            return Redirect("/Author/Article/Index");
        }

        public IActionResult DeleteArticle(int id)
        {
            _articleService.TDelete(id);
            return Redirect("/Author/Article/Index");
        }
        [HttpGet]
        public IActionResult UpdateArticle(int id)
        {
            var value = _articleService.TGetById(id);

            var categoryList = _categoryService.TGetAll();
            List<SelectListItem> categories = (from x in categoryList
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryId.ToString()
                                               }).ToList();
            ViewBag.Categories = categories;

            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateArticle(Article article)
        {
            // Kullanıcı bilgilerini al
            var userValue = await _userManager.FindByNameAsync(User.Identity.Name);

            // Mevcut makaleyi al
            var articleValue = _articleService.TGetById(article.ArticleId);

            // Gerekli alanları güncelle
            articleValue.AppUserID = userValue.Id;
            articleValue.Title = article.Title; // Güncel veri kullanılıyor
            articleValue.Detail = article.Detail;
            articleValue.CoverImageUrl = article.CoverImageUrl;
            articleValue.MainImageUrl = article.MainImageUrl;
            articleValue.CategoryId = article.CategoryId;

            // Güncellenmiş nesneyi kaydet
            _articleService.TUpdate(articleValue);

            return Redirect("/Author/Article/Index");

        }


    }
}
