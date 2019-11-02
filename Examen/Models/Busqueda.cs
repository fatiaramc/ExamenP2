using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examen.Models
{
    public abstract class Busqueda
    {
        public virtual List<string> opciones { get; set; }
        public virtual WeatherObject resultado { get; set; }

        public abstract List<string> getOpciones();
        public abstract WeatherObject getResultado(string searchTerm);
    }
}