﻿using EasyCashProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashProject.DataAccessLayer.Abstract
{
    public interface IAppUserDal:IGenericDal<AppUser>
    {
        void GetUserByMail(string mail);
    }
}
