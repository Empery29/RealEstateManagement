using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstateManagement.Models;

namespace RealEstateManagement.Controllers
{
    public class TenantController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TenantController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var tenants = await _context.Tenants.Include(t => t.Property).ToListAsync();
            return View(tenants);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Tenant model)
        {
            _context.Tenants.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}

