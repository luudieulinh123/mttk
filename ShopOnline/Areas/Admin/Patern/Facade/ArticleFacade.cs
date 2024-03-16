using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShopOnline.Models;
using System.IO;
using PagedList;
using PagedList.Mvc;

namespace ShopOnline.Areas.Admin.Patern.Facade
{
    public class ArticleFacade
    {
        private menfashionEntities db = DatabaseContext.Instance.GetDbContext();
        public bool DeleteArticle(int? id)
        {
            try
            {
                Article article = db.Articles.Find(id);
                if (article == null)
                {
                    return false; // Article not found
                }

                string currentImg = HttpContext.Current.Server.MapPath(article.image);
                if (System.IO.File.Exists(currentImg))
                {
                    System.IO.File.Delete(currentImg);
                }

                db.Articles.Remove(article);
                db.SaveChanges();

                return true; // Article successfully deleted
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return false; // Deletion failed
            }
        }

    }
}