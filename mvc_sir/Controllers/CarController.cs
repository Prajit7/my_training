using SampleMvcApp.DataComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleMvcApp.Controllers
{
    public class CarController : Controller
    {
        // GET: Car
        public ActionResult Index()
        {
            var repo = new CarInfoRepo();
            var model = repo.GetAllCars();
            return View(model);
        }
      public ActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                ViewBag.Message = "Car ID not found";
                return View();
            }
            var selectedId = int.Parse(id);
            var repo = new CarInfoRepo();
            var model = repo.FindCar(selectedId);
            if(model == null)
            {
                ViewBag.Message = "Car not Available with US";
                return View();
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(CARINFO updatedData)
        {
            var repo = new CarInfoRepo();
            repo.UpdateCar(updatedData);
            return RedirectToAction("Index");
        }
        public ActionResult AddCar() => View(new CARINFO());

        [HttpPost]
        public ActionResult AddCar(CARINFO postedData)
        {
            var repo = new CarInfoRepo();
            repo.AddNewCar(postedData);
            return RedirectToAction("Index");
        }
       
        public ActionResult DeleteCar(string id)
        {
            var selectedId = int.Parse(id);
            var repo = new CarInfoRepo();
            repo.DeleteCar(selectedId);
            return RedirectToAction("Index");
        }


    }
}