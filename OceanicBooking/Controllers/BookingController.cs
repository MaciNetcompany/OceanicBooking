
using Microsoft.AspNetCore.Cors;
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
        [HttpPost]
        public async Task<IActionResult> OnPost()
        {
            var d = 2;
            var origin = Request.Form["origin"];
            var destination = Request.Form["destination"];
            var weight = Request.Form["weight"];
            var length = Request.Form["length"];
            var width = Request.Form["width"];
            var height = Request.Form["height"];
            var category = Request.Form["category"];


            return RedirectToAction("Index", "Confirmation");
        }

        [Route("find")]
        [HttpGet()]
        [DisableCors]
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
