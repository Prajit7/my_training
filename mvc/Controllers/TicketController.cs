using MVCApp.DataComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCApp.Controllers
{
    public class TicketController : Controller
    {
        // GET: Ticket
        public ActionResult LoginUser()
        {
                      
            return View();
            
        }
        [HttpPost]
        public ActionResult LoginUser(ticketAdmin adm)
        {
            adm.username = Request.Form["username"];
            adm.pwd = Request.Form["password"];

            var repo = new adminCre();
            var findDet = repo.FindAdmin(adm);
            if (findDet.username == adm.username && findDet.pwd == adm.pwd)
                return RedirectToAction("GetDetails");
            else return View();
        }
        public ActionResult Index()
        {
           
            return View();
        }
        public ActionResult GetDetails()
        {
            var repo = new TicketRepo();
            var model = repo.GetAllTicket();
            return View(model);
        }
        public ActionResult AddTicket()
        {
           
            return View(new ticketsystem());


        }
        [HttpPost]
        public ActionResult AddTicket(ticketsystem ticket)
        {
            var repo = new TicketRepo();
            repo.AddNewTicket(ticket);
            return RedirectToAction("Home");
        }
        public ActionResult Delete(string id)
        {
            var selectedId = int.Parse(id);
            var repo = new TicketRepo();
            repo.DeleteTicket(selectedId);
            return RedirectToAction("Home");
        }
        public ActionResult Home()
        {
            return View();
        }
    }
}