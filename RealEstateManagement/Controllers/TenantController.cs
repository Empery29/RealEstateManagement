using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstateManagement.Models;
using RealEstateManagement.Models.DTO;

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
            var user = new User()
            {
                FullName = model.FullName,
                Gender = model.Gender,
                Phone = model.Phone,
                Email = model.Email,
                HashPassword = "Tenant123",
                Role = "Tenant"
            };
            await _context.Users.AddAsync(user);
            model.ExpiryDate = model.MoveInDate.AddYears(model.NumberOfYear);
            await _context.Tenants.AddAsync(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}

