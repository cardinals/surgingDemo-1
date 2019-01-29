using MicroService.Core;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroService.IApplication.Product.Dto
{
    [ProtoContract]
    [Serializable]
    public class GoodsQueryDto : BaseDto
    {

    
        [ProtoMember(2)]

        public string Name { set; get; }

        


    }
}
