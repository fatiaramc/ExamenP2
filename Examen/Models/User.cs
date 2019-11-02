using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Examen.Models
{
    public class User
    {
        [Key]
        [Display(Name = "username")]
        public int id { get; set; }

        [Key]
        [Display(Name = "username")]
        [Required(ErrorMessage = "El Nombre de usuario es Requerido")]
        public string username { get; set; }

        [Key]
        [Display(Name = "email")]
        [Required(ErrorMessage = "El email es Requerido")]
        public string email { get; set; }

        [Key]
        [Display(Name = "password")]
        [Required(ErrorMessage = "La contraseña es Requerida")]
        public string password { get; set; }
    }
}