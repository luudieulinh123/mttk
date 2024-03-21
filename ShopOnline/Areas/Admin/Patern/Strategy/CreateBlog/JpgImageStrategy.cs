using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ShopOnline.Areas.Admin.Patern.Strategy.CreateBlog
{
    public class JpgImageStrategy : IImageStrategy
    {
        public string GetImagePath(string fileName)
        {
            return "~/Content/img/blog/" + fileName;
        }
    }
}