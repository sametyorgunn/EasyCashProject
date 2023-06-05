using EasyCashProject.DtoLayer.Dtos.AppUserDto;
using EasyCashProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashProject.PresentationLayer.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            AppUserEditDto dto = new AppUserEditDto();
            dto.Name= user.Name;
            dto.Surname= user.Surname;
            dto.Email= user.Email;
            dto.Username= user.UserName;
            dto.PhoneNumber= user.PhoneNumber;
            dto.City= user.City;
            dto.District= user.District;
            dto.ImageUrl= user.ImageUrl;

            return View(dto);
        }
        [HttpPost]
        public async Task<IActionResult> Index(AppUserEditDto dto)
        {
            var username = User.Identity.Name;
            var user = _userManager.FindByNameAsync(username).Result;

            user.PhoneNumber = dto.PhoneNumber;
            user.Name = dto.Name;
            user.Surname = dto.Surname;
            user.City = dto.City;
            user.District = dto.District;
            user.Email = dto.Email;
            user.UserName = dto.Username;
            user.ImageUrl = dto.ImageUrl;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, dto.Password);

            await _userManager.UpdateAsync(user);
            return Redirect("/Customer/Profile/Index");
            //return RedirectToAction("Index","Profile");
        }
    }
}
