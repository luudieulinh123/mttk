using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopOnline.Areas.Admin.Patern.Builder
{
    public class DeliveryMessageBuilder
    {
        private string deliveryMessage;

        public void BuildDeliveryMessage(string invoiceNo)
        {
            deliveryMessage = "Order ID " + invoiceNo + " has been successfully delivered ";
        }

        public string GetDeliveryMessage()
        {
            return deliveryMessage;
        }
    }
}