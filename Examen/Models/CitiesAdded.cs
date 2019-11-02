using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examen.Models
{
    public class CitiesAdded
    {
        private List<string> _cities;

        public CitiesAdded()
        {
            _cities = new List<string>();
        }

        public void AddCity(string city)
        {
            _cities.Add(city);
        }

        public List<string> GetCities()
        {
            return _cities;
        }

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