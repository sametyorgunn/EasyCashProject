using EasyCashProject.BusinessLayer.Abstract;
using EasyCashProject.BusinessLayer.Concrete;
using EasyCashProject.DtoLayer.Dtos.ConfirmMail;
using EasyCashProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashProject.PresentationLayer.Controllers
{
    public class MailConfirmController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAppUserService _appUserService;

        public MailConfirmController(UserManager<AppUser> userManager, IAppUserService appUserService)
        {
            _userManager = userManager;
            _appUserService = appUserService;
        }

        public IActionResult Index()
        {
            var confirmMailAdres = HttpContext.Session.GetString("confirmMailAdres");
            ViewBag.mail = confirmMailAdres;
            return View();
        }
        [HttpPost]
        public IActionResult Index(ConfirmMailDto dto)
        {
            //var confirmcode = HttpContext.Session.GetInt32("confirmno");
            //var confirmMailAdres = HttpContext.Session.GetString("confirmMailAdres");
            //int intconfirmcode = Convert.ToInt32(confirmcode);

            
            if (ModelState.IsValid)
            {
                var user = _userManager.FindByEmailAsync(dto.Mail).Result;

                if (dto.Mail == user.Email && dto.ConfirmCode == user.ConfirmCode)
                {
                    _appUserService.TGetUserByMail(user.Email);
                    return RedirectToAction("Index","Login");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
            
        }
    }
}
