﻿using EasyCashProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashProject.DataAccessLayer.Abstract
{
    public interface ICustomerAccountProcessDal:IGenericDal<AccountProcess>
    {
        CustomerAccount TGetIdByAccountNumber(string accountNumber);

    }
}
