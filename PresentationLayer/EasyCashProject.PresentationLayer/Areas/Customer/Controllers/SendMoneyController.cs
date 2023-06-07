using EasyCashProject.BusinessLayer.Abstract;
using EasyCashProject.DtoLayer.Dtos.AccountProcessDto;
using EasyCashProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EasyCashProject.PresentationLayer.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class SendMoneyController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICustomerAccountProcessService _processService;
        public SendMoneyController(UserManager<AppUser> userManager, ICustomerAccountProcessService processService)
        {
            _userManager = userManager;
            _processService = processService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(SendMoneyAccountProcessDto dto)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var ReceiverAccountNumber = dto.ReceiverAccountNumber;
            var receiver = _processService.TGetIdByAccountNumber(ReceiverAccountNumber);

            AccountProcess process = new AccountProcess
            {
                Amount = dto.Amount,
                ProcessDate = Convert.ToDateTime(DateTime.Now),
                ProcessType = "havale",
                ReceiverID = receiver.AppUserId,
                SenderID = user.Id,
                CustomerAccountID = receiver.CustomerAccountID,


            };
            _processService.TInsert(process);

            return Redirect("/Customer/SendMoney/Index");
        }

    }
}
