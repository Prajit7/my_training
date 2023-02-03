using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCApp.DataComponent
{
    public class adminCre
    {
        private readonly adminDataContext _context = new adminDataContext();
        public ticketAdmin FindAdmin(ticketAdmin adm)
        {
           var username= _context.ticketAdmins.FirstOrDefault((p) => p.username == adm.username);
           return username;
            
        }
    }
}