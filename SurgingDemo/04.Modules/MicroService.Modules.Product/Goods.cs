using MicroService.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MicroService.Modules.Product
{
   public class Goods: Entity<string>
    {
        /// <summary>
        /// 商品名称
        /// </summary>
        [Required]
        [StringLength(128)]
        public string Name { set; get; }

        /// <summary>
        /// 库存
        /// </summary>
        [Required]
        public int StockNum { set; get; }

        /// <summary>
        /// 单价
        /// </summary>
        [Required]
        public decimal Price { set; get; }

        /// <summary>
        /// 封面图
        /// </summary>
        [Required,StringLength(256)]
        public string CoverImgSrc { set; get; }

        /// <summary>
        /// 详情
        /// </summary>
        [Required]
        public string Details { get; set; }
    }
}
