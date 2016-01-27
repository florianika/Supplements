namespace SupplementApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProductIngredient
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdProduct { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdIngredient { get; set; }

        public int? Unit { get; set; }

        public float? Value { get; set; }

        public virtual Ingredient Ingredient { get; set; }

        public virtual Product Product { get; set; }

        public virtual Unit Unit1 { get; set; }
    }
}
