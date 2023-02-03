using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCApp.DataComponent
{
    public class TicketRepo
    {
        private readonly TicketDataContext _context = new TicketDataContext();

        public void AddNewTicket(ticketsystem ticket)
        {
            ticket.TicketTime = DateTime.Now.ToLongTimeString();
            _context.ticketsystems.InsertOnSubmit(ticket);
            _context.SubmitChanges();
        }

        public List<ticketsystem> GetAllTicket() => _context.ticketsystems.ToList();

        public void DeleteTicket(int id)
        {
            var ticket= _context.ticketsystems.FirstOrDefault((c) => c.TicketNo == id);
            _context.ticketsystems.DeleteOnSubmit(ticket);
            _context.SubmitChanges();
        }
        public List<ticketsystem> GetAllTicketByEmpId(int id)
        {
            var ticket = from emp in _context.ticketsystems where emp.EmpId == id select emp;

            return ticket.ToList();
        } 
    }
}