using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DDDDD
{
   public class OrderInfo
    {
        [Key]
        [StringLength(36)]
        public  string Id { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        [Required]
        [StringLength(128)]
        public string OrderNumber { set; get; }

        /// <summary>
        /// 总金额
        /// </summary>

        [Required]
        public decimal TotalMoney { set; get; }

        /// <summary>
        /// 下单用户
        /// </summary>
        [Required]
        [StringLength(36)]
        public string UserId { set; get; }

        /// <summary>
        /// 订单状态
        /// </summary>
        [Required]
        public int Status { set; get; }


        /// <summary>
        /// 订单过期时间
        /// </summary>
        [Required]
        public DateTime ExpireTime { set; get; }
    }
}
