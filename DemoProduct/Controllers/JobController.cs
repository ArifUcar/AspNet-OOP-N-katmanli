using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace DemoProduct.Controllers
{
    public class JobController : Controller
    {
        JobManeger jobManeger = new JobManeger(new EfJobDal());
        public IActionResult Index()
        {
            var values=jobManeger.TGetList();
           
            return View(values);
        }
        [HttpGet]
        public IActionResult AddJob()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddJob(Job j)
        {
            JobValidator validationRules = new JobValidator();
            ValidationResult result = validationRules.Validate(j);
            if (result.IsValid)
            {
               jobManeger.TAdd(j);
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

        public ActionResult DeleteJob(int id)
        {
            var values= jobManeger.TGetById(id);
            jobManeger.TDelete(values);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult UpdateJob(int id)
        {
            var values = jobManeger.TGetById(id);
            return View(values);
        }
        public ActionResult UpdateJob(Job job)
        {
            jobManeger.TUpdate(job);
            return RedirectToAction("Index");
        }

    }
}
