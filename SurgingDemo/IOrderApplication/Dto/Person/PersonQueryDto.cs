using LZN.Core;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace IOrderApplication.Dto
{
    [ProtoContract]
    [Serializable]
    public class PersonQueryDto : BaseDto
    {

        [ProtoMember(1)]

        public string RoleId { set; get; }
        [ProtoMember(2)]

        public string Name { set; get; }


        [ProtoMember(3)]
        public string PhoneCode { set; get; }


    }
}
