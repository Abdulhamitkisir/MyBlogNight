using Microsoft.AspNetCore.Mvc;
using MyBlogNight.BusinessLayer.Abstract;
using X.PagedList.Mvc.Core;
using X.PagedList.Extensions;
using MyBlogNight.EntityLayer.Concrete;

namespace MyBlogNight.PresentationLayer.ViewComponents
{
    public class _DefaultArticleListComponentPartial : ViewComponent
    {
        private readonly IArticleService _articleService;

        public _DefaultArticleListComponentPartial(IArticleService articleService)
        {
            _articleService = articleService;
        }
        public IViewComponentResult Invoke(int page = 1)
        {
            const int pageSize = 4;

            var articles = _articleService.TArticleListWithCategoryAndAppUser();

            var pagedArticles = articles.ToPagedList(page, pageSize);

            return View("Default",pagedArticles);






            //var values = _articleService.TArticleListWithCategoryAndAppUser();

            //// Null kontrolü yapın
            //if (values == null || !values.Any())
            //{
            //    // Eğer liste null ise, boş bir liste döndürün
            //    values = new List<Article>();
            //}

            //var pagedArticles = values.ToPagedList(page, pageSize);
            //return View("Index","Default" pagedArticles); // "Default" view'ine gönderilen model





            //var values = _articleService.TGetAll().ToPagedList(page,3);            
            //return View(values);
            //const int pageSize = 4;
            //var articles = _articleService.TArticleListWithCategoryAndAppUser();
            //var pagedArticles = articles.ToPagedList(page, pageSize);
            //return View(pagedArticles);

            //var values = _articleService.TArticleListWithCategoryAndAppUser();
            //var pagedArticles = values.ToPagedList(page, pageSize);
            //return View(pagedArticles);
        }
    }
}
