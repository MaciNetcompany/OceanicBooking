using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DatabaseComponent.Services
{
    public class InformationGatherer
    {
        private string token =
            "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJjb21wYW55IjoiT2NlYW5pY3MifQ.eAayd9TP8peFENeAK9wV-lli3IIPHRR0nDsInPpbLFg";

        public ResponseData GetData(DataModel jsonObject)
        {
            try
            {
                var json = JsonConvert.SerializeObject(jsonObject);

                var responseTelstar =
                    JsonConvert.DeserializeObject(SendRequest(json,
                        "https://wa-tl-dk2.azurewebsites.net/route/information").Result);

                var responseEastIndia =
                    JsonConvert.DeserializeObject(SendRequest(json,
                        "https://wa-eit-dk2.azurewebsites.net/route/information", token).Result);

                ResponseData responseEastIndia2 =
                    JsonConvert.DeserializeObject<ResponseData>(responseEastIndia.ToString());
                ResponseData responseEastTelstar2 =
                    JsonConvert.DeserializeObject<ResponseData>(responseTelstar.ToString());

                float.Parse(responseEastIndia2.duration);

                if (float.Parse(responseEastIndia2.duration) < float.Parse(responseEastTelstar2.duration))
                {
                    return responseEastIndia2;
                }
                else
                {
                    return responseEastTelstar2;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("A route from external systems could not be found", ex);
            }
        }

        private async Task<string> SendRequest(string json, string url, string? token = null)
        {
            using (var client = new HttpClient())
            {
                if (token is not null)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",
                    token);
                }
                var response = await client.PostAsync(url, new StringContent(json, System.Text.Encoding.UTF8, "application/json"));
                var responseString = JsonConvert.SerializeObject(await response.Content.ReadAsStringAsync());
                return responseString;
            }
        }
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
}
