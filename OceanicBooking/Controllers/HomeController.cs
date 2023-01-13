using DatabaseComponent.Entitities;
using DatabaseComponent.Interfaces;
using ExportingComponent.Interfaces;
using ExportingComponent.NewFolder;
using Microsoft.AspNetCore.Mvc;
using OceanicBooking.Models.Home;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace OceanicBooking.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly IBookingContext _bookingContext;
        private readonly ICSVExporter _csvExporter;
        private const string MimeType = "text/csv";
        private const string FileName = "raport.csv";
        public HomeController(IBookingContext bookingContext, ICSVExporter csvExporter)
        {
            this._bookingContext=bookingContext;
            this._csvExporter = csvExporter;
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
        [Route("download")]
        public ActionResult Download()
        {
            var routes = _bookingContext.Bookings.Select(x=>x).ToList();
            var cities = _bookingContext.Cities.Select(x => x).ToList();
            var flights=_bookingContext.Flights.Select(x => x).ToList();
            var exported = _csvExporter.SaveToCSV(routes,cities,flights);
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(exported);
            writer.Flush();
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream.GetBuffer(), MimeType, FileName);
        }

        [Route("export")]
        [HttpGet()]
        public ActionResult ExportParcels()
        {
            var routes = new List<FlyRoute>();
            routes.Add(new FlyRoute()
            {
                Category = "Weapons",
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
                Category = "Fragile",
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
                Category = "None",
                Date = DateTime.Now,
                DestinationPoint = "Point7",
                Dimensions = new decimal[] { 4.1m, 4.2m, 4.5m },
                Price = 22.3m,
                RouteID = 1,
                SourcePoint = "Point4",
                Weight = 10.1m

            });
            var exported = _csvExporter.SaveToCSV(routes);
            //return Download(new HomeViewModel(){CSV = exported});
            return Ok(exported);
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
