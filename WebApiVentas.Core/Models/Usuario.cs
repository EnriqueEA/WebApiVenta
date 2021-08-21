using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiVentas.Core.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            UsuarioRols = new HashSet<UsuarioRol>();
        }

        public int UsuarioId { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int RolId { get; set; }

        public virtual Rol Rol { get; set; }
        public virtual ICollection<UsuarioRol> UsuarioRols { get; set; }
    }
}
