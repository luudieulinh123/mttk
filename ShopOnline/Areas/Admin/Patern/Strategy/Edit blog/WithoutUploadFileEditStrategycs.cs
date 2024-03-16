using ShopOnline.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShopOnline.Areas.Admin.Patern.Strategy.Edit_blog
{
    public class WithoutUploadFileEditStrategycs
    {
        menfashionEntities db = DatabaseContext.Instance.GetDbContext();
        public void Edit(Article article, HttpPostedFileBase uploadFile, string contentTemp, string imgPath, IDictionary<string, object> tempData)
        {
            article.content = contentTemp;
            article.image = imgPath;
            db.Entry(article).State = EntityState.Modified;
            if (db.SaveChanges() > 0)
            {
                tempData["msgEdit"] = "Successfully edited product has ID: " + article.articleId;
            }
        }
    }
}