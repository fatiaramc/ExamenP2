using Examen.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Examen.Models
{
    public class UsuarioGen : Controller
    {
        public static UsuarioGen _usuariogen;
        public static User user;
        public static CitiesAdded citiesAdded = new CitiesAdded();
        public static Caretaker caretaker = new Caretaker(citiesAdded);
        public static List<string> citiesBD = new List<string>();

        private UsuarioGen()
        {
            user = new User()
            {
                 id= 0,
                username = "",
                email = ""
            };
        }

        public static UsuarioGen GetUsuarioGen()
        {
            if(_usuariogen == null)
            {
                _usuariogen = new UsuarioGen();
            }
            return _usuariogen;
        }

        public static void ChangeUser(User u)
        {
            user.id = u.id;
            user.username = u.username;
            user.email = u.email;
            citiesBD = DataService.GetDataService().getCities(user.id);
        }

        public static void updateCitiesBD()
        {
            citiesBD = DataService.GetDataService().getCities(user.id);
        }

        public int GetUserID()
        {
            return user.id;
        }

        public static void Update()
        {
            _usuariogen = new UsuarioGen();
            citiesAdded = new CitiesAdded();
            caretaker = new Caretaker(citiesAdded);
            citiesBD = new List<string>();
            return;

        }
    }
}
