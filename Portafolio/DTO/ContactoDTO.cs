﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Portafolio.DTO
{
    public class ContactoDTO
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        [EmailAddress]
        public string Correo { get; set; }
        [Required]
        public string Mensaje { get; set; }
    }
}