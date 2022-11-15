using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace weddingWebapp.Models
{
    public partial class matrimak_Context : DbContext
    {
        public matrimak_Context()
        {
        }

        public matrimak_Context(DbContextOptions<matrimak_Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Ordenregalo> Ordenregalos { get; set; }
        public virtual DbSet<Regalo> Regalos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("Server=localhost; port=3306;Database=matrimak_;Uid=root;Pwd=1984;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ordenregalo>(entity =>
            {
                entity.HasKey(e => e.IdOrdenRegalo)
                    .HasName("PRIMARY");

                entity.ToTable("ordenregalo");

                entity.Property(e => e.IdOrdenRegalo)
                    .HasColumnName("idOrdenRegalo")
                    .HasComment("idoredn reglao");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("correo")
                    .HasComment("correo del pelagato");

                entity.Property(e => e.MontoRegalo)
                    .HasColumnName("montoRegalo")
                    .HasComment("monto total del regalo");

                entity.Property(e => e.Nota)
                    .HasMaxLength(300)
                    .HasColumnName("nota")
                    .HasComment("nota en el regalo");
            });

            modelBuilder.Entity<Regalo>(entity =>
            {
                entity.HasKey(e => e.IdRegalo)
                    .HasName("PRIMARY");

                entity.ToTable("regalo");

                entity.Property(e => e.IdRegalo)
                    .HasColumnName("idRegalo")
                    .HasComment("idregalo");

                entity.Property(e => e.CostoRegalo)
                    .HasColumnName("costoRegalo")
                    .HasComment("costo regalo");

                entity.Property(e => e.DescripcionRegalo)
                    .IsRequired()
                    .HasMaxLength(280)
                    .HasColumnName("descripcionRegalo")
                    .HasComment("descripcion del regalo");

                entity.Property(e => e.NombreRegalo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("nombreRegalo")
                    .HasComment("nombre del regalo");

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasColumnName("path")
                    .HasComment("imagepath");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
