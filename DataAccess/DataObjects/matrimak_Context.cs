using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace weddingWebapp.DataAccess.DataObjects
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

        public virtual DbSet<Regalo> Regalos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=weddingdev;password=securepassword.123;database=matrimak_");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Regalo>(entity =>
            {
                entity.HasKey(e => e.Idregalo)
                    .HasName("PRIMARY");

                entity.ToTable("regalos");

                entity.Property(e => e.Idregalo).HasColumnName("idregalo");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("correo");

                entity.Property(e => e.Monto).HasColumnName("monto");

                entity.Property(e => e.NombreRegalo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("nombreRegalo");

                entity.Property(e => e.NombreUsuario)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("nombreUsuario");

                entity.Property(e => e.Notaregalo)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("notaregalo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
