using MicroService.Core;
using Surging.Core.CPlatform;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroService.Data.Common
{
    public class LoginUser: BaseDto
    {

        public string RoleId { set; get; }

        public string UserId { set; get; }

        public string Name { set; get; }

        public string Password { set; get; }

        public string PhoneCode{  set; get; }
    }
}
