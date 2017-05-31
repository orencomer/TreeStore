using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TreeStore.Data;
using TreeStore.Models;

namespace TreeStore.Controllers
{
    public class MyCampaignsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MyCampaignsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: MyCampaigns
        public async Task<IActionResult> Index()
        {
            return View(await _context.Campaign.ToListAsync());
        }

        // GET: MyCampaigns/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campaign = await _context.Campaign
                .SingleOrDefaultAsync(m => m.Id == id);
            if (campaign == null)
            {
                return NotFound();
            }

            return View(campaign);
        }

        // GET: MyCampaigns/Create
        public IActionResult Create()
        {
            var myCampaign = new Campaign();
            return View(myCampaign);
        }

        // POST: MyCampaigns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Description,Slogan,StartedDate,EndDate,ImagePath,IsActive,Id,Name,CreateDate,UpdateDate,CreatedBy,UpdateBy")] Campaign campaign)
        {
            if (ModelState.IsValid)
            {
                _context.Add(campaign);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(campaign);
        }

        // GET: MyCampaigns/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campaign = await _context.Campaign.SingleOrDefaultAsync(m => m.Id == id);
            if (campaign == null)
            {
                return NotFound();
            }
            return View(campaign);
        }

        // POST: MyCampaigns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Description,Slogan,StartedDate,EndDate,ImagePath,IsActive,Id,Name,CreateDate,UpdateDate,CreatedBy,UpdateBy")] Campaign campaign)
        {
            if (id != campaign.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(campaign);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CampaignExists(campaign.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(campaign);
        }

        // GET: MyCampaigns/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campaign = await _context.Campaign
                .SingleOrDefaultAsync(m => m.Id == id);
            if (campaign == null)
            {
                return NotFound();
            }

            return View(campaign);
        }

        // POST: MyCampaigns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var campaign = await _context.Campaign.SingleOrDefaultAsync(m => m.Id == id);
            _context.Campaign.Remove(campaign);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CampaignExists(long id)
        {
            return _context.Campaign.Any(e => e.Id == id);
        }
    }
}
