using Products.Models;
using Dapper;
using System.Data.Common;
using Products.Context;
using Microsoft.EntityFrameworkCore;

namespace Products.Managers
{
    public class ProductManager : IManager<Product>
    {
        DbConnection connection;

        public ProductManager(NorthwindContext context)
            => connection = context.Database.GetDbConnection();

        public bool Add(Product item)
        {
            try
            {
                return connection.Execute("INSERT INTO Products (ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued) VALUES (@ProductName,@SupplierID,@CategoryID,@QuantityPerUnit,@UnitPrice,@UnitsInStock,@UnitsOnOrder,@ReorderLevel,@Discontinued)", item) > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteByID(int id)
            => connection.Execute("Delete From Products Where  ProductID = @ProductID", new { ProductID = id }) > 0;

        public List<Product> GetAll()
            => connection.Query<Product>("SelectAllProducts", commandType: System.Data.CommandType.StoredProcedure).ToList()?? new List<Product>();

        public Product GetByID(int id)
            => connection.QueryFirstOrDefault<Product>("Select * From Products Where  ProductID = @ProductID", new { ProductID = id })?? new ();

        public bool Update(Product item)
        {
            try
            {
                return connection.Execute("Update Products Set ProductName = @ProductName, SupplierID = @SupplierID, CategoryID = @CategoryID, QuantityPerUnit = @QuantityPerUnit, UnitPrice = @UnitPrice, UnitsInStock = @UnitsInStock, UnitsOnOrder = @UnitsOnOrder, ReorderLevel = @ReorderLevel, Discontinued = @Discontinued Where  ProductID = @ProductID", item) > 0;
            }
            catch
            {
                return false;
            }
        }

    }
}
