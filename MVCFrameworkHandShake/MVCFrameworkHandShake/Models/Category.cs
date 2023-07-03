using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace MVCFrameworkHandShake.Models
{
    public partial class Category
    {
        [Key]
        [Column("CategoryID")]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(15)]
        [Index("CategoryName")]
        public string CategoryName { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        [Column(TypeName = "image")]
        public byte[] Picture { get; set; }

        [InverseProperty("Category")]
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}