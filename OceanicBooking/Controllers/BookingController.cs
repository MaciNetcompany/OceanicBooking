
using Microsoft.AspNetCore.Mvc;

namespace OceanicBooking.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : Controller
    {

        public BookingController()
        {
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
            if (found)
            {
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
