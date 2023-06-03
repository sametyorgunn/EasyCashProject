using EasyCashProject.DtoLayer.Dtos.LoginDto;
using EasyCashProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashProject.PresentationLayer.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _loginManager;
        private readonly UserManager<AppUser> _userManager;

        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> loginManager)
        {
            _userManager = userManager;
            _loginManager = loginManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserLoginDto dto)
        {
            if (ModelState.IsValid)
            {
                var login = await _loginManager.PasswordSignInAsync(dto.Username,dto.Password,true,true);//ispersistence true 
                //olması sifre saklansınmı beni hatırla ile aynı işlem 
                //lockoutonfailure true olması ise birkaç kez yanlıs girerse hesabı kitleniyor.

                if (login.Succeeded)
                {
                    var user = _userManager.FindByNameAsync(dto.Username).Result;
                    if (user.EmailConfirmed == false)
                    {
                        return RedirectToAction("Index","MailConfirm");
                    }
                    return RedirectToAction("Index", "Profile");
                }
                else
                {
                    TempData["loginfalse"] = "Giriş Başarısız Kullanıcı Adı Veya Şifre Hatalı";
                    return View();
                }
               
            }
            return View();
        }
    }
}
