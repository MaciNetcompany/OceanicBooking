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

        if (jsonObject == null )
        {
            return BadRequest("Route not found");
        }

        //Call calculate route component, where we take the cost and duration and return those values.

        var cost = jsonObject.weight;
        var duration = jsonObject.weight;


        string response = $"{{\"cost\":{cost},\"duration\":{duration}}}";
        return Ok(response);
    }

    public ActionResult<string> GetData(DataModel jsonObject)
    {
        var json = JsonConvert.SerializeObject(jsonObject);
        //Do not call this until we have urls.
        var responseTelstar = SendRequest(json, "https://wa-tl-dk2.azurewebsites.net/information/order");

        var responseEastIndia = SendRequest(json, "https://XXX2.azurewebsites.net//route/information");

        if (responseTelstar.Result[1] < responseEastIndia.Result[1])
        {
            return responseTelstar.Result;
        }

        return responseEastIndia.Result;
    }

    private async Task<string> SendRequest(string json, string url)
    {
        using (var client = new HttpClient())
        {
            var response = await client.PostAsync(url, new StringContent(json, System.Text.Encoding.UTF8, "application/json"));
            var responseString = JsonConvert.SerializeObject(response);
            return responseString;
        }
    }
}

public class RequestData
{
    public string Data { get; set; }
}

public class ResponseData
{
    public string Result { get; set; }
}

public class DataModel
{
    public string start_destination { get; set; }
    public string stop_destination { get; set; }
    public string start_destination_arrival { get; set; }
    public DimensionModel dimensions { get; set; }
    public string weight { get; set; }
    public string categories { get; set; }
}

public class DimensionModel
{
    public string height { get; set; }
    public string width { get; set; }
    public string length { get; set; }
}