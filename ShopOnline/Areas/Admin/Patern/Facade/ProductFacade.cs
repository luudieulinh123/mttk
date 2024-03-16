using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using ShopOnline.Models;
namespace ShopOnline.Areas.Admin.Patern.Facade
{
    public class ProductFacade
    {
        private menfashionEntities db = DatabaseContext.Instance.GetDbContext();

        public bool CanDeleteProduct(int? productId)
        {
            var checkInvoice = db.InvoinceDetails.FirstOrDefault(model => model.productId == productId);
            return checkInvoice != null;
        }

        public void DeleteProduct(int? productId)
        {
            Product product = db.Products.Find(productId);
            string currentImg = Path.GetFullPath(product.image);

            if (File.Exists(currentImg))
            {
                File.Delete(currentImg);
            }

            db.Products.Remove(product);
            db.SaveChanges();
        }
      





    }
}