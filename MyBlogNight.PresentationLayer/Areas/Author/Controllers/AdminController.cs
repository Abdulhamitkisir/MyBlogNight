using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlogNight.BusinessLayer.Abstract;
using MyBlogNight.EntityLayer.Concrete;

namespace MyBlogNight.PresentationLayer.Areas.Author.Controllers
{
	[Area("Author")]
	public class AdminController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICommentService _commentService;
        private readonly UserManager<AppUser> _userManager;

        public AdminController(IArticleService articleService, ICommentService commentService, UserManager<AppUser> userManager)
        {
            _articleService = articleService;
            _commentService = commentService;
            _userManager = userManager;
        }

      
        
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var myAriticleCount=_articleService.TGetArticlesByAppUserID(user.Id).Count().ToString();
            ViewBag.ArticleCount = myAriticleCount;

            var myCommentCount = _commentService.TGetCommentsByAppUserId(user.Id).Count().ToString();
            ViewBag.CommentCount = myCommentCount;

            var userName = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.UserName = userName;
            
            return View();
        }
    }
}
