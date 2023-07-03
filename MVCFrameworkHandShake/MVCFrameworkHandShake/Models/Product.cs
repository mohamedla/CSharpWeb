using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace MVCFrameworkHandShake.Models
{
    public partial class Product
    {
        [Key]
        [Column("ProductID")]
        public int ProductId { get; set; }

        [Required]
        [StringLength(40)]
        [Index("ProductName")]
        public string ProductName { get; set; }

        [Column("SupplierID")]
        public int? SupplierId { get; set; }

        [Column("CategoryID")]
        public int? CategoryId { get; set; }

        [StringLength(20)]
        public string QuantityPerUnit { get; set; }

        [Column(TypeName = "money")]
        public decimal? UnitPrice { get; set; }

        public short? UnitsInStock { get; set; }

        public short? UnitsOnOrder { get; set; }

        public short? ReorderLevel { get; set; }

        public bool Discontinued { get; set; }

        [ForeignKey("CategoryId")]
        [InverseProperty("Products")]
        [Index("CategoriesProducts")]
        [Index("CategoryID")]
        public virtual Category Category { get; set; }

        [ForeignKey("SupplierId")]
        [InverseProperty("Products")]
        [Index("SupplierID")]
        [Index("SuppliersProducts")]
        public virtual Supplier Supplier { get; set; }
    }
}