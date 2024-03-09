using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Areas.Admin.Patern.Builder
{
    interface IDeliveryMessageBuilder
    {
        void BuildDeliveryMessage(string invoiceNo);

        string GetDeliveryMessage();
    }
}
