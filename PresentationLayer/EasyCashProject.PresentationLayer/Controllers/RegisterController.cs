using EasyCashProject.DtoLayer.Dtos.AppUserDto;
using EasyCashProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashProject.PresentationLayer.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(AppUserRegisterDto dto)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    Email = dto.Email,
                    Name= dto.Name,
                    UserName = dto.UserName,
                    Surname= dto.Surname,
                    Status = "0"
                   
                };
                var result = await _userManager.CreateAsync(user, dto.Password);
                
                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "ConfirmMail");
                }
                else
                {
                    foreach(var i in result.Errors)
                    {
                        ModelState.AddModelError("",i.Description);
                    }
                }
            }
            return View();
        }
    }
}
