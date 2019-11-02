using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examen.Models
{
    public class UsuarioGen
    {
        public static UsuarioGen _usuariogen;
        public static User user;

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
        }

        public int GetUserID()
        {
            return user.id;
        }
    }
}
