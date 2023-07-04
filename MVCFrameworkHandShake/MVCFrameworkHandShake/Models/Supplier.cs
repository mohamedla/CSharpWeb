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
        [StringLength(40,ErrorMessage = "Company Name Must be Less Then 40 Chars")]
        [Index("CompanyName")]
        public string CompanyName { get; set; }

        [StringLength(30, ErrorMessage = "Contact Name Must be Less Then 30 Chars")]
        public string ContactName { get; set; }

        [StringLength(30, ErrorMessage = "Contact Title Must be Less Then 30 Chars")]
        public string ContactTitle { get; set; }

        [StringLength(60, ErrorMessage = "Contact Address Must be Less Then 60 Chars")]
        public string Address { get; set; }

        [StringLength(15, ErrorMessage = "City Must be Less Then 15 Chars")]
        public string City { get; set; }

        [StringLength(15, ErrorMessage = "Region Must be Less Then 15 Chars")]
        public string Region { get; set; }

        [StringLength(10, ErrorMessage = "Postal Code Must be Less Then 10 Chars")]
        [Index("PostalCode")]
        public string PostalCode { get; set; }

        [StringLength(15, ErrorMessage = "Country Must be Less Then 15 Chars")]
        public string Country { get; set; }

        [StringLength(24, ErrorMessage = "Phone Must be Less Then 24 Chars")]
        public string Phone { get; set; }

        [StringLength(24, ErrorMessage = "Fax Must be Less Then 24 Chars")]
        public string Fax { get; set; }

        [Column(TypeName = "ntext")]
        public string HomePage { get; set; }

        [InverseProperty("Supplier")]
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}