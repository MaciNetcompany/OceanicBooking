using DatabaseComponent.Entitities;
using DatabaseComponent.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace OceanicBooking.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly IBookingContext _bookingContext;
        public HomeController(IBookingContext bookingContext)
        {
            this._bookingContext=bookingContext;
        }


        [Route("GetParcelDeliveries")]
        [HttpGet()]
        public async Task<List<BookingsJPA>> GetParcelDeliveries()
        {
            var bookings = await _bookingContext.Bookings.ToListAsync(); 
            if (!bookings.IsNullOrEmpty())
            {
                return bookings;
            }
            else
            {
                return null;
            }
            
        }

        [Route("admin")]
        public ActionResult AdminIndex()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }

        [Route("export")]
        [HttpGet()]
        public async Task<IActionResult> ExportParcels()
        {
            var routes = new List<FlyRoute>();
            routes.Add(new FlyRoute()
            {
                Category = Categories.Weapons,
                Date = DateTime.Now,
                DestinationPoint = "Point1",
                Dimensions = new decimal[]{4.1m,4.2m,4.5m},
                Price = 22.3m,
                RouteID = 0,
                SourcePoint = "Point0",
                Weight = 10.1m
                
            });
            routes.Add(new FlyRoute()
            {
                Category = Categories.Weapons,
                Date = DateTime.Now,
                DestinationPoint = "Point3",
                Dimensions = new decimal[] { 4.1m, 4.2m, 4.5m },
                Price = 22.3m,
                RouteID = 0,
                SourcePoint = "Point2",
                Weight = 10.1m

            });
            routes.Add(new FlyRoute()
            {
                Category = Categories.Weapons,
                Date = DateTime.Now,
                DestinationPoint = "Point7",
                Dimensions = new decimal[] { 4.1m, 4.2m, 4.5m },
                Price = 22.3m,
                RouteID = 1,
                SourcePoint = "Point4",
                Weight = 10.1m

            });
            var exported = _csvExporter.SaveToCSV(routes);
            if (exported)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [Route("save_prices")]
        [HttpGet()]
        public async Task<IActionResult> SavePrices()
        {
            var saved = true; // TODO: use BookingSystem to get if we managed to save prices
            if (saved)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [Route("add")]
        [HttpGet()]
        public async Task<IActionResult> AddParcels()
        {
            //forward to the booking page
            return Ok();
        }

    }
}
