using ShopOnline.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;

namespace ShopOnline.Areas.Admin.Patern.Strategy.Edit_blog
{

  


    public class WithUploadFileEditStrategy : IEditStrategy
    {

        menfashionEntities db = DatabaseContext.Instance.GetDbContext();
     

        public void Edit(Article article, HttpPostedFileBase uploadFile, string contentTemp, string imgPath)
        {
            var fileName = Path.GetFileName(uploadFile.FileName);
            var path = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/img/blog"), fileName);

            article.image = "~/Content/img/blog/" + fileName;
            article.content = contentTemp;
           db.Entry(article).State = EntityState.Modified;

            string oldImgPath = HttpContext.Current.Request.MapPath(imgPath);
            if (db.SaveChanges() > 0)
            {
                //TempData["msgEdit"] = "Successfully edited product has ID: " + article.articleId;
                uploadFile.SaveAs(path);
                if (System.IO.File.Exists(oldImgPath))
                {
                    System.IO.File.Delete(oldImgPath);
                }
            }
        }
    }
}