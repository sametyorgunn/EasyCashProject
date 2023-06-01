using EasyCashProject.DataAccessLayer.Abstract;
using EasyCashProject.DataAccessLayer.Concrete;
using EasyCashProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashProject.DataAccessLayer.Repository
{
    public class EfAppUserRepository : GenericRepository<AppUser>, IAppUserDal
    {
      

        void IAppUserDal.GetUserByMail(string mail, int confirmcode)
        {
            using (var c = new Context())
            {
                var user = c.Users.Where(x => x.Email == mail).FirstOrDefault();
                user.ConfirmCode = Convert.ToInt32(confirmcode);
                user.Status = "1";
                c.SaveChanges(); 
            }
        }
    }
}
