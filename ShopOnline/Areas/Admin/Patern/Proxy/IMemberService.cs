using ShopOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Areas.Admin.Patern.Proxy
{
   public  interface IMemberService
    {
        bool IsUsernameExist(string username);
        void RegisterMember(Member member);
    }
}
