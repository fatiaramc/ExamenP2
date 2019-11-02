using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examen.Models
{
    public interface IProxy
    {
        WeatherObject weather(string ciudad);
        //string weather(string ciudad);

    }
}