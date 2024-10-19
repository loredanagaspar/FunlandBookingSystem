using FunlandV3.Areas.Customer.Data;
using FunlandV3.Areas.Customer.Data.Data;
using FunlandV3.Models;
using Microsoft.AspNetCore.Mvc;

namespace FunlandV3.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class GameController : Controller
    {
        private readonly ApplicationDbContext _db;

        public GameController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Game> objGameList = _db.Games.ToList();
            return View(objGameList);
        }
    }
}
