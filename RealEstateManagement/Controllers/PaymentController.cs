using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstateManagement.Models;

namespace RealEstateManagement.Controllers
{
    public class PaymentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PaymentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var payments = await _context.Payments.Include(p => p.Tenant).ToListAsync();
            return View(payments);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Payment model)
        {
            _context.Payments.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }

}
