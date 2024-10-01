using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CustomerManeger : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManeger(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public List<Customer> GetCustomersListWithJob()
        {
            return _customerDal.GetCustomerListWithJob();
        }

        public void TAdd(Customer t)
        {
            _customerDal.Insert(t); 
        }

        public void TDelete(Customer t)
        {
            _customerDal.Delete(t);
        }

        public Customer TGetById(int id)
        {
           return _customerDal.GetById(id);
        }

        public List<Customer> TGetList()
        {
           return _customerDal.GetList();
        }

        public void TUpdate(Customer t)
        {
           _customerDal.Update(t);
        }
    }
}
