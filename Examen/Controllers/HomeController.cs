﻿using Examen.DataAccess;
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
            return View(result);
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
        public ActionResult AddCity()
        {
            return View("SearchCity");
        }

        public ActionResult SearchCity()
        {
            IProxyPais proxy = new ProxyPais();
            cities = proxy.city();
            return View(new WeatherObject());
        }

        [HttpPost]
        public ActionResult OnSearchCity(string searchTerm)
        {
            WeatherObject r = null;
            if (cities.Contains(searchTerm))
            {
                IProxy proxy = new Proxy();
                r = proxy.weather(searchTerm);
            }
            return View(r);
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