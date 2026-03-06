using Microsoft.AspNetCore.Mvc;
using RealEstateManagement.Models;

namespace RealEstateManagement.Controllers
{

    public class AgentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AgentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var agents = _context.Agents.ToList();
            return View(agents);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Agent model)
        {
            _context.Agents.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
