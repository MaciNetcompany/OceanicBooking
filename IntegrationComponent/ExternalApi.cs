using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


[ApiController]
public class InformationController : ControllerBase
{
    [HttpPost("/route/information")]
    public ActionResult<string> PostData(RequestData jsonObject)
    {
        // Do something with the posted data, first we have to validate the information.
        // ...
        if (jsonObject == null)//Neds to be updated to check if we have a valid route and if not we return badrequest with a custom message,
        {
            return BadRequest("Route not found");
        }

        // Process the request and prepare the response
        var response = new ResponseData();
        var cost = 0;
        var duration = 0;


        response.Result = $"{{\"cost\":{cost},\"duration\":{duration}}}";
        return Ok(response.Result);
    }

    [HttpGet("/route/information")]
    public ActionResult<string> GetData(RequestData jsonObject)
    {
        var json = JsonConvert.SerializeObject(jsonObject);

        var response1 = SendRequest(json, "https://firstplace.com/route/information");

        var response2 = SendRequest(json, "https://secondplace.com/route/information");

        if (response1[1] < response2[1])
        {
            return response1;
        }

        return response2;
    }

    private string SendRequest(string json, string url)
    {
        using (var client = new HttpClient())
        {
            var response =  client.PostAsync(url, new StringContent(json, System.Text.Encoding.UTF8, "application/json"));
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