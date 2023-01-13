
using DatabaseComponent.Entitities;
using DatabaseComponent.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Specialized;
using System.Data.Entity;

namespace OceanicBooking.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : Controller
    {
        private readonly IBookingContext _bookingContext;


        public BookingController(IBookingContext bookingContext)
        {
            _bookingContext = bookingContext;
        }
        public ActionResult Index()
        {
            return View();
        }

        [Route("find")]
        [HttpGet()]
        public async Task<IActionResult> FindRoutes()
        {
            var found = true; // TODO: use CalculatingRouteSystem to get routes
            Dictionary<string,string> test = new Dictionary<string,string>();
            test.Add("Origin", "Nairobi");
            test.Add("Destination", "Tunis");
            ISet<CitiesJPA> origin =_bookingContext.Cities.ToHashSet();
            CitiesJPA destination = _bookingContext.Cities.Where(p => p.Name == test.GetValueOrDefault("Destination")).First();
            if (found){
                //TODO: input found routes
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
