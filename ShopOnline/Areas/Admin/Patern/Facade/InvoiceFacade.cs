
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
using Rotativa;

namespace ShopOnline.Areas.Admin.Patern.Facade
{
    public class InvoiceFacade
    {
         menfashionEntities db = DatabaseContext.Instance.GetDbContext();
        public bool DeleteInvoice(string id)
        {
            try
            {
                // Xóa các chi tiết hóa đơn
                List<InvoinceDetail> invoiceDetails = db.InvoinceDetails.Where(model => model.invoinceNo == id).ToList();
                foreach (var detail in invoiceDetails)
                {
                    db.InvoinceDetails.Remove(detail);
                }

                // Xóa hóa đơn
                Invoince invoice = db.Invoinces.Find(id);
                if (invoice != null)
                {
                   db.Invoinces.Remove(invoice);
                    db.SaveChanges();
                    return true; // Xóa thành công
                }
                return false; // Không tìm thấy hóa đơn
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ, có thể ghi log hoặc thông báo lỗi
                return false; // Xóa không thành công
            }
        }

    }
}