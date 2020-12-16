using System.Net;
using MagicDemo.Constants;
using RestSharp;

namespace MagicDemo.Services
{
    public class Service
    {
        public bool ValidateLocation(string location)
        {
            bool result = false;
            var client = new RestClient(BaseUrl.BaseAPI);
            var request = new RestRequest("/api/getValidAddresses/" + location, Method.GET);
            request.AddHeader("Referer", BaseUrl.BaseAPI);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                result = true;
            }

            return result;
        }
    }
}
