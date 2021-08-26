﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiVentas.Core.DTOs
{
    public class UsuarioDto
    {
        public int usuarioId { get; set; }
        public string nombre { get; set; }
        public string contraseña { get; set; }
        public int rolId {get; set; }

        public DateTime fechaCreacion { get; set; }
    }
}
