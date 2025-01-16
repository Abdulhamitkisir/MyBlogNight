using Microsoft.AspNetCore.Mvc;
using MyBlogNight.BusinessLayer.Abstract;

namespace MyBlogNight.PresentationLayer.ViewComponents
{
    public class _RecentPostComponentPartial : ViewComponent
    {
        private readonly IArticleService _articleService;

        public _RecentPostComponentPartial(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IViewComponentResult Invoke()
        {
            // Makaleleri ID'ye göre ters sırada alıp son 3 makaleyi seçiyoruz
            var values = _articleService.TGetAll()
                                        .OrderByDescending(x => x.ArticleId) // En son eklenen makaleler
                                        .Take(3) // İlk 3 makaleyi al
                                        .ToList();

            return View(values); // Bu değerleri View'a gönder
        }
    }
}
