using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LZN.EntityFramwork.Data
{
  public  interface IRespositoryWithDbContext
    {
        DbContext GetDbContext();
    }
}
