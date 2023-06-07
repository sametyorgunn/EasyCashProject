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

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<AccountProcess>()
        //        .HasOne(x => x.SenderCustomer)
        //        .WithMany(y => y.CustomerSender)
        //        .HasForeignKey(z => z.SenderID)
        //        .OnDelete(DeleteBehavior.ClientSetNull);

        //    builder.Entity<AccountProcess>()
        //        .HasOne(x => x.ReceiverCustomer)
        //        .WithMany(y => y.CustomerReceiver)
        //        .HasForeignKey(z => z.ReceiverID)
        //        .OnDelete(DeleteBehavior.ClientSetNull);

        //    base.OnModelCreating(builder);
        //}

    }
}
