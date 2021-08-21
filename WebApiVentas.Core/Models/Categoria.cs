using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiVentas.Core.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            InverseCategoriaPadreNavigation = new HashSet<Categoria>();
            Productos = new HashSet<Producto>();
        }

        public int CategoriaId { get; set; }
        public string NombreCategoria { get; set; }
        public int? CategoriaPadre { get; set; }

        public virtual Categoria CategoriaPadreNavigation { get; set; }
        public virtual ICollection<Categoria> InverseCategoriaPadreNavigation { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }
    }
}
