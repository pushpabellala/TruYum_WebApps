namespace TruYum_WebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MenuItem")]
    public partial class MenuItem
    {
        
        public MenuItem()
        {
            Carts = new HashSet<Cart>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public bool Active { get; set; }
        [Required]
        [Display(Name="Price")]
        public decimal price { get; set; }
        [Display(Name = "Date of Launch")]
        [DataType(DataType.Date, ErrorMessage = "Date only")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? dateOfLaunch { get; set; }

        [Required]
        [StringLength(25)]
        [Display(Name = "Category")]
        public string category { get; set; }
        [Display(Name = "Free Delivery")]
        public bool freeDelivery { get; set; }

        
        public virtual ICollection<Cart> Carts { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}
