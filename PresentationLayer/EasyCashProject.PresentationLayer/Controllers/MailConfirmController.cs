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
        private readonly AppUserManager _appUserManager;
        public MailConfirmController(UserManager<AppUser> userManager, AppUserManager appUserManager)
        {
            _userManager = userManager;
            _appUserManager = appUserManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(ConfirmMailDto dto)
        {
            var confirmcode = HttpContext.Session.GetInt32("confirmno");
            var confirmMailAdres = HttpContext.Session.GetString("confirmMailAdres");

            int intconfirmcode = Convert.ToInt32(confirmcode);
            if (ModelState.IsValid)
            {
                if(dto.ConfirmMail == confirmcode)
                {
                    _appUserManager.TGetUserByMail(confirmMailAdres,intconfirmcode);

                }
            }
            return View();
        }
    }
}
