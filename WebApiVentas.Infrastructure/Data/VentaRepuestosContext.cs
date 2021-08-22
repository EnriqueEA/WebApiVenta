using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebApiVentas.Core.Models;

#nullable disable

namespace WebApiVentas.Infrastructure.Data
{
    public partial class VentaRepuestosContext : DbContext
    {
        public VentaRepuestosContext()
        {
        }

        public VentaRepuestosContext(DbContextOptions<VentaRepuestosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Departamento> Departamentos { get; set; }
        public virtual DbSet<DetallePedido> DetallePedidos { get; set; }
        public virtual DbSet<Distrito> Distritos { get; set; }
        public virtual DbSet<HistorialPedido> HistorialPedidos { get; set; }
        public virtual DbSet<Imagen> Imagenes { get; set; }
        public virtual DbSet<LugarEntrega> LugarEntregas { get; set; }
        public virtual DbSet<Marca> Marcas { get; set; }
        public virtual DbSet<Pais> Pais { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Provincia> Provincias { get; set; }
        public virtual DbSet<Rol> Rols { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<UsuarioRol> UsuarioRols { get; set; }
        public virtual DbSet<Venta> Venta { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.CategoriaId)
                    .HasName("PK__categori__6378C0C059A417C0");

                entity.ToTable("categoria");

                entity.HasIndex(e => e.NombreCategoria, "UQ__categori__788BF0FA36FE25FE")
                    .IsUnique();

                entity.Property(e => e.CategoriaId).HasColumnName("categoriaId");

                entity.Property(e => e.CategoriaPadre).HasColumnName("categoriaPadre");

                entity.Property(e => e.NombreCategoria)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombreCategoria");

                entity.HasOne(d => d.CategoriaPadreNavigation)
                    .WithMany(p => p.InverseCategoriaPadreNavigation)
                    .HasForeignKey(d => d.CategoriaPadre)
                    .HasConstraintName("fk_categoria_categoriaPadre");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("cliente");

                entity.Property(e => e.ClienteId).HasColumnName("clienteId");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("apellidos");

                entity.Property(e => e.Celular)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("celular");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("nombres");
            });

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.ToTable("departamento");

                entity.Property(e => e.DepartamentoId).HasColumnName("departamentoId");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<DetallePedido>(entity =>
            {
                entity.ToTable("detallePedido");

                entity.Property(e => e.DetallePedidoId).HasColumnName("detallePedidoId");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.Descuento)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("descuento");

                entity.Property(e => e.PedidoId).HasColumnName("pedidoId");

                entity.Property(e => e.ProductoId).HasColumnName("productoId");

                entity.Property(e => e.Subtotal)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("subtotal");

                entity.HasOne(d => d.Pedido)
                    .WithMany(p => p.DetallePedidos)
                    .HasForeignKey(d => d.PedidoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_detalleP_pedido");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.DetallePedidos)
                    .HasForeignKey(d => d.ProductoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_detalleP_producto");
            });

            modelBuilder.Entity<Distrito>(entity =>
            {
                entity.ToTable("distrito");

                entity.Property(e => e.DistritoId).HasColumnName("distritoId");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.ProvinciaId).HasColumnName("provinciaId");

                entity.HasOne(d => d.Provincia)
                    .WithMany(p => p.Distritos)
                    .HasForeignKey(d => d.ProvinciaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_distrito_provincia");
            });

            modelBuilder.Entity<HistorialPedido>(entity =>
            {
                entity.ToTable("historialPedido");

                entity.Property(e => e.HistorialPedidoId).HasColumnName("historialPedidoId");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("estado");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.PedidoId).HasColumnName("pedidoId");

                entity.HasOne(d => d.Pedido)
                    .WithMany(p => p.HistorialPedidos)
                    .HasForeignKey(d => d.PedidoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_historialP_pedido");
            });

            modelBuilder.Entity<Imagen>(entity =>
            {
                entity.ToTable("imagen");

                entity.HasIndex(e => e.Url, "UQ__imagen__DD778417BB857943")
                    .IsUnique();

                entity.Property(e => e.ImagenId).HasColumnName("imagenId");

                entity.Property(e => e.ProductoId).HasColumnName("productoId");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("url");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.Imagens)
                    .HasForeignKey(d => d.ProductoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_imagen_producto");
            });

            modelBuilder.Entity<LugarEntrega>(entity =>
            {
                entity.ToTable("lugarEntrega");

                entity.Property(e => e.LugarEntregaId).HasColumnName("lugarEntregaId");

                entity.Property(e => e.DistritoId).HasColumnName("distritoId");

                entity.Property(e => e.PrecioEnvio)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("precioEnvio");

                entity.HasOne(d => d.Distrito)
                    .WithMany(p => p.LugarEntregas)
                    .HasForeignKey(d => d.DistritoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_lugarEntrega_distrito");
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.ToTable("marca");

                entity.Property(e => e.MarcaId).HasColumnName("marcaId");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.PaisId).HasColumnName("paisId");

                entity.HasOne(d => d.Pais)
                    .WithMany(p => p.Marcas)
                    .HasForeignKey(d => d.PaisId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_marca_pais");
            });

            modelBuilder.Entity<Pais>(entity =>
            {
                entity.HasKey(e => e.PaisId)
                    .HasName("PK__pais__45785B8BE3E89DD0");

                entity.ToTable("pais");

                entity.Property(e => e.PaisId).HasColumnName("paisId");

                entity.Property(e => e.Iso)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("iso");

                entity.Property(e => e.NombrePais)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("nombrePais");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.ToTable("pedido");

                entity.Property(e => e.PedidoId).HasColumnName("pedidoId");

                entity.Property(e => e.ClienteId).HasColumnName("clienteId");

                entity.Property(e => e.FechaEntrega)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaEntrega");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaRegistro");

                entity.Property(e => e.LugarEntregaId).HasColumnName("lugarEntregaId");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pedido_cliente");

                entity.HasOne(d => d.LugarEntrega)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.LugarEntregaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pedido_lugarEntrega");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("producto");

                entity.HasIndex(e => e.NombreProducto, "UQ__producto__A600056A317EB07C")
                    .IsUnique();

                entity.Property(e => e.ProductoId).HasColumnName("productoId");

                entity.Property(e => e.CategoriaId).HasColumnName("categoriaId");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(600)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.MarcaId).HasColumnName("marcaId");

                entity.Property(e => e.Modelo)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("modelo");

                entity.Property(e => e.NombreProducto)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("nombreProducto");

                entity.Property(e => e.Precio)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("precio");

                entity.Property(e => e.Stock).HasColumnName("stock");

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.CategoriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_producto_categoria");

                entity.HasOne(d => d.Marca)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.MarcaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_producto_marca");
            });

            modelBuilder.Entity<Provincia>(entity =>
            {
                entity.HasKey(e => e.ProvinciaId)
                    .HasName("PK__provinci__671F12A5CA308F96");

                entity.ToTable("provincia");

                entity.Property(e => e.ProvinciaId).HasColumnName("provinciaId");

                entity.Property(e => e.DepartamentoId).HasColumnName("departamentoId");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.Departamento)
                    .WithMany(p => p.Provincia)
                    .HasForeignKey(d => d.DepartamentoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_provincia_departamento");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.ToTable("rol");

                entity.Property(e => e.RolId).HasColumnName("rolId");

                entity.Property(e => e.NombreRol)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombreRol");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuario");

                entity.Property(e => e.UsuarioId).HasColumnName("usuarioId");

                entity.Property(e => e.Contrasena)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("contrasena");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaCreacion");

                entity.Property(e => e.NombreUsuario)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombreUsuario");

                entity.Property(e => e.RolId).HasColumnName("rolId");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.RolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_usuario_rol");
            });

            modelBuilder.Entity<UsuarioRol>(entity =>
            {
                entity.ToTable("usuarioRol");

                entity.Property(e => e.UsuarioRolId).HasColumnName("usuarioRolId");

                entity.Property(e => e.RolId).HasColumnName("rolId");

                entity.Property(e => e.UsuarioId).HasColumnName("usuarioId");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.UsuarioRols)
                    .HasForeignKey(d => d.RolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_usuarioRol_rol");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.UsuarioRols)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_usuarioRol_usuario");
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.HasKey(e => e.VentaId)
                    .HasName("PK__venta__40B8EB5448360BA7");

                entity.ToTable("venta");

                entity.Property(e => e.VentaId).HasColumnName("ventaId");

                entity.Property(e => e.FechaVenta)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaVenta");

                entity.Property(e => e.PedidoId).HasColumnName("pedidoId");

                entity.Property(e => e.Total)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("total");

                entity.HasOne(d => d.Pedido)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.PedidoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_venta_pedido");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
