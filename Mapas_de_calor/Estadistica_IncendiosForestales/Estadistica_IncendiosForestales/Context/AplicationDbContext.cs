using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Estadistica_IncendiosForestales.Model;

namespace Estadistica_IncendiosForestales.Context
{
    public partial class AplicationDbContext : DbContext
    {
        public AplicationDbContext()
        {
        }

        public AplicationDbContext(DbContextOptions<AplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Incendios> Incendios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=Estadistica_IncendiosForestales;Persist Security Info=True;User ID=sa;Password=19244rojasR", x => x.UseNetTopologySuite());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Incendios>(entity =>
            {
                entity.Property(e => e.Comuna).HasMaxLength(100);

                entity.Property(e => e.Fecha_Fin).HasColumnType("datetime");

                entity.Property(e => e.Fecha_Inicio).HasColumnType("datetime");

                entity.Property(e => e.Provincia).HasMaxLength(100);

                entity.Property(e => e.Region).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
