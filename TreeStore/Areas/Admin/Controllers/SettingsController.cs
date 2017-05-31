using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TreeStore.Data;
using TreeStore.Models.Entities;
using Microsoft.AspNetCore.Hosting;

namespace TreeStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SettingsController : Controller
    {
        private ApplicationDbContext context;
        private IHostingEnvironment env;
        public SettingsController(IHostingEnvironment _env, Data.ApplicationDbContext _context)
        {
            this.context = _context;
            this.env = _env;
        }
        public IActionResult Index()
        {
            Setting setting;
            setting = context.Setting.FirstOrDefault();
            if (setting == null)
            {
                setting = new Setting();
            }
            return View(setting);
        }
        [HttpPost]
        public IActionResult Index(Setting setting)
        {
            Setting s = context.Setting.FirstOrDefault();
            if (ModelState.IsValid)
            {
                
                if (context.Setting.Any())
                {
                   
                    s.WelcomeText = setting.WelcomeText;
                    s.MembershipAgreement = setting.MembershipAgreement;
                    s.UpdateDate = DateTime.Now;
                    s.SeoTitle = setting.SeoTitle;
                    s.SeoDescription = setting.SeoDescription;
                    s.SeoKeywords = setting.SeoKeywords;
                    s.Address = setting.Address;
                    s.Phone = setting.Phone;
                    s.Fax = setting.Fax;
                    s.Mail = setting.Mail;
                    s.About = setting.About;
                    s.PrivacyPolicy = setting.PrivacyPolicy;
                    s.TermsOfUse = setting.TermsOfUse;
                    context.SaveChanges();
                }
                else
                {
                    context.Setting.Add(setting);
                    context.SaveChanges();
                    ViewBag.Message = "Ayarlar baþarýyla kaydedildi.";
                }
            }
            
            return View(setting);
        }
    }
}
