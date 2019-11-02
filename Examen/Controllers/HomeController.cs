using Examen.DataAccess;
using Examen.Models;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Examen.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataService _dataService = DataService.GetDataService();
        private UsuarioGen _user = UsuarioGen.GetUsuarioGen();
        List<string> cities;

        public ActionResult Index()
        {
            //use of proxy
            /*IProxy proxy = new Proxy();
            var r =proxy.weather("ABUJA").main.temp;
            var response = "" + r;
            return Content(response);*/
            /*IProxyPais proxy = new ProxyPais();
            var r = proxy.city();*/
            UsuarioGen.Update();
            return View();
        }

        public ActionResult Signup()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Dashboard()
        {
            //ViewBag.Message = "Your contact page.";
            var result = _dataService.getCities(_user.GetUserID());
            var q = UsuarioGen.citiesAdded;
            return View(q);
        }

        [HttpPost]
        public ActionResult SetUser(string name, string pass)
        {

            string errors = "";
            var x = _dataService.getUser(name);
            if(x!= null)
            {
                if (x.password != pass)
                {
                    errors += "Contraseña incorrecta";
                }
                else
                {
                    UsuarioGen.ChangeUser(x);
                    return RedirectToAction("Dashboard");
                }
            }
            errors = "Error en usuario";
            return Content(errors);



            //return View("Contact");
        }

        [HttpPost]
        public ActionResult AddCity(WeatherObject w)
        {
            if (!UsuarioGen.citiesBD.Contains(w.name))
            {
                UsuarioGen.caretaker.Backup();
                UsuarioGen.citiesAdded.AddCity(w.name);
                _dataService.addCity(UsuarioGen.GetUsuarioGen().GetUserID(), w.name);
                UsuarioGen.updateCitiesBD();
            }
            var q = UsuarioGen.citiesAdded;
            //q.GetImages();
            return View(q);
            //return View();
        }

        public ActionResult City()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SearchCity(string searchTerm)
        {
            var q = Request.Form["searchTerm"];
            /*IProxyPais proxy = new ProxyPais();
            cities = proxy.city();
            WeatherObject r = null;
            if (cities.Contains(searchTerm))
            {
                IProxy proxy2 = new Proxy();
                r = proxy2.weather(searchTerm);
            }
            return View(r,cities);*/
            //imaginamos que despues queremos implementar busquedas por otro valor

            //string sText = drop.Itemes[Select.SelectedIndex].Text;

            Busqueda b = new BusquedaCiudad();
            b.getOpciones();
            b.getResultado(searchTerm);
            if(b.resultado.weather !=null)
                ViewBag.Image = "http://openweathermap.org/img/wn/"+ b.resultado.weather[0].icon + "@2x.png";

            return View(b);
        }

        [HttpPost]
        public ActionResult OnSearchCity(string searchTerm)
        {
            WeatherObject r = null;
            if (cities.Contains(searchTerm))
            {
                IProxyMaster proxy = new Proxy();
                proxy.IniciarApi();
                r = proxy.weather(searchTerm);
            }
            return View(r);
        }

        [HttpPost]
        public ActionResult ViewMore(WeatherObject w)
        {
            IProxyMaster prox = new Proxy();
            prox.IniciarApi();
            var k = prox.forecast(w.name);
            if (w.weather != null)
                ViewBag.Image = "http://openweathermap.org/img/wn/" + k.list[0].weather[0].icon + "@2x.png";
            return View(k);
        }

        /*[HttpPost]
        public ActionResult SearchCity(string searchTerm)
        {
            IProxyPais proxy = new ProxyPais();
            cities = proxy.city();
            List<string> result = new List<string>();
            if (string.IsNullOrEmpty(searchTerm))
            {
                result = cities;
            }
            else
            {
                var q= cities.Where(x => x.StartsWith(searchTerm));
            }
            return View(result);
        }*/
        public JsonResult GetCities(string term)
        {
            List<string> result;
            result = cities.Where(x => x.StartsWith(term)).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult RegisterUser(string name, string email, string pass)
        {
            if (IsValidEmail(email))
            {

            }
            else
            {
                return Content("Email is not valid");
            }
            return Content(name);
            
        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}