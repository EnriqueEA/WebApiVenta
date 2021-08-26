using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiVentas.Core.Models
{
    public partial class Producto
    {
        public Producto()
        {
            DetallePedidos = new HashSet<DetallePedido>();
            Imagens = new HashSet<Imagen>();
        }

        public int ProductoId { get; set; }
        public int CategoriaId { get; set; }
        public int MarcaId { get; set; }
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public string Modelo { get; set; }
        public int Stock { get; set; }
        public double Precio { get; set; }

        public virtual Categoria Categoria { get; set; }
        public virtual Marca Marca { get; set; }
        public virtual ICollection<DetallePedido> DetallePedidos { get; set; }
        public virtual ICollection<Imagen> Imagens { get; set; }
    }
}
