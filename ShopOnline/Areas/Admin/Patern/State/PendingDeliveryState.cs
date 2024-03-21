using ShopOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopOnline.Areas.Admin.Patern.State
{
    public class PendingDeliveryState : IDeliveryState
    {
        public void HandleDelivery(Invoince invoice)
        {
            // Xử lý khi giao hàng đang chờ
            invoice.deliveryDate = DateTime.Now;
            invoice.deliveryStatus = true;
        }
    }
}