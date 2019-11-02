using Examen.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examen.Models
{
    public class BusquedaCiudad : Busqueda
    {

        public override List<string> opciones { get; set; }
        public override WeatherObject resultado{ get; set; }

        public override List<string> getOpciones()
        {
            IProxyMaster proxy = new ProxyPais();
            proxy.IniciarApi();
            opciones = proxy.city();
            return opciones;
        }

        public override WeatherObject getResultado(string searchTerm)
        {
            resultado = new WeatherObject();
            if (opciones.Contains(searchTerm))
            {
                IProxyMaster proxy2 = new Proxy();
                proxy2.IniciarApi();
                resultado = proxy2.weather(searchTerm);
            }
            return resultado;
        }
    }
}