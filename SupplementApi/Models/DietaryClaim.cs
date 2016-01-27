using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SupplementApi.Models
{
    [Table("DietaryClaim")]
    public class DietaryClaim
    {
        public DietaryClaim() 
        {
            Products = new HashSet<Product>();
        }
        [StringLength(5)]
        public string Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        internal virtual ICollection<Product> Products { get; set; }
    }
}