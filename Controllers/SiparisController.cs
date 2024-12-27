using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VtOdev.Models;

namespace VtOdev.Controllers
{
    public class SiparisController : Controller
    {
        private readonly DbodevContext _context;

        public SiparisController()
        {
            _context = new DbodevContext();
        }
        //Fiyat hesaplama eklendi 

        // GET: Siparis
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var dbodevContext = _context.Siparis.Include(s => s.Musteri).Include(s => s.Product);
            int fiyat = 0;
            int adet = 0;
            foreach(var n in dbodevContext)
            {
                adet=n.Adet;
                fiyat = n.Product.Fiyat;
                n.Tutar=fiyat * adet;
            }
            ViewData["searchString"] = "";
            return View(await dbodevContext.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Index(string ad)
        {
            var dbodevContext = _context.Siparis.Include(s => s.Musteri).Include(s => s.Product).Where(x=> x.Musteri.Name == ad);
            int fiyat = 0;
            int adet = 0;
            foreach(var n in dbodevContext)
            {
                adet=n.Adet;
                fiyat = n.Product.Fiyat;
                n.Tutar=fiyat * adet;
            }
            ViewData["searchString"] = ad;
            return View(await dbodevContext.ToListAsync());
        }

        // GET: Siparis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sipari = await _context.Siparis
                .Include(s => s.Musteri)
                .Include(s => s.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sipari == null)
            {
                return NotFound();
            }
            sipari.Tutar = sipari.Adet * sipari.Product.Fiyat;
            return View(sipari);
        }

        // GET: Siparis/Create
        public IActionResult Create()
        {
            ViewData["MusteriId"] = new SelectList(_context.Musteris, "Id", "Name");
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Ad");
            return View();
        }

        // POST: Siparis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Sipari sipari)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sipari);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MusteriId"] = new SelectList(_context.Musteris, "Id", "Name", sipari.MusteriId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Ad", sipari.ProductId);
            return View(sipari);
        }

        // GET: Siparis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sipari = await _context.Siparis.FindAsync(id);
            if (sipari == null)
            {
                return NotFound();
            }
            ViewData["MusteriId"] = new SelectList(_context.Musteris, "Id", "Name", sipari.MusteriId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Ad", sipari.ProductId);
            return View(sipari);
        }

        // POST: Siparis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromForm] Sipari sipari)
        {
            if (id != sipari.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sipari);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SipariExists(sipari.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MusteriId"] = new SelectList(_context.Musteris, "Id", "Name", sipari.MusteriId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Ad", sipari.ProductId);
            return View(sipari);
        }

        // GET: Siparis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sipari = await _context.Siparis
                .Include(s => s.Musteri)
                .Include(s => s.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sipari == null)
            {
                return NotFound();
            }
            sipari.Tutar = sipari.Adet * sipari.Product.Fiyat;

            return View(sipari);
        }

        // POST: Siparis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sipari = await _context.Siparis.FindAsync(id);
            if (sipari != null)
            {
                _context.Siparis.Remove(sipari);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SipariExists(int id)
        {
            return _context.Siparis.Any(e => e.Id == id);
        }
    }
}
