using EasyCashProject.BusinessLayer.Abstract;
using EasyCashProject.DataAccessLayer.Abstract;
using EasyCashProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashProject.BusinessLayer.Concrete
{
    public class CustomerAccountProcessManager : ICustomerAccountProcessService
    {
        private readonly ICustomerAccountProcessDal _costumerAccountProcessDal;

        public CustomerAccountProcessManager(ICustomerAccountProcessDal costumerAccountProcessDal)
        {
            _costumerAccountProcessDal = costumerAccountProcessDal;
        }

        public void TDelete(AccountProcess t)
        {
            _costumerAccountProcessDal.Delete(t);
        }

        public AccountProcess TGetById(int id)
        {
            return _costumerAccountProcessDal.GetById(id);
        }

        public CustomerAccount TGetIdByAccountNumber(string accountNumber)
        {
            return _costumerAccountProcessDal.TGetIdByAccountNumber(accountNumber);
        }

        public List<AccountProcess> TGetList()
        {
            return _costumerAccountProcessDal.GetList();
        }

        public void TInsert(AccountProcess t)
        {
            _costumerAccountProcessDal.Insert(t);
        }

        public void TUpdate(AccountProcess t)
        {
            _costumerAccountProcessDal.Update(t);
        }
    }
}
