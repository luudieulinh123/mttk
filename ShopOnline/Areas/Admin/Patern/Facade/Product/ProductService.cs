using ShopOnline.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ShopOnline.Areas.Admin.Patern.Facade.Products
{
    public class ProductService
    {
        menfashionEntities db = DatabaseContext.Instance.GetDbContext();

        public void CreateProduct(Product product, HttpPostedFileBase uploadFile)
        {
            var productName = product.productName.Trim();
            var check = db.Products.SingleOrDefault(model => model.productName == productName);

            if (check != null)
            {
                throw new Exception("Product name already exists");
            }

            var fileName = Path.GetFileName(uploadFile.FileName);
            var path = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/img/product"), fileName);
            var extension = Path.GetExtension(uploadFile.FileName);

            if (!(extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".png"))
            {
                throw new Exception("Invalid File Type");
            }

            if (uploadFile == null)
            {
                throw new Exception("Error while file uploading.");
            }

            if (product.discount >= 100)
            {
                throw new Exception("Discount percent must be less than 100.");
            }

            product.productName = productName;
            product.brand = product.brand.Trim();
            product.image = "~/Content/img/product/" + fileName;
            product.userName = HttpContext.Current.Session["userNameAdmin"].ToString();
            product.dateCreate = DateTime.Now;
            product.status = true;

            db.Products.Add(product);
            db.SaveChanges();

            uploadFile.SaveAs(path);
        }

    }
}