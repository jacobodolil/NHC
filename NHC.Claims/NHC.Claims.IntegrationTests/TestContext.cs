using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using NHC.Claims.API;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace NHC.Claims.IntegrationTests
{
    public class TestContext
    {
        public HttpClient Client { get; set; }
        private TestServer _server;

        public TestContext()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            Client = _server.CreateClient();
        }
    }
}
