
using Microsoft.AspNetCore.Mvc;

namespace OceanicBooking.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ConfirmationController : Controller
    {

        public ConfirmationController()
        {
        }
        public ActionResult Index()
        {
            return View();
        }

        [Route("book")]
        [HttpGet()]
        public async Task<IActionResult> BookRoutes()
        {
            var selected = true; // TODO: get user input to find selected route
            if (selected)
            {
                //TODO: use BookingSystem to book the route
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
