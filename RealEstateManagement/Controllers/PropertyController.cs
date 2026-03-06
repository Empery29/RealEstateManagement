using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstateManagement.Models;

namespace RealEstateManagement.Controllers
{
    public class PropertyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PropertyController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var properties = await _context.Properties.ToListAsync();
            return View(properties);
        }

        public async Task<IActionResult> Details(int id)
        {
            var property = await _context.Properties
                .Include(p => p.Tenants)
                .FirstOrDefaultAsync(p => p.Id == id);

            return View(property);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Property model)
        {
            if (ModelState.IsValid)
            {
                _context.Properties.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var property = await _context.Properties.FindAsync(id);

            _context.Properties.Remove(property);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
