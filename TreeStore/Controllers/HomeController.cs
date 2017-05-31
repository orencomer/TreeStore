using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TreeStore.Data;
using TreeStore.Models.Entities;

namespace TreeStore.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext context;
        
        public HomeController(ApplicationDbContext _context)
        {
            this.context = _context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Route("hakkinda")]
        public IActionResult About()
        {
            ViewBag.About = context.Settings.FirstOrDefault().About;
            
            return View();
        }
        [Route("iletisim")]
        public IActionResult Contact()
        {
            ViewBag.Address = context.Settings.FirstOrDefault().Address;
            ViewBag.Phone = context.Settings.FirstOrDefault().Phone;
            ViewBag.Mail = context.Settings.FirstOrDefault().Mail;
            ViewBag.Fax = context.Settings.FirstOrDefault().Fax;
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
