using ShopOnline.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Areas.Admin.Patern.Facade.M
{
    public class EmployeeFacade
    {

        menfashionEntities db = DatabaseContext.Instance.GetDbContext();
        public void CreateMember(Member member, HttpPostedFileBase uploadFile)
        {
            var username = member.userName.Trim();
            var check = db.Members.SingleOrDefault(model => model.userName == username);

            if (check != null)
            {
                throw new Exception("Username already exists");
            }

            string fileName = Path.GetFileName(uploadFile.FileName);
            string path = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/img/avatar"), fileName);
            string extension = Path.GetExtension(uploadFile.FileName);

            if (extension.ToLower() != ".jpg" && extension.ToLower() != ".jpeg" && extension.ToLower() != ".png")
            {
                throw new Exception("Invalid File Type");
            }

            member.firstName = member.firstName.Trim();
            member.lastName = member.lastName.Trim();
            member.email = member.email.Trim();
            member.address = member.address.Trim();
            member.phone = member.phone.Trim();
            member.identityNumber = member.identityNumber.Trim();
            member.avatar = "~/Content/img/avatar/" + fileName;
            member.dateOfJoin = DateTime.Now;
            member.status = true;
            member.password = Encryptor.MD5Hash(member.password);

            db.Members.Add(member);
            db.SaveChanges();

            uploadFile.SaveAs(path);
        }


        public bool CanDeleteMember(string userName)
        {
            var member = db.Members.Find(userName);
            if (member == null)
                throw new ArgumentException("Member not found", nameof(userName));

            var checkArticle = db.Articles.FirstOrDefault(model => model.userName == userName);
            var checkInvoice = db.Invoinces.FirstOrDefault(model => model.userName == userName);
            var checkProduct = db.Products.FirstOrDefault(model => model.userName == userName);

            return checkArticle == null && checkInvoice == null && checkProduct == null;
        }

        public void DeleteMember(string userName)
        {
            var member = db.Members.Find(userName);
            if (member == null)
                throw new ArgumentException("Member not found", nameof(userName));

            db.Members.Remove(member);
            db.SaveChanges();
        }

        public void DeleteMemberAndAvatar(string userName, string avatarPath)
        {
            DeleteMember(userName);

            // Delete avatar file if it exists
            string avatarFullPath = HttpContext.Current.Server.MapPath(avatarPath);
            if (File.Exists(avatarFullPath))
            {
                File.Delete(avatarFullPath);
            }
        }






    }
}