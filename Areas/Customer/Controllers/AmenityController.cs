using FunlandV3.Areas.Customer.Data;
using FunlandV3.Areas.Customer.Data.Data;
using FunlandV3.Models;
using Microsoft.AspNetCore.Mvc;

namespace FunlandV3.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class AmenityController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AmenityController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Amenity> objAmenityList = _db.Amenities.ToList();
            return View(objAmenityList);
        }
    }
}
