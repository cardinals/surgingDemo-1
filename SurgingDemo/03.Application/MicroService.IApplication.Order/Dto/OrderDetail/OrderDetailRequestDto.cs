
using MicroService.Core;
using MicroService.Data.Common;
using MicroService.Data.Enums;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroService.IApplication.Order.Dto
{
    [ProtoContract]
    [Serializable]
    public class OrderDetailRequestDto : LoginUser
    {

        /// <summary>
        /// 订单id
        /// </summary>

            
        public string OrderId { set; get; }

        /// <summary>
        /// 商品名称
        /// </summary>
      
        public string GoodsId { set; get; }

        /// <summary>
        /// 单价
        /// </summary>
     
        public decimal Price { set; get; }

        /// <summary>
        /// 数量
        /// </summary>
      
        public int Count { set; get; }

        /// <summary>
        /// 小计
        /// </summary>
    
        public decimal Money { set; get; }


    }
}
