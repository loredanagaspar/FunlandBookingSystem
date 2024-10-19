using FunlandV3.Areas.Customer.Data;
using FunlandV3.Areas.Customer.Data.Data;
using FunlandV3.Models;
using Microsoft.AspNetCore.Mvc;

namespace FunlandV3.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class PartyRoomController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PartyRoomController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<PartyRoom> objPartyRoomList = _db.PartyRooms.ToList();
            return View(objPartyRoomList);
        }
    }
}
