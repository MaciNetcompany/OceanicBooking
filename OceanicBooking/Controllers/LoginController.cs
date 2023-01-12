using Microsoft.AspNetCore.Mvc;
namespace OceanicBooking.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {

        public LoginController()
        {
        }

        public ActionResult Index()
        {
            return View();
        }


        [Route("auth")]
        [HttpGet()]
        public async Task<IActionResult> AuthenticateUser()
        {
            var logged = true; // TODO: use UserAuthSystem to get if we are logged in
            if (logged)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

    }
}