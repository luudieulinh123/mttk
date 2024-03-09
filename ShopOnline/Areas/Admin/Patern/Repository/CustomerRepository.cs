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

namespace ShopOnline.Areas.Admin.Patern.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        menfashionEntities db = DatabaseContext.Instance.GetDbContext();


        public void DeleteCustomer(int customerId)
        {
            try
            {
                Customer customer = (from i in db.Customers
                                     select i).SingleOrDefault(model => model.customerId == customerId);
                if (customer != null)
                {
                    db.Customers.Remove(customer);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Customer not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete customer: " + ex.Message);
            }
        }
    }

}