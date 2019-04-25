using System;
using System.Threading.Tasks;
using Xunit;

namespace NHC.Claims.IntegrationTests
{
    public class ClaimsTest
    {
        private TestContext _context;
        public ClaimsTest()
        {
            _context = new TestContext();
        }

        [Fact]
        public async Task GetClaimsForAnYear_Valid_Response()
        {
            var response = await _context.Client.GetAsync("api/claims/1");
            var responseMessage = await response.Content.ReadAsStringAsync();
        }
    }
}
