using Microsoft.AspNetCore.Mvc;

namespace MyBlogNight.PresentationLayer.Areas.Author.ViewComponents
{
	public class _AdminHeadComponentPartial :ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
