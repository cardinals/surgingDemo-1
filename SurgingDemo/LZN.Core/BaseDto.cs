﻿using Surging.Core.CPlatform;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroService.Core
{
    public class BaseDto : RequestData
    {


     

        public string Id { set; get; }

        public int IsDelete { set; get; }

        public DateTime CreateDate { set; get; }

        public byte[] Timestamp { set; get; }

      
        


     

    }
}
