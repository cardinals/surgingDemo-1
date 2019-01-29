using System;
using System.Collections.Generic;
using System.Text;

namespace MicroService.IApplication.Order.Dto
{
  public  class OrderInfoBatchRequestDto
    {
        public List<OrderInfoRequestDto> OrderInfoRequestList { set; get; }
    }
}
