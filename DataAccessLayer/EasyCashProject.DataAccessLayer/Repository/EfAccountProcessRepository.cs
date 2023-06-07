using EasyCashProject.DataAccessLayer.Abstract;
using EasyCashProject.DataAccessLayer.Concrete;
using EasyCashProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashProject.DataAccessLayer.Repository
{
    public class EfAccountProcessRepository : GenericRepository<AccountProcess>, ICustomerAccountProcessDal
    {
        public CustomerAccount TGetIdByAccountNumber(string accountNumber)
        {
            Context c = new Context();
            var account = c.CustomerAccounts.Where(x => x.CustomerAccountNumber == accountNumber).FirstOrDefault();
            return account;
        }
    }
}
