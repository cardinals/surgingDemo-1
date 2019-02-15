using MicroService.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroService.IApplication.Order.Dto
{
  public  class GoodsQueryDto:BaseDto
    {
       

        public string Name { set; get; }

        /// <summary>
        /// 库存
        /// </summary>

        public int StockNum { set; get; }

        /// <summary>
        /// 单价
        /// </summary>

        public decimal Price { set; get; }

        /// <summary>
        /// 封面图
        /// </summary>

        public string CoverImgSrc { set; get; }

        /// <summary>
        /// 详情
        /// </summary>

        public string Details { get; set; }
    }
}
