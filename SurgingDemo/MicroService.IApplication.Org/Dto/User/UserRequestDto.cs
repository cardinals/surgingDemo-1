
using MicroService.Core;
using MicroService.Data.Common;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroService.IApplication.Org.Dto
{
    [ProtoContract]
    public class UserRequestDto : BaseDto
    {
        private LoginUser _loginUser;

        [ProtoMember(1)]

        public string RoleId { set; get; }

        [ProtoMember(2)]

        public string Name { set; get; }
        [ProtoMember(3)]
        public string Password { set; get; }

        [ProtoMember(4)]
        public string PhoneCode { set; get; }

        public LoginUser LoginUser
        {
            get
            {
                return _loginUser;
            }

            set
            {
                _loginUser = Newtonsoft.Json.JsonConvert.DeserializeObject<LoginUser>(this.Payload);
            }
        }
    }
}
