using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examen.Models
{
    public abstract class IProxyMaster
    {
        public abstract void IniciarApi();
        public abstract WeatherObject weather(string ciudad);
        public abstract ForecastObject forecast(string ciudad);
        public abstract List<string> city();
    }
}