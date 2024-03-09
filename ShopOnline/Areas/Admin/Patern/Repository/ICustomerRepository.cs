using System;
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
using System.Web.Security;
using ShopOnline.Areas.Admin.Patern.Repository;

namespace ShopOnline.Areas.Admin.Patern.Repository
{
    public interface ICustomerRepository
    {
       
        void DeleteCustomer(int customerId);
    }

}
