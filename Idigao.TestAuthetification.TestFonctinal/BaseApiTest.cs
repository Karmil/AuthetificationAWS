using Idigao.TestAuthetification.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Text;

namespace Idigao.TestAuthetification.TestFonctinal
{
    
    public abstract class BaseApiTest
    {
        protected readonly HttpClient _client;
        protected string _contentRoot;

        public BaseApiTest()
        {
            //_client = GetClient();
        }

        //protected HttpClient GetClient()
        //{
            //var startupAssembly = typeof(Startup).GetTypeInfo().Assembly;
            //_contentRoot = GetProjectPath(startupAssembly);
            //var builder = new WebHostBuilder()
            //    .UseContentRoot(_contentRoot)
            //    .UseEnvironment("Testing")
            //    .UseStartup<Startup>();

            //var server = new TestServer(builder);

            //// seed data
            //using (var scope = server.Host.Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider;
            //    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
               
            //}

            //return server.CreateClient();
        //}

        

    }
}
