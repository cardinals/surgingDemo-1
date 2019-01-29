using MicroService.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MicroService.Entity.Order
{
    public class OrderDetail : Entity<string>
    {
        /// <summary>
        /// 订单id
        /// </summary>
        
        [Required]
        [StringLength(36)]
        public string OrderId { set; get; }

        /// <summary>
        /// 商品名称
        /// </summary>
        [Required]
        [StringLength(36)]
        public string  GoodsId { set; get; }

        /// <summary>
        /// 单价
        /// </summary>
        [Required]
        public decimal Price { set; get; }

        /// <summary>
        /// 数量
        /// </summary>
        [Required]
        public int Count { set; get; }

        /// <summary>
        /// 小计
        /// </summary>
        [Required]
        public decimal Money { set; get; }
    }
}
