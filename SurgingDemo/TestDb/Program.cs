using Microsoft.AspNetCore.Hosting;
using System;

namespace TestDb
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                   .UseStartup<Startup>();
                      host.Run();
        }
    }
}
