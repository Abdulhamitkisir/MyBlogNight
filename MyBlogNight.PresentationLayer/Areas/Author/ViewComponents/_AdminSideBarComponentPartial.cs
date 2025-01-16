using Microsoft.AspNetCore.Mvc;

namespace MyBlogNight.PresentationLayer.Areas.Author.ViewComponents
{
	public class _AdminSideBarComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
