using EasyCashProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashProject.DataAccessLayer.Concrete
{
    public class Context:IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlServer("Data Source=SAMET;Initial Catalog=EasyCashProject;Integrated Security=True");
        }
        public DbSet<CustomerAccount> CustomerAccounts { get; set; }
        public DbSet<AccountProcess> AccountProcesses { get; set; }

    }
}
