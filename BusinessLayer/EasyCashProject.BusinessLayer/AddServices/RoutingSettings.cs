using EasyCashProject.BusinessLayer.Abstract;
using EasyCashProject.BusinessLayer.Concrete;
using EasyCashProject.DataAccessLayer.Abstract;
using EasyCashProject.DataAccessLayer.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashProject.BusinessLayer.AddServices
{
    public static class RoutingSettings
    {
        public static void AddRoutingSettings(this IServiceCollection services)
        {
            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IAppUserDal, EfAppUserRepository>();
           
        }
    }
}
