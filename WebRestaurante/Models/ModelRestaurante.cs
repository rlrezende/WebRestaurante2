namespace WebRestaurante.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelRestaurante : DbContext
    {
        public ModelRestaurante()
            : base("name=ModelRestaurante")
        {
        }

        public virtual DbSet<Pratos> Pratos { get; set; }
        public virtual DbSet<Restaurantes> Restaurantes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pratos>()
                .Property(e => e.Nome)
                .IsFixedLength();

            modelBuilder.Entity<Pratos>()
                .Property(e => e.Preco)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Restaurantes>()
                .Property(e => e.Nome)
                .IsFixedLength();

            modelBuilder.Entity<Restaurantes>()
                .HasMany(e => e.Pratos)
                .WithRequired(e => e.Restaurantes)
                .WillCascadeOnDelete(false);
        }
    }
}
