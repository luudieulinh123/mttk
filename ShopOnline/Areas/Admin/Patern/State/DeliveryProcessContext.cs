using ShopOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopOnline.Areas.Admin.Patern.State
{
    public class DeliveryProcessContext
    {
        private IDeliveryState currentState;

        public DeliveryProcessContext()
        {
            currentState = new PendingDeliveryState(); // Khởi tạo với trạng thái ban đầu
        }

        public void SetState(IDeliveryState state)
        {
            currentState = state;
        }
        public void Deliver(Invoince invoice)
        {
            currentState.HandleDelivery(invoice);
        }
    }
}