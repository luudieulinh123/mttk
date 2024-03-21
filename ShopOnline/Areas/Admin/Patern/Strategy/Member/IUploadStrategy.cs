using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ShopOnline.Areas.Admin.Patern.Strategy.Member
{
    public interface IUploadStrategy
    {
        void UploadFile(HttpPostedFileBase uploadFile, string destinationPath);
    }
}
