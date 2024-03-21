using ShopOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Areas.Admin.Patern.State
{
    public interface IDeliveryState
    {
        void HandleDelivery(Invoince invoice);
    }
}
