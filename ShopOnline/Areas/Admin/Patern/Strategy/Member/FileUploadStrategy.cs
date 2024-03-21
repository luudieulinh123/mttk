using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ShopOnline.Areas.Admin.Patern.Strategy.Member
{
    public class FileUploadStrategy : IUploadStrategy
    {
        public void UploadFile(HttpPostedFileBase uploadFile, string destinationPath)
        {
            if (uploadFile != null)
            {
                var fileName = Path.GetFileName(uploadFile.FileName);
                var path = Path.Combine(destinationPath, fileName);
                uploadFile.SaveAs(path);
            }
        }
    }
}