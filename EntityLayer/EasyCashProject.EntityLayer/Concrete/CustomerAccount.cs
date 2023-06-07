using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashProject.EntityLayer.Concrete
{
    public class CustomerAccount
    {
        [Key]
        public int CustomerAccountID { get; set; }
        public string CustomerAccountNumber { get; set; }
        public string CustomerAccountCurrency { get; set; }
        public decimal CustomerAccountBalance { get; set; }
        public string BankBranch { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public List<AccountProcess> Process { get; set; }

        //public List<AccountProcess> CustomerSender { get; set; }
        //public List<AccountProcess> CustomerReceiver { get; set; }
    }
}
