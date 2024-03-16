using ShopOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ShopOnline.Areas.Admin.Patern.Strategy.Edit_blog
{
    public interface IEditStrategy
    {
        void Edit(Article article, HttpPostedFileBase uploadFile, string contentTemp, string imgPath);
    }
}
