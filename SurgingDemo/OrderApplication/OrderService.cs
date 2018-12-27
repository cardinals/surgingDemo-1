using IOrderApplication;
using Surging.Core.CPlatform.Ioc;
using Surging.Core.ProxyGenerator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderApplication
{
    [ModuleName("Order")]
    public class OrderService : ProxyServiceBase, IOrderService
    {
        public async Task<int> Test(int a)
        {
            return await Task.FromResult<int>(a + 1);
        }
    }
}
