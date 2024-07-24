using Domain.Request;
using PosTechFiap.Test.IntegrationTests.BaseClasses;
using NUnit.Framework;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PosTechFiap.Test.IntegrationTests
{
    [TestFixture]
    public class ContactIntegrationTest
    {
        private readonly string baseRoute = "api/Contact";
        private CustomWebApplicationFactory _factory;
        private HttpClient _client;

        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            _factory = new CustomWebApplicationFactory();
            await _factory.InitializeAsync();
            _client = _factory.CreateClient();

        }

        [OneTimeTearDown]
        public async Task OneTimeTearDown()
        {
            await _factory.DisposeAsync();
            _client.Dispose();
        }

        [Test]
        public async Task ShouldAddContactSuccessfully()
        {
            var request = new CreateContactRequest()
            {
                DDD = 27,
                Email = "12345@outlook.com",
                Name = "Test",
                Telephone = "976436563"
            };

            var body = JsonSerializer.Serialize(request);
            var content = new StringContent(body, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(baseRoute, content);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
