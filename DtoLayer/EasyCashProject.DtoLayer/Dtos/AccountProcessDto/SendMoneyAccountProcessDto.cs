using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashProject.DtoLayer.Dtos.AccountProcessDto
{
    public class SendMoneyAccountProcessDto
    {
        public string ProcessType { get; set; }
        public decimal Amount { get; set; }
        public DateTime ProcessDate { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string ReceiverAccountNumber { get; set; }
    }
}
