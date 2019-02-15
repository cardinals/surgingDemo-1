using System;
using System.Collections.Generic;
using System.Text;

namespace MicroService.IApplication.Order.Dto
{
  public  class OrderDetailBatchRequestDto
    {
        public List<OrderDetailRequestDto> OrderInfoRequestList { set; get; }
    }
}
