using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;

namespace DemoProduct.Controllers
{
    public class CustomerController : Controller
    {
        CustomerManeger _customerManeger=new CustomerManeger (new EfCustomerDal());
        public IActionResult Index()
        {
            var values = _customerManeger.GetCustomersListWithJob();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddCustomer()
        {
            JobManeger jobManeger = new JobManeger(new EfJobDal());


            List<SelectListItem> values = (from x in jobManeger.TGetList()
                                           select new SelectListItem
                                           {

                                               Text = x.Name,
                                               Value = x.JobID.ToString()
                                           }).ToList();
            ViewBag.v = values;

            return View();

        }
        [HttpPost]
        public IActionResult AddCustomer(Customer c) {

            


            CustomerValidator validationRules = new CustomerValidator();
            ValidationResult result = validationRules.Validate(c);
            if (result.IsValid)
            {
               _customerManeger.TAdd(c);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
          
            return View();
        }
        public IActionResult DeleteCustomer(int id)
        {
            var value = _customerManeger.TGetById(id);
            _customerManeger.TDelete(value);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult UpdateCustomer(int id)

        {
            JobManeger jobManeger = new JobManeger(new EfJobDal());


            List<SelectListItem> values = (from x in jobManeger.TGetList()
                                           select new SelectListItem
                                           {

                                               Text = x.Name,
                                               Value = x.JobID.ToString()
                                           }).ToList();
            ViewBag.v = values;
            var value = _customerManeger.TGetById(id);

            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateCustomer(Customer c)
        {
            _customerManeger.TUpdate(c);
            return RedirectToAction("Index");

        }


    }
}
