namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public int UnitCost { get; set; }

        public int Quantity { get; set; }

        [StringLength(100)]
        public string Image { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        public int ID_Category { get; set; }

        public virtual Category Category { get; set; }
    }
}
