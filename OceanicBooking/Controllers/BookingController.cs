
using CalculatingRouteSystem;
using CalculatingRouteSystem.Models;
using DatabaseComponent.Entitities;
using DatabaseComponent.Interfaces;
using Microsoft.AspNetCore.Mvc;

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

            ISet<CitiesJPA> cities =_bookingContext.Cities.ToHashSet();
           
            var relationsList = new List<RelationsJPA>();
            var nodes = new Dictionary<int, Node>();
            foreach (var city in cities)
            {
                relationsList.AddRange(_bookingContext.Relations.Where(x => x.ID_City == city.Id).ToList());
                nodes.Add(city.Id, new Node(city.Id.ToString()) );
            }
            var graph = new Graph();
            int i = 0;
            foreach (var relation in relationsList)
            {
                nodes[relation.ID_City].AddNeighbour(nodes[relation.ID_Neighbour],i%2==0?2:4);
            }
            foreach(var n in nodes)
            {
                graph.Add(n.Value);
            }
            DistanceCalculator calc = new DistanceCalculator(graph);
            Node[] node = calc.Calculate(nodes[2], nodes[5]);
             return Ok(node[0].ToString() + "," + node[1].ToString());

        }
    }
}
