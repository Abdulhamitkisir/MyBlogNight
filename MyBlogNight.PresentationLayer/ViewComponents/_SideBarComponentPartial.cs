using Microsoft.AspNetCore.Mvc;

namespace MyBlogNight.PresentationLayer.ViewComponents
{
    public class _SideBarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        { 
            return  View();
        }
    }
}
