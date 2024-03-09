using ShopOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopOnline.Areas.Admin.Patern.Proxy
{
    public class MemberService : IMemberService
    {
        private menfashionEntities db = DatabaseContext.Instance.GetDbContext();

        public bool IsUsernameExist(string username)
        {
            var check = db.Members.Any(model => model.userName == username);
            return check;
        }

        public void RegisterMember(Member member)
        {
            member.password = Encryptor.MD5Hash(member.password);
            member.dateOfJoin = DateTime.Now;
            member.roleId = 3;
            member.avatar = "~/Content/img/avatar/avatar.jpg";
            member.status = true;

            db.Members.Add(member);
            db.SaveChanges();
        }
    }
}