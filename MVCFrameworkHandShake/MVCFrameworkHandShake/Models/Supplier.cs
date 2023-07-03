using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace MVCFrameworkHandShake.Models
{
    
    public class ToSelect
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public partial class Supplier
    {
        [Key]
        [Column("SupplierID")]
        public int SupplierId { get; set; }

        [Required]
        [StringLength(40)]
        [Index("CompanyName")]
        public string CompanyName { get; set; }

        [StringLength(30)]
        public string ContactName { get; set; }

        [StringLength(30)]
        public string ContactTitle { get; set; }

        [StringLength(60)]
        public string Address { get; set; }

        [StringLength(15)]
        public string City { get; set; }

        [StringLength(15)]
        public string Region { get; set; }

        [StringLength(10)]
        [Index("PostalCode")]
        public string PostalCode { get; set; }

        [StringLength(15)]
        public string Country { get; set; }

        [StringLength(24)]
        public string Phone { get; set; }

        [StringLength(24)]
        public string Fax { get; set; }

        [Column(TypeName = "ntext")]
        public string HomePage { get; set; }

        [InverseProperty("Supplier")]
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}