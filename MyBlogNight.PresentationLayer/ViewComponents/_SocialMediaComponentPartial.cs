using Microsoft.AspNetCore.Mvc;
using MyBlogNight.BusinessLayer.Abstract;

namespace MyBlogNight.PresentationLayer.ViewComponents
{
    public class _SocialMediaComponentPartial:ViewComponent
    {
        private readonly ISocialMediaService _service;

        public _SocialMediaComponentPartial(ISocialMediaService service)
        {
            _service = service;
        }

        public IViewComponentResult Invoke()
        {
            var values = _service.TGetAll();
            return View(values);
        }
    }
}
