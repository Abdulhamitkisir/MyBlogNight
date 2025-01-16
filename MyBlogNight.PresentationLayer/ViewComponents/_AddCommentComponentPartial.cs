using Microsoft.AspNetCore.Mvc;
using MyBlogNight.BusinessLayer.Abstract;
using MyBlogNight.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;

namespace MyBlogNight.PresentationLayer.ViewComponents
{
    public class _AddCommentComponentPartial : ViewComponent
    {
     

        public IViewComponentResult Invoke(int articleId)
        {
            var model = new Comment
            {
                ArticleId = articleId // ArticleId'yi View'dan alıp modele aktarıyoruz
            };
            return View(model);
        }
    }
}
