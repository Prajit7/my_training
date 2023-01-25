using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleWebApp.Models
{

    public static class ProductRepoDB
    {
        private static List<PRODUCTSDB> _repo = new List<PRODUCTSDB>();

        static ProductRepoDB()
        {
            getAll();
        }
        public static List<PRODUCTSDB> AllProduct => _repo;

        private static void getAll()
        {
            var context = new productsdbDataContext();
            _repo = context.PRODUCTSDBs.ToList();
        }
        public static void UpdateProduct(PRODUCTSDB product)
        {
            var context = new productsdbDataContext();
            var found = (from pd in context.PRODUCTSDBs
                         where pd.PRODUCTID == product.PRODUCTID
                         select pd).FirstOrDefault();
            found.PRODUCTID = product.PRODUCTID;
            found.PRODUCTNAME = product.PRODUCTNAME;
            found.PRICE = product.PRICE;

            context.SubmitChanges();
        }

        public static void DeleteProduct(int id)
        {
            var found = _repo.Find((p) => p.PRODUCTID == id);
            _repo.Remove(found);
        }
        public static void AddNewProduct(PRODUCTSDB product)
        {
            var context = new productsdbDataContext();

            context.PRODUCTSDBs.InsertOnSubmit(product);
            context.SubmitChanges();
        }
    }
}