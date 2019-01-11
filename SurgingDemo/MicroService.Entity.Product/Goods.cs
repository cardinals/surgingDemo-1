using MicroService.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroService.Entity.Product
{
   public class Goods: Entity<string>
    {
        public string Name { set; get; }
    }
}
