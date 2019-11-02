using Examen.Models;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examen.DataAccess
{
    public class ProxyPais : IProxyPais
    {
        private RestClient _client;

        public ProxyPais()
        {
            _client = new RestClient("https://restcountries.eu/rest/v2/all");
        }

        public List<string> city()
        {
            List<string> result = new List<string>();
            var request = new RestRequest();
            var restResponse = _client.Get(request);
            var response = restResponse.Content;
            var objects = JArray.Parse(response);

            foreach(JObject r in objects)
            {
                var k = (string)r["capital"];
                result.Add(k);
            }

            return result;
            //var response = _client.Get<PaisObject>(request);
            //return response.Data;
        }
    }
}