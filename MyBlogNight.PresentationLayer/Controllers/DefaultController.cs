using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlogNight.BusinessLayer.Abstract;
using MyBlogNight.EntityLayer.Concrete;
using X.PagedList.Extensions;

namespace MyBlogNight.PresentationLayer.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICommentService _commentService;
        private readonly UserManager<AppUser> _userManager;
        public DefaultController(IArticleService articleService, ICommentService commentService, UserManager<AppUser> userManager)
        {
            _articleService = articleService;
            _commentService = commentService;
            _userManager = userManager;
        }

        public IActionResult Index(int page = 1)
        {
            const int pageSize = 3;

            var articles = _articleService.TArticleListWithCategoryAndAppUser();

            var pagedArticles = articles.ToPagedList(page, pageSize);

            return View(pagedArticles);
        }
        public IActionResult ArticleDetail(int id)
        {
            _articleService.TArticleViewCountIncrease(id);
            var value = _articleService.TGetArticleDetails(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> SaveComment(Comment comment,string UserName)
        {
           
            // Kullanıcıyı username'e göre bulmaya çalışıyoruz
            var user = await _userManager.FindByNameAsync(UserName);

            // Eğer kullanıcı bulunamazsa
            if (user == null)
            {
              ModelState.AddModelError("UserName", "User not found. Please enter a valid username.");

                return View("ArticleDetail", comment);

            }
            // Yorum bilgilerini dolduruyoruz
            comment.AppUserId = user.Id;
            comment.CreatedDate = DateTime.Now;
            comment.Status = true;

            // Veritabanına ekliyoruz
            _commentService.TInsert(comment);

            // Başarı durumunda aynı makale sayfasına yönlendiriyoruz
            return RedirectToAction("ArticleDetail", new { id = comment.ArticleId });
        }
    }
}
