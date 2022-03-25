using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace apiMF.Models
{
    public partial class PostDbContext : DbContext
    {
    
        public PostDbContext(DbContextOptions options): base(options)
        {
        }

        public virtual DbSet<Categoriaconsumible> Categoriaconsumibles { get; set; }
        public virtual DbSet<Categoriaherramienta> Categoriaherramienta { get; set; }
        public virtual DbSet<Categoriamateriaprima> Categoriamateriaprimas { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Consumible> Consumibles { get; set; }
        public virtual DbSet<Herramientum> Herramienta { get; set; }
        public virtual DbSet<Materiaprima> Materiaprimas { get; set; }
        public virtual DbSet<Productoterminado> Productoterminados { get; set; }
        public virtual DbSet<Tipousuario> Tipousuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;database=madifain;uid=root;pwd=jesus140999", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.26-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            modelBuilder.Entity<Categoriaconsumible>(entity =>
            {
                entity.HasKey(e => e.IdCategoriaConsumibles)
                    .HasName("PRIMARY");

                entity.ToTable("categoriaconsumibles");

                entity.Property(e => e.IdCategoriaConsumibles)
                    .ValueGeneratedNever()
                    .HasColumnName("idCategoriaConsumibles");

                entity.Property(e => e.Descripcion).HasMaxLength(45);

                entity.Property(e => e.NombreCategoriaConsumibles)
                    .IsRequired()
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Categoriaherramienta>(entity =>
            {
                entity.HasKey(e => e.IdCategoriaHerramienta)
                    .HasName("PRIMARY");

                entity.ToTable("categoriaherramienta");

                entity.Property(e => e.IdCategoriaHerramienta)
                    .ValueGeneratedNever()
                    .HasColumnName("idCategoriaHerramienta");

                entity.Property(e => e.Descripcion).HasMaxLength(45);

                entity.Property(e => e.NombreCategoriaHerramienta)
                    .IsRequired()
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Categoriamateriaprima>(entity =>
            {
                entity.HasKey(e => e.IdCategoriaMateriaPrima)
                    .HasName("PRIMARY");

                entity.ToTable("categoriamateriaprima");

                entity.Property(e => e.IdCategoriaMateriaPrima)
                    .ValueGeneratedNever()
                    .HasColumnName("idCategoriaMateriaPrima");

                entity.Property(e => e.Descripcion).HasMaxLength(50);

                entity.Property(e => e.NombreCategoriaMateriaPrima)
                    .IsRequired()
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PRIMARY");

                entity.ToTable("cliente");

                entity.Property(e => e.IdCliente)
                    .ValueGeneratedNever()
                    .HasColumnName("idCliente");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("correo");

                entity.Property(e => e.NombreCliente)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Telefono).HasMaxLength(10);
            });

            modelBuilder.Entity<Consumible>(entity =>
            {
                entity.HasKey(e => e.IdConsumible)
                    .HasName("PRIMARY");

                entity.ToTable("consumible");

                entity.Property(e => e.IdConsumible)
                    .ValueGeneratedNever()
                    .HasColumnName("idConsumible");

                entity.Property(e => e.ClaveConsumible)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DescripcionConsumible).HasMaxLength(45);

                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.Property(e => e.IdCategoriaConsumible).HasColumnName("idCategoriaConsumible");

                entity.Property(e => e.Imagen).HasMaxLength(500);

                entity.Property(e => e.NombreConsumible)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.UnidadMedida).HasPrecision(10);
            });

            modelBuilder.Entity<Herramientum>(entity =>
            {
                entity.HasKey(e => e.IdHerramienta)
                    .HasName("PRIMARY");

                entity.ToTable("herramienta");

                entity.Property(e => e.IdHerramienta)
                    .ValueGeneratedNever()
                    .HasColumnName("idHerramienta");

                entity.Property(e => e.ClaveHerramienta)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.DescripcionHerramienta).HasMaxLength(45);

                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.Property(e => e.IdCategoriaHerramienta).HasColumnName("idCategoriaHerramienta");

                entity.Property(e => e.Imagen).HasMaxLength(500);

                entity.Property(e => e.NombreHerramienta)
                    .IsRequired()
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Materiaprima>(entity =>
            {
                entity.HasKey(e => e.IdMateriaPrima)
                    .HasName("PRIMARY");

                entity.ToTable("materiaprima");

                entity.Property(e => e.IdMateriaPrima)
                    .ValueGeneratedNever()
                    .HasColumnName("idMateriaPrima");

                entity.Property(e => e.ClaveMateriaPrima)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.DescripcionMateriaPrima).HasMaxLength(45);

                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.Property(e => e.IdCategoriaMateriaPrima).HasColumnName("idCategoriaMateriaPrima");

                entity.Property(e => e.NombreMateriaPrima)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.UnidadMedida).HasPrecision(10);
            });

            modelBuilder.Entity<Productoterminado>(entity =>
            {
                entity.HasKey(e => e.IdProductoTerminado)
                    .HasName("PRIMARY");

                entity.ToTable("productoterminado");

                entity.Property(e => e.IdProductoTerminado)
                    .ValueGeneratedNever()
                    .HasColumnName("idProductoTerminado");

                entity.Property(e => e.DescripcionProductoTerminado).HasMaxLength(45);

                entity.Property(e => e.Empresa)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.FechaLlegada).HasColumnType("datetime");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.NombreProductoTerminado)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("status");
            });

            modelBuilder.Entity<Tipousuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PRIMARY");

                entity.ToTable("tipousuario");

                entity.Property(e => e.IdTipoUsuario)
                    .ValueGeneratedNever()
                    .HasColumnName("idTipoUsuario");

                entity.Property(e => e.TipoUsuario1)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("TipoUsuario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuarios)
                    .HasName("PRIMARY");

                entity.ToTable("usuarios");

                entity.Property(e => e.IdUsuarios)
                    .ValueGeneratedNever()
                    .HasColumnName("idUsuarios");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("correo");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("nombre");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("password");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
