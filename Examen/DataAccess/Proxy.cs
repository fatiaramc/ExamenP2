using Examen.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examen.DataAccess
{
    public class Proxy : IProxyMaster
    {
        private RestClient _client;
        private string appid = "807e039bd90c3a40ac224637ffd000fb";
        private string metric = "metric";

        public Proxy()
        {
            //_client = new RestClient("http://api.openweathermap.org/data/2.5/");
        }

        public override List<string> city()
        {
            throw new NotImplementedException();
        }

        public override void IniciarApi()
        {
            //throw new NotImplementedException();
            _client = new RestClient("http://api.openweathermap.org/data/2.5/");
        }

        /*public WeatherObject weather(string ciudad)
        {
           var request = new RestRequest($"weather?q={ciudad}&APPID={appid}&units={metric}");
            var response = _client.Get<WeatherObject>(request);
            return response.Data;
        }*/

        public override WeatherObject weather(string ciudad)
        {
            //throw new NotImplementedException();
            var request = new RestRequest($"weather?q={ciudad}&APPID={appid}&units={metric}");
            var response = _client.Get<WeatherObject>(request);
            return response.Data;
        }
        public override ForecastObject forecast(string ciudad)
        {
            //throw new NotImplementedException();
            var request = new RestRequest($"forecast?q={ciudad}&APPID={appid}&units={metric}");
            var response = _client.Get<ForecastObject>(request);
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