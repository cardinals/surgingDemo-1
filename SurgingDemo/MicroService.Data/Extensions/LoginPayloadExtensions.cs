using MicroService.Data.Common;
using Surging.Core.CPlatform;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroService.Data.Extensions
{
   public static class LoginPayloadExtensions
    {

        public static  void ToLoginUser(this LoginUser loginUser)
        {
            var token = loginUser.Payload.Replace("\\", "").Trim('"');
            var login = Newtonsoft.Json.JsonConvert.DeserializeObject<LoginUser>(token);
            loginUser.UserId = login.UserId;
            loginUser.RoleId = login.RoleId;
            loginUser.Name = login.Name;

        }
    }
}
