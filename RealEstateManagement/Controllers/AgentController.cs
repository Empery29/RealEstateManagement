using Microsoft.AspNetCore.Mvc;
using RealEstateManagement.Models;
using RealEstateManagement.Models.DTO;

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
        public async Task<IActionResult> Create(AgentRequestModel model)
        {
            var user = new User()
            {
                FullName = model.Name,
                Phone = model.Phone,
                Email = model.Email,
                Gender = model.Gender,
                HashPassword = "Agent123",
                Role = "Agent"
            };
            await _context.Users.AddAsync(user);
            await  _context.Agents.AddAsync(new Agent
            {
                Name = model.Name,
                Phone = model.Phone,
                Email = model.Email
            });
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
