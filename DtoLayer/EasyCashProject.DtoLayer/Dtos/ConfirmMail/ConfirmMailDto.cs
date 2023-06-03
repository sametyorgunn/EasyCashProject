using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashProject.DtoLayer.Dtos.ConfirmMail
{
    public class ConfirmMailDto
    {
        public int ConfirmCode { get; set; }
        public string Mail { get; set; }
    }
}
