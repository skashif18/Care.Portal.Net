using JobPortal.Data.Models.Datamodel;
using JobPortal.Data.Models.Repository;
using JobPortal.Data.Models.Repository.Employee;
using System;
using System.Web.Mvc;

namespace Care.Portal.Net.Web.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile


        private readonly IEmployeeRepository emp;

        public ProfileController(IEmployeeRepository emp)
        {
                this.emp = emp;
        }

        DoValidation val = new DoValidation();
        public ActionResult Index()
        {

            return View(emp.GetProfiles());
        }

        [HttpGet]
        public ActionResult Create()
        {
            Profile profileBase = new Profile();
            profileBase.CreatedDate = DateTime.Now;
            return View(profileBase);
        }

        [HttpPost]
        public ActionResult Create(Profile model)
        {

            if (!ModelState.IsValid)
                return View(model);

            val = emp.Save(model);

            if (val.IsSucess) {
                return RedirectToAction("Index");

            }
            else
            {
                ModelState.AddModelError("", val.Message);
                return View(model);
            }
        }


        [HttpGet]
        public ActionResult Edit(int Id)
        {
            return View(emp.GetProfile(Id));
        }

        [HttpPost]
        public ActionResult Edit(Profile model)
        {

            if (!ModelState.IsValid)
                return View(model);

            val = emp.Save(model);

            if (val.IsSucess)
            {
                return RedirectToAction("Index");

            }
            else
            {
                ModelState.AddModelError("", val.Message);
                return View(model);
            }
        }
    }
}