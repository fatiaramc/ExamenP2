using Examen.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examen.DataAccess
{
    public class Proxy : IProxy
    {
        private RestClient _client;
        private string appid = "b1e34d4d55487b41db609a28e5854900";
        private string metric = "metric";

        public Proxy()
        {
            _client = new RestClient("http://api.openweathermap.org/data/2.5/");
        }

        public WeatherObject weather(string ciudad)
        {
            var request = new RestRequest($"weather?q={ciudad}&APPID={appid}&units={metric}");
            var response = _client.Get<WeatherObject>(request);
            return response.Data;
        }
        /*public string weather(string ciudad)
        {
            var request = new RestRequest($"weather?q={ciudad}&APPID={appid}&units={metric}");
            var response = _client.Get(request);
            return response.Content;
        }*/
    }
}