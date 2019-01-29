
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
    public class OrderInfoRequestDto : LoginUser
    {

        /// <summary>
        /// 订单号
        /// </summary>

        public string OrderNumber { set; get; }

        /// <summary>
        /// 总金额
        /// </summary>


        public decimal TotalMoney { set; get; }

      

       // public string UserId { set; get; }

        /// <summary>
        /// 订单状态
        /// </summary>

        public OrderStatus Status { set; get; }


        /// <summary>
        /// 订单过期时间
        /// </summary>

        public DateTime ExpireTime { set; get; }


    }
}
