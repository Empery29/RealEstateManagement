using Microsoft.AspNetCore.Mvc;
using RealEstateManagement.Models;

namespace RealEstateManagement.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Dashboard()
        {
            ViewBag.Properties = _context.Properties.Count();
            ViewBag.Tenants = _context.Tenants.Count();
            ViewBag.Agents = _context.Agents.Count();
            ViewBag.Payments = _context.Payments.Sum(p => p.Amount);
            ViewBag.Maintenance = _context.MaintenanceRequests.Count();

            return View();
        }
    }
}
