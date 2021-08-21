using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiVentas.Core.Models
{
    public partial class Rol
    {
        public Rol()
        {
            UsuarioRols = new HashSet<UsuarioRol>();
            Usuarios = new HashSet<Usuario>();
        }

        public int RolId { get; set; }
        public string NombreRol { get; set; }

        public virtual ICollection<UsuarioRol> UsuarioRols { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
