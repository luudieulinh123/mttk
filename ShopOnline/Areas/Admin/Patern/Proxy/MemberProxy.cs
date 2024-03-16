using ShopOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopOnline.Areas.Admin.Patern.Proxy
{
    public class MemberProxy
    {
        private IMemberService memberService = new MemberService();

        public bool IsUsernameExist(string username)
        {
           
            return memberService.IsUsernameExist(username);
        }

        public void RegisterMember(Member member)
        {
            
            if (member == null)
            {
                throw new ArgumentNullException(nameof(member));
            }

            if (string.IsNullOrWhiteSpace(member.userName))
            {
                throw new ArgumentException("Username cannot be empty.", nameof(member.userName));
            }

            if (string.IsNullOrWhiteSpace(member.password))
            {
                throw new ArgumentException("Password cannot be empty.", nameof(member.password));
            }

            if (string.IsNullOrWhiteSpace(member.email))
            {
                throw new ArgumentException("Email cannot be empty.", nameof(member.email));
            }
            this.memberService.RegisterMember(member);
        }
    }
}