using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace OceanicBooking.Controllers;

[Route("route/[controller]")]
[ApiController]
public class InformationController : ControllerBase
{
    [Route("")]
    [HttpPost()]
    public ActionResult<string> PostData([FromBody] DataModel jsonObject)
    {

        if (jsonObject == null)
        {
            return BadRequest("Route not found");
        }

        //Call calculate route component, where we take the cost and duration and return those values.

        var cost = jsonObject.weight;
        var duration = jsonObject.weight;

        ResponseData response = new ResponseData();
        response.cost = jsonObject.weight;
        response.duration = jsonObject.weight;


        return Ok(new {cost, duration});
    }
}

public class RequestData
{
    public string Data { get; set; }
}

public class ResponseData
{
    public string cost { get; set; }
    public string duration { get; set; }
}

public class DataModel
{
    public string cityTo { get; set; }
    public string cityFrom { get; set; }
    public string deliveryTime { get; set; }
    public DimensionModel dimensions { get; set; }
    public string weight { get; set; }
    public string[] categories { get; set; }
}

public class DimensionModel
{
    public string height { get; set; }
    public string width { get; set; }
    public string length { get; set; }
}