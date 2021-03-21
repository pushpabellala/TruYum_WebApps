namespace TruYum_WebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cart")]
    public partial class Cart
    {
        [Key]
        public int Id { get; set; }
        public int MenuItemId { get; set; }

        public int Quantity { get; set; }

        public int? UserId { get; set; }

        public virtual MenuItem MenuItem { get; set; }

        public virtual User User { get; set; }
    }
}
