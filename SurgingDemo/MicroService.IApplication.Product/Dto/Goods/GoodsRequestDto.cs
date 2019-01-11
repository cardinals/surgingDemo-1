
using MicroService.Core;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroService.IApplication.Product.Dto
{
    [ProtoContract]
    [Serializable]
    public class GoodsRequestDto : BaseDto
    {
        
        [ProtoMember(2)]

        public string Name { set; get; }

        


    }
}
