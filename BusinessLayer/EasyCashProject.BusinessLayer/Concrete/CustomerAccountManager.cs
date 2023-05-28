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
    public class CustomerAccountManager : ICustomerAccountService
    {
        private readonly ICustomerAccountDal _costumeraccountdal;

        public CustomerAccountManager(ICustomerAccountDal costumeraccountdal)
        {
            _costumeraccountdal = costumeraccountdal;
        }

        public void TDelete(CustomerAccount t)
        {
           _costumeraccountdal.Delete(t);
        }

        public CustomerAccount TGetById(int id)
        {
            return _costumeraccountdal.GetById(id);
        }

        public List<CustomerAccount> TGetList()
        {
            return _costumeraccountdal.GetList();
        }

        public void TInsert(CustomerAccount t)
        {
           _costumeraccountdal.Insert(t);
        }

        public void TUpdate(CustomerAccount t)
        {
           _costumeraccountdal.Update(t);
        }
    }
}
