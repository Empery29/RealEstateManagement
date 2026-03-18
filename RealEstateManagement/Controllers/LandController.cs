using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstateManagement.Models;
using RealEstateManagement.Models.DTO;

namespace RealEstateManagement.Controllers
{
    public class LandController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LandController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var lands = await _context.Lands.ToListAsync();
            return View(lands);
        }

        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var land = await _context.Lands
                .FirstOrDefaultAsync(m => m.Id == id);

            if (land == null)
            {
                return NotFound();
            }

            return View(land);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Land model)
        {
           

                _context.Lands.Add(new Land
                {
                    Title = model.Title,
                    Address = model.Address,
                    SurveyNumber = model.SurveyNumber,
                    SizeSquareMeters = model.SizeSquareMeters,
                    City = model.City,
                });
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }




            //[HttpPost]
            //[ValidateAntiForgeryToken]
            //public IActionResult Create(Land land)
            //{
            //    if (ModelState.IsValid)
            //    {
            //        _context.Add(land);
            //        return RedirectToAction(nameof(Index));
            //    }
            //    return View(land);
            //}
        }
}
