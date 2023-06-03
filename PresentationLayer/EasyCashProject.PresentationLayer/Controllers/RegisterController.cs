using EasyCashProject.DtoLayer.Dtos.AppUserDto;
using EasyCashProject.EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using MimeKit;

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
            var usermail = await _userManager.FindByEmailAsync(dto.Email);
            var username = await _userManager.FindByNameAsync(dto.UserName);

            if (ModelState.IsValid && dto.Password == dto.ConfirmPassword)
            {
                if(usermail != null)
                {
                    TempData["KullaniciMailAdresKontrol"] = "Bu mail adresi zaten kayıtlı!!";
                    return View();
                }
                if(username != null)
                {
                    TempData["KullaniciAdiKontrol"] = "Bu Kullanıcı Adı zaten kayıtlı!!";
                    return View();
                }

                Random rand = new Random();
                int confirmcode = rand.Next(100000, 999999);
                AppUser user = new AppUser
                {
                    Email = dto.Email,
                    Name= dto.Name,
                    UserName = dto.UserName,
                    Surname= dto.Surname,
                    Status = "0",
                    ConfirmCode = confirmcode
                   
                };
                var result = await _userManager.CreateAsync(user, dto.Password);
                if(result.Succeeded)
                {

                    MimeMessage mimemessage = new MimeMessage();
                    MailboxAddress mailboxadresfrom = new MailboxAddress("Easy Cash", "alefhigh17@gmail.com");
                    MailboxAddress mailboxadresTo = new MailboxAddress("User",user.Email);

                    mimemessage.From.Add(mailboxadresfrom);
                    mimemessage.To.Add(mailboxadresTo);

                    var bodybuilder = new BodyBuilder();
                    bodybuilder.TextBody="Kayıt işlemini gerçekleştirmek için onay kodunuz :"+ confirmcode;
                    mimemessage.Body = bodybuilder.ToMessageBody();
                    mimemessage.Subject = "easy cash onay kodu";

                    SmtpClient client = new SmtpClient();
                    client.Connect("smtp.gmail.com",587,false);
                    client.Authenticate("alefhigh17@gmail.com", "dqvqpseevktkcdgb");
                    client.Send(mimemessage);
                    client.Disconnect(true);


                    HttpContext.Session.SetInt32("confirmno", confirmcode);
                    HttpContext.Session.SetString("confirmMailAdres", user.Email);

                    return RedirectToAction("MailConfirmLinkPage", "Register");
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

        public IActionResult MailConfirmLinkPage()
        {
            return View();
        }
    }
}
