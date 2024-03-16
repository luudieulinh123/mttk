using ShopOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopOnline.Areas.Admin.Patern.Facade
{
    public class ProductCategoryFacade
    {
        menfashionEntities db = DatabaseContext.Instance.GetDbContext();
        public bool AddCategory(string categoryName)
        {
            try
            {
                var category = new ProductCategory();
                category.categoryName = categoryName;

                db.ProductCategories.Add(category);
                db.SaveChanges();

                return true; // Thêm danh mục thành công
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ, có thể ghi log hoặc thông báo lỗi
                return false; // Thêm danh mục không thành công
            }
        }











    }
}