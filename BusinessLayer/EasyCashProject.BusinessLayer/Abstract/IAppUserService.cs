using EasyCashProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashProject.BusinessLayer.Abstract
{
    public interface IAppUserService:IGenericService<AppUser>
    {
        void TGetUserByMail(string mail);

    }
}
