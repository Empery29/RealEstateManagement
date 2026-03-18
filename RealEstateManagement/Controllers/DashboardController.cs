using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstateManagement.Models;
using RealEstateManagement.Models.DTO;
using System.Security.Claims;

namespace RealEstateManagement.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> TenantDashboard()
        {
            var currentTenants =  _context.Tenants.Include(x => x.Property).Where(x => x.Email == User.FindFirst(ClaimTypes.Email).Value).OrderByDescending(x => x.Id).ToList();
            var currentTenant = currentTenants.FirstOrDefault();

            var pastTenants = _context.Tenants.Include(x => x.Property).Where(x => x.Email == User.FindFirst(ClaimTypes.Email).Value).OrderByDescending(x => x.Id).ToList();

            var maintenance = _context.MaintenanceRequests.Where(x => x.UserId.ToString() == User.FindFirst(ClaimTypes.NameIdentifier).Value).OrderByDescending(x => x.Id).ToList();
            ;
            return View(new TenantDashboardViewModel() { CurrentTenant = currentTenant, PastTenants = pastTenants, MaintenanceRequests = maintenance});
        }

        public IActionResult Dashboard()
        {
            ViewBag.Properties = _context.Properties.Count();
            ViewBag.Lands = _context.Lands.Count();
            ViewBag.Tenants = _context.Tenants.Count();
            ViewBag.Agents = _context.Agents.Count();
            ViewBag.Payments = _context.Payments.Sum(p => p.Amount);
            ViewBag.Maintenance = _context.MaintenanceRequests.Count();

            return View();
        }
    }
}
