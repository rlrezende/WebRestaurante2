namespace WebRestaurante.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Pratos
    {
        [Key]
        public int Id_Prato { get; set; }

        [Required]
        [StringLength(75)]
        public string Nome { get; set; }

        [Column(TypeName = "money")]
        public decimal Preco { get; set; }

        public int id_Restaurante { get; set; }

        public virtual Restaurantes Restaurantes { get; set; }
    }
}
