using Microsoft.AspNetCore.Mvc;
using MyBlogNight.BusinessLayer.Abstract;
using MyBlogNight.DtoLayer.Dtos.CategoryDtos;

namespace MyBlogNight.PresentationLayer.ViewComponents
{
    public class _CategoryWithArticleCountComponentPartial : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        private readonly IArticleService _articleService;

        public _CategoryWithArticleCountComponentPartial(ICategoryService categoryService, IArticleService articleService)
        {
            _categoryService = categoryService;
            _articleService = articleService;
        }

        public IViewComponentResult Invoke()
        {
            // Tüm kategorileri ve makaleleri al
            var categories = _categoryService.TGetAll();
            var articles = _articleService.TGetAll();

            // Her kategori için o kategoriye ait toplam makale sayısını bul
            var articleCountsByCategory = articles
                                                .GroupBy(article => article.CategoryId)
                                                .ToDictionary(g => g.Key, g => g.Count());

            // Kategorilerle eşleşen makale sayılarını al
            var categoryArticleCounts = categories.Select(category => new CategoryArticleCountDto()
            {
                CategoryName = category.CategoryName,
                ArticleCount = articleCountsByCategory.ContainsKey(category.CategoryId)
                                ? articleCountsByCategory[category.CategoryId]
                                : 0 // Kategoriye ait makale yoksa 0 döndür
            }).ToList();
            return View(categoryArticleCounts);
        }
    }
}
