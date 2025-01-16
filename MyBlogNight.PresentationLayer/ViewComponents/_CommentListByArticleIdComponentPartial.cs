using Microsoft.AspNetCore.Mvc;
using MyBlogNight.BusinessLayer.Abstract;

namespace MyBlogNight.PresentationLayer.ViewComponents
{
    public class _CommentListByArticleIdComponentPartial : ViewComponent
    {
        private readonly ICommentService _commentService;

        public _CommentListByArticleIdComponentPartial(ICommentService commentService)
        {
            _commentService = commentService;
        }
        public IViewComponentResult Invoke(int ArticleId)
        {
            
            var values = _commentService.TGetCommentsByArticleId(ArticleId);
            return View(values);
        }
    }
}
