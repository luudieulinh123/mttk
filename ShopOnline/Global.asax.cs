using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using CaptchaMvc.Infrastructure;
using CaptchaMvc.Interface;
using CaptchaMvc.Models;
using System.Web.Optimization;
using ShopOnline.App_Start;
using ShopOnline.Areas.Admin.Patern;
using ShopOnline.Areas.Admin.Patern.Strategy;
using Unity;
using Unity.AspNet.Mvc;


namespace ShopOnline
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var container = new UnityContainer();

            // Đăng ký các interface và implementation
            container.RegisterType<IEmailSendingStrategy, GmailEmailSendingStrategy>();
           
            // Thiết lập UnityDependencyResolver
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            var captchaManager = (DefaultCaptchaManager)CaptchaUtils.CaptchaManager;
            captchaManager.CharactersFactory = () => "my characters";
            captchaManager.PlainCaptchaPairFactory = length =>
            {
                string randomText = RandomText.Generate(captchaManager.CharactersFactory(), length);
                bool ignoreCase = false;
                return new KeyValuePair<string, ICaptchaValue>(Guid.NewGuid().ToString("N"),
                        new StringCaptchaValue(randomText, randomText, ignoreCase));
            };
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Application["SoNguoiTruyCap"] = 0; // Đếm số lượt người đã truy cập vào website
            Application["SoNguoiDangOnline"] = 0; // Đếm số người hiện đang online

        }
        protected void Session_Start()
        {
            Application.Lock(); // Dùng để xử lí tuần tự
            Application["SoNguoiTruyCap"] = (int)Application["SoNguoiTruyCap"] + 1;
            Application["SoNguoiDangOnline"] = (int)Application["SoNguoiDangOnline"] + 1;
            Application.UnLock();
        }
        protected void Session_End()
        {
            Application.Lock(); // Dùng để đồng bộ hóa
            Application["SoNguoiDangOnline"] = (int)Application["SoNguoiDangOnline"] - 1;
            Application.UnLock();
        }
    }
}
