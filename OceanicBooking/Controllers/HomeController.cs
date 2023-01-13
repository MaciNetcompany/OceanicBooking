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

        public ActionResult Index()
        {
            return View();
        }

        [Route("export")]
        [HttpGet()]
        public async Task<IActionResult> ExportParcels()
        {
            var exported = true; // TODO: use ExportingComponent to get if we managed to export file
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
