using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstateManagement.Models;
using RealEstateManagement.Models.DTO;

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

        public async Task<IActionResult> Search()
        {
            var houseForSale = await _context.Properties.Where(k => k.IsAvailable == true && k.IsHouse == true && k.IsForSale == true).ToListAsync();
            var houseForRent = await _context.Properties.Where(k => k.IsAvailable == true && k.IsHouse == true && k.IsForRent == true).ToListAsync();
            var flatForSale = await _context.Properties.Where(k => k.IsAvailable == true && k.IsFlat == true && k.IsForSale == true).ToListAsync();
            var flatForRent = await _context.Properties.Where(k => k.IsAvailable == true && k.IsFlat == true && k.IsForRent == true).ToListAsync();

            var properties = new PropertyCategoryResponseModel
            {
                HouseForRent = houseForRent,
                HouseForSale = houseForSale,
                FlatForRent = flatForRent,
                FlatForSale = flatForSale
            };
            return View(properties);
        }
        public async Task<IActionResult> Details(int id)
        {
            var property = await _context.Properties
                .Include(p => p.Tenants)
                .FirstOrDefaultAsync(p => p.Id == id);

            return View(property);
        }
        [HttpPost]

        public async Task<IActionResult> AvailableProperties(FilterRequest model)
        {
            bool isForRent = model.IsForSale == "True" ? false : true;
            bool isForSale = model.IsForSale == "True" ? true : false;

            bool isFlat = model.IsFlat == "True" ? true : false;
            bool isHouse = model.IsFlat == "True" ? false : true;

            var properties = await _context.Properties.Where(x => x.IsAvailable == true && x.IsForRent == isForRent && x.IsForSale == 
            isForSale && x.IsFlat == isFlat && x.IsHouse == isHouse && x.Bedrooms == model.Bedrooms).ToListAsync();
            return View(properties);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePropertyRequestModel model)
        {
            bool isForRent = model.IsForSale == "True" ? false : true;
            bool isForSale = model.IsForSale == "True" ? true : false;

            bool isFlat = model.IsFlat == "True" ? true : false;
            bool isHouse = model.IsFlat == "True" ? false : true;
            if (ModelState.IsValid)
            {

                _context.Properties.Add(new Property
                {
                    Title = model.Title,
                    Address = model.Address,
                    price = model.price,
                    Bedrooms = model.Bedrooms,
                    IsAvailable = true,
                    IsForRent = isForRent,
                    IsForSale = isForSale,
                    IsFlat = isFlat,
                    IsHouse = isHouse,
                    ImageUrl = model.ImageUrl

                });
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

        //public async Task<IActionResult> Update(int id)
        //{
        //    var property = await _context.Properties.FindAsync(id);

        //    _context.Properties.Remove(property);
        //    await _context.SaveChangesAsync();

        //    return RedirectToAction("Index");
        //}
    }
}
