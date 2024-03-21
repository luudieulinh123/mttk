using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ShopOnline.Areas.Admin.Patern.Strategy.CreateBlog
{
    public interface IImageStrategy
    {
        string GetImagePath(string fileName);
    }
}
