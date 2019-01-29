using Surging.Core.CPlatform;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroService.Core
{
    public class BaseDto:RequestData
    {
        public string Id { set; get; }

        public bool IsDelete { set; get; }

        public DateTime CreateDate { set; get; } = DateTime.Now;

    }
}
