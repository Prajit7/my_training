using SampleLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLib
{
    public interface IProductDB
    {
        void AddProduct(PRODUCTSDB product);
        void UpdateProduct(PRODUCTSDB product);
        void DeleteProduct(int id);
        List<PRODUCTSDB> GetAllProducts();
    }

    public static class ProductFactory
    {
        public static IProductDB GetComponent() => new ProductNew();
    }
    class ProductNew : IProductDB
    {
        static ProductDb context = new ProductDb();
        public void AddProduct(PRODUCTSDB product)
        {
            context.PRODUCTSDBs.Add(product);
            context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var found = context.PRODUCTSDBs.First((p) => p.PRODUCTID == id);
            context.PRODUCTSDBs.Remove(found);
            context.SaveChanges();

        }

        public List<PRODUCTSDB> GetAllProducts() => context.PRODUCTSDBs.ToList();

        public void UpdateProduct(PRODUCTSDB product)
        {
            var found = context.PRODUCTSDBs.First((p) => p.PRODUCTID == product.PRODUCTID);
            found.IMAGE = product.IMAGE;
            found.PRODUCTNAME = product.PRODUCTNAME;
            found.PRICE = product.PRICE;
            found.QUANTITY = product.QUANTITY;
            context.SaveChanges();

        }
    }

}
