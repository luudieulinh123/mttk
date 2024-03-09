using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Areas.Admin.Patern
{
    public interface IEmailSendingStrategy
    {
        bool SendEmail(string toEmail, string subject, string emailBody);
    }
}
