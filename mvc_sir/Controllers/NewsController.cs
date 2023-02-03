using SampleMvcApp.DataComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleMvcApp.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index()
        {
            var repo = new newspage();
            var model = repo.GetAllNews();
            return View(model);
        }
    }
}