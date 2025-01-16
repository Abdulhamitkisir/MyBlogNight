using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using MyBlogNight.EntityLayer.Concrete;
using MyBlogNight.PresentationLayer.Areas.Author.Models;

namespace MyBlogNight.PresentationLayer.Areas.Author.Controllers
{
    [Area("Author")]
    public class ProfileController : Controller
    {
        
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task <IActionResult> EditMyProfile()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel model = new UserEditViewModel();
            model.Surname= values.Surname;
            model.Name = values.Name;
            model.Email = values.Email;
            model.ImageUrl = values.ImageUrl;
            model.Username = values.UserName;
            model.Detail = values.Detail;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditMyProfile(UserEditViewModel model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            user.Name = model.Name;
            user.Surname = model.Surname;
            user.Email = model.Email;
            user.ImageUrl = model.ImageUrl;
            user.UserName=model.Username;
            user.Detail = model.Detail;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            { 
                return Redirect("/Author/Profile/EditMyProfile");
            }
            return View();
        }
    }
}
