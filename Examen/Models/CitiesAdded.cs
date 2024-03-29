﻿using Examen.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examen.Models
{
    public class CitiesAdded
    {
        private List<string> _cities;
        public List<WeatherObject> weathers = new List<WeatherObject>();
        public Dictionary<string,string> images = new Dictionary<string, string>();

        public CitiesAdded()
        {
            _cities = DataService.GetDataService().getCities(UsuarioGen.GetUsuarioGen().GetUserID());
        }

        public void AddCity(string city)
        {
            if(!_cities.Contains(city))
                _cities.Add(city);
        }

        public List<string> GetCities()
        {
            return _cities;
        }

        public List<WeatherObject> GetWeathers()
        {
            weathers = new List<WeatherObject>();
            foreach(var i in _cities)
            {
                IProxyMaster proxy2 = new Proxy();
                proxy2.IniciarApi();
                var r = proxy2.weather(i);
                weathers.Add(r);
            }
            return weathers;
            
        }

        /*public void GetImages()
        {
            foreach(var i in weathers)
            {
                images.Add(i.name,"http://openweathermap.org/img/wn/" + i.weather[0].icon + "@2x.png");
            }
            //return images;
        }*/

        public IMemento Save()
        {
            return new ConcreteMemento(_cities);
        }

        public void Restore(IMemento memento)
        {
            if(!(memento is ConcreteMemento))
            {
                throw new Exception("Unknown memento class");
            }

            this._cities = memento.GetState();
        }
    }
}