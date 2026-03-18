using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstateManagement.Models;
using RealEstateManagement.Models.DTO;
using System.Security.Claims;

namespace RealEstateManagement.Controllers
{
    public class MaintenanceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MaintenanceController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var requests = await _context.MaintenanceRequests
           // .Include(m => m.Property)
            .ToListAsync();

            return View(requests);
        }

        public async Task<IActionResult> Acknowledgement(int id)
        {
            var maintenance = await _context.MaintenanceRequests.SingleOrDefaultAsync(x => x.Id == id);
            maintenance.Status = "Processing";
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Maintenance");
        }

        public async Task<IActionResult> Resolved(int id)
        {
            var maintenance = await _context.MaintenanceRequests.SingleOrDefaultAsync(x => x.Id == id);
            maintenance.Status = "Resolved";
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Maintenance");
        }

        public async Task<IActionResult> Create(int tenantId)
        {
            var tenant = await _context.Tenants.SingleOrDefaultAsync(x => x.Id == tenantId);
            return View(tenant);
        }
   

        [HttpPost]

        public async Task<IActionResult> Create(MaintenanceRequestDto model)
        {
            var tenant = await _context.Tenants.SingleOrDefaultAsync(x => x.Id == model.TenantId);
            _context.MaintenanceRequests.Add(new MaintenanceRequest
            {
                PropertyTitle = model.Title,
                TenantEmail = tenant.Email,
                TenantName = tenant.FullName,
                UserId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value),
                Issue = model.Issue,
                PropertyId = tenant.PropertyId,
                DateReported = DateTime.UtcNow
            });
            await _context.SaveChangesAsync();

            return RedirectToAction("TenantDashboard","Dashboard");
        }
    }
}
