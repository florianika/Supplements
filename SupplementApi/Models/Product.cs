namespace SupplementApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            PruductIngredients = new HashSet<ProductIngredient>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public int? Producer { get; set; }

        [StringLength(10)]
        public string TypeId { get; set; }

        [StringLength(10)]
        public string SupplementFormId { get; set; }

        [StringLength(10)]
        public string TargetGroupId { get; set; }

        [StringLength(5)]
        public string DietaryClaimId { get; set; }

        public virtual Producer Producer1 { get; set; }

        public virtual ProductType ProductType { get; set; }

        public virtual SupplementForm SupplementForm { get; set; }

        public virtual TargetGroup TargetGroup { get; set; }

        public virtual DietaryClaim DietaryClaim { get; set; }

        public int Priority { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductIngredient> PruductIngredients { get; set; }
    }
}
