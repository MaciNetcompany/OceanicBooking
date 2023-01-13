using DatabaseComponent.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace OceanicBooking.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        string adminUserName="admin";
        private string bookerUserName = "booker";
        private readonly IBookingContext _bookingContext;

        public LoginController(IBookingContext context)
        {
            this._bookingContext=context;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> OnPost()
        {
            var d = 2;
            var username = Request.Form["username"];
            var password = Request.Form["password"];
            String userName = _
            if (username[0] == null || password[0] == null)
            {
                return BadRequest();
            }

            if (username[0].Equals(adminUserName))
            {
                return RedirectToAction("AdminIndex", "Home");
            }
            else if (username[0].Equals(bookerUserName))
            {
                return RedirectToAction("Index", "Home");
            }

            return BadRequest();
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