using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LZN.Core.Data
{
    /// <summary>
    /// 业务单元操作接口
    /// </summary>
    public interface IUnitOfWork
    {


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        Task<int> SaveChangesAsync();


        DbContext GetDbContext();
       
    }
}
